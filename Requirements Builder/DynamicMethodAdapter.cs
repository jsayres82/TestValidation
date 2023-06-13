// © Parata Systems, LLC 2008 
// All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.IO;
using Microsoft.CSharp;
using System.Diagnostics;
using System.ComponentModel;

namespace Requirements_Builder
{
    /// <summary>
    /// Generates an adapted ControlsProcess class to use with the PropertyGrid.
    /// </summary>
    public static class DynamicMethodAdapter
    {
        /// <summary>
        /// Caching mechanism for compiled assemblies.
        /// </summary>
        private static Dictionary<String, Assembly> _compiledAssemblyCache = new Dictionary<String, Assembly>();
        private static String nameSpace = "RemoteTest";
        private static String className = "MethodAdapter";

        public static String getMethodSignature(MethodInfo method)
        {
            return getMethodSignature(method, false);
        }

        public static String getMethodSignature(MethodInfo method, bool fullName)
        {
            String type = getMethodType(method);
            String name = fullName ? getMethodFullName(method) : getMethodName(method);
            String parameters = getMethodParameters(method);

            return String.Format("{0} {1}{2}", type, name, parameters);
        }

        private static String getMethodName(MethodInfo method)
        {
            return method.Name;
        }

        private static String getMethodFullName(MethodInfo method)
        {
            return String.Format("{0}.{1}", getFriendlyTypeName(method.DeclaringType), getMethodName(method));
        }

        private static String getMethodType(MethodInfo method)
        {
            return getFriendlyTypeName(method.ReturnType);
        }

        private static String getMethodParameters(MethodInfo method)
        {
            List<String> parameters = new List<String>();

            foreach (var param in method.GetParameters())
            {
                parameters.Add(String.Format("{0} {1}", getFriendlyTypeName(param.ParameterType), param.Name));
            }

            return String.Format("({0})", String.Join(", ", parameters.ToArray()));
        }

        public static String[] getParameterNames(MethodInfo method)
        {
            var parameters = method.GetParameters();
            var parameterNames = new String[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameterNames[i] = parameters[i].Name;
            }

            return parameterNames;
        }

        public static String getFriendlyTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                String name = type.Name.Substring(0, type.Name.IndexOf('`'));
                String format = "{0}<{1}>";

                List<String> genericArgs = new List<String>();
                foreach (var arg in type.GetGenericArguments())
                {
                    genericArgs.Add(getFriendlyTypeName(arg));
                }

                return String.Format(format, name, String.Join(", ", genericArgs.ToArray()));
            }
            else
            {
                return type.Name;
            }
        }

        /// <summary>
        /// Creates a new type at runtime. 
        /// </summary>        
        /// <param name="objectUnknown"><see cref="object"/>to adapt</param>
        /// <param name="name"><see cref="string"/> representing the name of the process.</param>
        /// <param name="output">Flag indicating write the adapter to disk or just memory.</param>
        /// <returns>adapted object</returns>
        public static object Create(MethodInfo method, Output output)
        {
            object proxy = null;
            String signature = getMethodSignature(method, true);
            //
            // Only recompile if necessary
            //
            if (_compiledAssemblyCache.ContainsKey(signature))
            {
                return CreateInstance(_compiledAssemblyCache[signature]);
            }

            using (CSharpCodeProvider compiler = new CSharpCodeProvider())
            {
                //
                // Set up compiler params for an in-memory dll
                //
                CompilerParameters options = new CompilerParameters();
                options.GenerateInMemory = true;
                options.GenerateExecutable = false;
                options.IncludeDebugInformation = false;

                var assemblies = GetReferences(method);
                options.ReferencedAssemblies.AddRange(assemblies.ToArray());
                // options.CompilerOptions = "/optimize";
                //
                // Set a temporary files collection. The TempFileCollection stores the temporary files
                // generated during a build in the current directory, and deletes them after compilation.
                //
                bool keepFiles = false;
                options.TempFiles = new TempFileCollection(".", keepFiles);
                //
                // Attempt to compile generated source
                //
                string fullSource = GenerateSource(method, output);

                //
                // If no source, punt and return a plain-jane obj.
                //
                if (fullSource == String.Empty)
                    return new object();

                CompilerResults results = compiler.CompileAssemblyFromSource(options, fullSource);
                //
                // If compilation failed, punt
                //
                if (results.Errors.HasErrors)
                {
                    string errors = String.Empty;
                    foreach (CompilerError error in results.Errors)
                    {
                        errors += error.ToString();
                    }

                    throw new ApplicationException(errors);
                }

                //foreach(string output in results.Output)
                //{
                //    Debug.WriteLine(output);
                //}

                try
                {
                    //
                    // If compilation succeeded, create new instance of generated class.
                    //
                    Assembly assembly = results.CompiledAssembly;
                    _compiledAssemblyCache.Add(signature, assembly);
                    proxy = CreateInstance(assembly);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw new ApplicationException("Could not create method adapter.", ex);
                }
            }

            return proxy;
        }

        private static string GenerateSource(MethodInfo method, Output output)
        {
            using (TextWriter sw = new StringWriter())
            {
                using (CSharpCodeProvider cscProvider = new CSharpCodeProvider())
                {
                    ICodeGenerator codeGenerator = cscProvider.CreateGenerator(sw);
                    CodeGeneratorOptions codeGenerationOptions = new CodeGeneratorOptions();
                    //
                    // Place braces on newline
                    //
                    codeGenerationOptions.BracingStyle = "C";
                    CodeNamespace nspace = new CodeNamespace(nameSpace);
                    //codeGenerator.GenerateCodeFromCompileUnit(compileUnit, sw, codeGenerationOptions);
                    //
                    // Create a class named after the type - append Adapter to the name.
                    //
                    CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration();
                    codeTypeDeclaration.IsClass = true;
                    codeTypeDeclaration.Name = className;
                    codeTypeDeclaration.TypeAttributes = TypeAttributes.Public;
                    nspace.Types.Add(codeTypeDeclaration);

                    CodeAttributeDeclaration typeConverterDeclaration = new CodeAttributeDeclaration(
                        new CodeTypeReference(typeof(TypeConverterAttribute)), new CodeAttributeArgument(
                            new CodeTypeOfExpression((typeof(ExpandableObjectConverter)))));
                    codeTypeDeclaration.CustomAttributes.Add(typeConverterDeclaration);

                    AddProperties(method, codeTypeDeclaration);

                    //
                    // Generate code for the new type
                    //
                    codeGenerator.GenerateCodeFromNamespace(nspace, sw, codeGenerationOptions);
                }

                Debug.WriteLine(sw.ToString());

                //
                // Helpful for seeing the actual generated class
                //
                if (Output.File == output)
                {
                    using (StreamWriter streamWriter = new StreamWriter(className + ".cs"))
                    {
                        streamWriter.Write(sw.ToString());
                    }
                }

                return sw.ToString();
            }
        }

        /// <summary>
        /// Responsible for generating the adapter class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        //private static string GenerateSource(Type type, Output output)
        //{
        //    TextWriter sw = new StringWriter();

        //    using (CSharpCodeProvider cscProvider = new CSharpCodeProvider())
        //    {
        //        ICodeGenerator codeGenerator = cscProvider.CreateGenerator(sw);
        //        CodeGeneratorOptions codeGenerationOptions = new CodeGeneratorOptions();
        //        //
        //        // Place braces on newline
        //        //
        //        codeGenerationOptions.BracingStyle = "C";
        //        CodeNamespace nspace = new CodeNamespace(nameSpace);
        //        nspace.Imports.Add(new CodeNamespaceImport("System"));
        //        //codeGenerator.GenerateCodeFromCompileUnit(compileUnit, sw, codeGenerationOptions);
        //        //
        //        // Create a class named after the type - append Adapter to the name.
        //        //
        //        CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration();
        //        codeTypeDeclaration.IsClass = true;
        //        codeTypeDeclaration.Name = className;
        //        codeTypeDeclaration.TypeAttributes = TypeAttributes.Public;
        //        nspace.Types.Add(codeTypeDeclaration);
        //        //
        //        // Inherit from MarshalByRefObject, as this needs to support remoting.
        //        //
        //        codeTypeDeclaration.BaseTypes.Add(typeof(MarshalByRefObject));
        //        //
        //        // Mark the type as Serializable for use with Remoting.
        //        //
        //        CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration("System.SerializableAttribute");
        //        codeTypeDeclaration.CustomAttributes.Add(codeAttributeDeclaration);

        //        //
        //        // Create a private member to store the concrete ControlsProcess instance.
        //        //
        //        CodeMemberField declaration = new CodeMemberField(type, "_process");
        //        declaration.Attributes = MemberAttributes.Private;
        //        codeTypeDeclaration.Members.Add(declaration);
        //        //
        //        // Create a constructor that accepts a param of type ControlsObject.
        //        //
        //        CodeConstructor paramConstructor = new CodeConstructor();
        //        paramConstructor.Attributes = MemberAttributes.Public;
        //        paramConstructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "processName"));
        //        //
        //        // Immediately convert constructor param to concrete type, as we are gonna need the specialized members.
        //        //
        //        paramConstructor.Statements.Add(new CodeSnippetStatement("\t\t_process = Parata.Controls.ControlsObjectFactory.getProcess(processName) as " + type + ";"));
        //        codeTypeDeclaration.Members.Add(paramConstructor);
        //        //
        //        // Generate source for the new type
        //        //
        //        // codeGenerator.GenerateCodeFromType(codeTypeDeclaration, sw, codeGenerationOptions);
        //        codeGenerator.GenerateCodeFromNamespace(nspace, sw, codeGenerationOptions);
        //    }

        //    sw.Close();
        //    //
        //    // Helpful for seeing the actual generated class
        //    //
        //    if (Output.File == output)
        //    {
        //        using (StreamWriter streamWriter = new StreamWriter(className + ".cs"))
        //        {
        //            streamWriter.Write(sw.ToString());
        //        }
        //    }

        //    return sw.ToString();
        //}

        private static void AddProperties(MethodInfo method, CodeTypeDeclaration codeTypeDeclaration)
        {
            if (!isVoid(method))
            {
                GenerateProperty(codeTypeDeclaration, method.ReturnType, "Return", "Return");
            }

            foreach (var parameter in method.GetParameters())
            {
                GenerateProperty(codeTypeDeclaration, parameter.ParameterType, parameter.Name, "Parameters");
            }
        }

        private static void GenerateProperty(CodeTypeDeclaration codeTypeDeclaration, Type propertyType, String name, String category)
        {
            string fieldName = "_" + name;
            CodeMemberField declaration = new CodeMemberField(propertyType, fieldName);
            declaration.Attributes = MemberAttributes.Private;
            codeTypeDeclaration.Members.Add(declaration);

            CodeMemberProperty codeMemberProperty = new CodeMemberProperty();
            codeMemberProperty.Attributes = MemberAttributes.Public;
            codeMemberProperty.Type = new CodeTypeReference(propertyType);
            codeMemberProperty.Name = name;

            codeMemberProperty.HasGet = true;
            codeMemberProperty.GetStatements.Add(new CodeSnippetExpression("return " + fieldName));

            codeMemberProperty.HasSet = true;
            codeMemberProperty.SetStatements.Add(new CodeSnippetExpression(fieldName + " = value"));

            CodeAttributeDeclaration categoryDeclaration = new CodeAttributeDeclaration(
                        new CodeTypeReference(typeof(CategoryAttribute)), new CodeAttributeArgument(new CodePrimitiveExpression(category)));
            codeMemberProperty.CustomAttributes.Add(categoryDeclaration);

            codeTypeDeclaration.Members.Add(codeMemberProperty);
        }
        /// <summary>
        /// Simple factory method
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/></param>
        /// <returns></returns>
        private static object CreateInstance(Assembly assembly)
        {
            Type type = assembly.GetType(nameSpace + "." + className);
            return Activator.CreateInstance(type);
        }

        private static List<String> GetReferences(MethodInfo method)
        {
            var assemblies = GetReferencedAssemblies(method.DeclaringType);
            if (!isVoid(method))
            {
                assemblies.AddRange(GetReferencedAssemblies(method.ReturnType));
            }

            foreach (var parameter in method.GetParameters())
            {
                assemblies.AddRange(GetReferencedAssemblies(parameter.ParameterType));
            }

            assemblies.Add(typeof(ExpandableObjectConverter).Assembly.GetName());

            List<String> assemblyNames = new List<String>();
            foreach (var assemblyName in assemblies)
            {
                var assembly = Assembly.Load(assemblyName);
                assemblyNames.Add(assembly.Location);
            }

            return assemblyNames.Distinct().ToList();
        }

        public static Boolean isVoid(MethodInfo method)
        {
            return method.ReturnType == typeof(void);
        }

        private static List<AssemblyName> GetReferencedAssemblies(Type type)
        {
            var assemblies = GetReferencedAssemblies(type.Assembly);

            if (type.IsGenericType)
            {
                foreach (var parameter in type.GetGenericArguments())
                {
                    assemblies.AddRange(GetReferencedAssemblies(parameter));
                }
            }

            return assemblies;
        }

        private static List<AssemblyName> GetReferencedAssemblies(Assembly assembly)
        {
            var assemblies = assembly.GetReferencedAssemblies().ToList();
            assemblies.Add(assembly.GetName());
            return assemblies;
        }

        private static string appDirectory;
        private static string AppDirectory
        {
            get
            {
                if (String.IsNullOrEmpty(appDirectory))
                    appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                return appDirectory;
            }
        }

        /// <summary>
        /// Specifies how the process adapter should be output.
        /// </summary>
        public enum Output
        {
            /// <summary>
            /// Specifies the process adapter should only be created in memory.
            /// </summary>
            Memory,
            /// <summary>
            /// Specifies the process adapter source should be written to disk. 
            /// </summary>
            File
        }
    }
}

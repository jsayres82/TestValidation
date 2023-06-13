
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Requirements_Builder
{   
    public class TreeBuilder
    {
        static TreeBuilderBase imp = new TreeBuilderBase();
        
        /// <summary>
        ///  A static TreeNode factory.   
        ///  It uses TreeBuilderBase
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public TreeNode ToTree(object obj)
        {
            return imp.ToTree(obj, obj.GetType().Name);
        }

        /// <summary>
        ///  A static TreeNode factory.   
        ///  It uses TreeBuilderBase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        static public TreeNode ToTree(object obj, string name)
        {
            return imp.ToTree(obj, name);
        }
    }

    /// <summary>
    /// Take an object and constructs an TreeNode tree that matchs it data fields. 
    /// Recurse down objects
    /// </summary>
    public class TreeBuilderBase
    {        
        /// <summary>
        /// Construct a single tree node 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual TreeNode ToTree(object o, string name)
        {
            Type type = o.GetType();
            if(type.IsPrimitive)
            {
                return PrimitiveToNode(o, name, o.ToString());
            }
            else
            {
                return WalkObject(o, name);
            }
        }


        /// <summary>
        ///  Use reflection to walk over object and construct all displayable fields
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual TreeNode WalkObject(object obj, string name)
        {
            TreeNode node = ObjectToNode(obj, name);

            Type t = obj.GetType();
            MemberInfo[] allMembers = t.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);

            foreach(MemberInfo member in allMembers)
            {
                try
                {            
                    object o = null;

                    switch(member.MemberType)
                    {
                        case MemberTypes.Property:
                            PropertyInfo p = member as PropertyInfo;
                            o = p.GetValue(obj, null);
                            break;
                        case MemberTypes.Field:
                            FieldInfo f = member as FieldInfo;
                            o = f.GetValue(obj);
                            break;
                        default:
                            continue;
                    }                    
                    
                    if(o is Array)
                    {
                        object[] ar = (object[])o;  //FIXME - we can only deal with one dimensional arrays
                        foreach(object i in ar)
                        {
                            node.Nodes.Add(ObjectToNode(i, member.Name));                            
                        }
                    }
                    else
                    {
                        Type type = o.GetType();
                        if(type.IsPrimitive || type.Name == "String")
                        {
                            node.Nodes.Add(PrimitiveToNode(o, member.Name, o.ToString()));
                        }
                        else
                        {
                            node.Nodes.Add(ObjectToNode(o, member.Name));
                        }
                    }
                }
                catch { }
            }

            return node;
        }


        /// <summary>
        ///  Construct a node for a C# primitive
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        protected virtual TreeNode PrimitiveToNode(object o, string name, string currentValue)
        {
            TreeNode node = new TreeNode(name + " = " + currentValue);
            node.Tag = o;
            return node;
        }


        /// <summary>
        ///  Construct the root node for a class object.  WalkObject will add all the child objects
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        protected virtual TreeNode ObjectToNode(object o, string name)
        {
            TreeNode node = new TreeNode(name);
            node.Tag = o;
            return node;
        }
    }
}

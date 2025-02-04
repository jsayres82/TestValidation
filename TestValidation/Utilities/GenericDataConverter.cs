using iText.Barcodes.Dmcode;
using MicrowaveNetworks;
using MicrowaveNetworks.Matrices;
using MicrowaveNetworks.Touchstone;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Nuvo.TestValidation.Limits;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuvo.TestValidation.Parameters;
using Nuvo.TestValidation.Limits.Validators;
using ScottPlot.TickGenerators.TimeUnits;
using System.Reflection;

namespace Nuvo.TestValidation.Utilities
{
    public class GenericDataConverter
    {
        public static INetworkParametersCollection ToNetworkParameters(Dictionary<string, List<object[]>> baseDataSet)
        {
            //// Get the frequency points
            var parameterDomain = baseDataSet.Keys.ToList();
            //var sumTraceList = new List<double>(parameterDomain.Count);
            var frequencyList = new List<string>(parameterDomain.Count);
            
            bool isFirstPass = true;
            List<INetworkParametersCollection> c = new List<INetworkParametersCollection>();

            // Loop through each frequency and populate the network parameter values for each sParameter
            foreach (var d in baseDataSet)
            {
                frequencyList.Add(d.Key);
                var m = d.Value.First();
                var matrix = new ScatteringParametersMatrix((IList<NetworkParameter>)m[0]);
                var pair = new FrequencyParametersPair(Convert.ToDouble(d.Key), matrix);
                
                if(isFirstPass)
                {
                    c.Add(new NetworkParametersCollection<ScatteringParametersMatrix>(matrix.NumPorts));
                    isFirstPass = false;
                }
                c.First().Add(pair.Frequency_Hz, pair.Parameters as ScatteringParametersMatrix);
            }

            return c.First();
        }


        public static Dictionary<string, List<object[]>> FromNetworkParameters(string filePath)
        {
            Dictionary<string, List<object[]>> data = new Dictionary<string, List<object[]>>();
            INetworkParametersCollection coll = Touchstone.ReadAllData(filePath);
            Dictionary<string, IList<NetworkParameter>> networkParamCollDataDic = new Dictionary<string, IList<NetworkParameter>>();
            foreach (FrequencyParametersPair pair in coll)
            {
                var matrixEnum = pair.Parameters.GetEnumerator(ListFormat.SourcePortMajor);
                IList<NetworkParameter> flattenedList = new List<NetworkParameter>();
                while (matrixEnum.MoveNext())
                {
                    flattenedList.Add(matrixEnum.Current.NetworkParameter);
                }
                networkParamCollDataDic.Add(pair.Frequency_Hz.ToString(), flattenedList.ToArray());
            }
            foreach (var dList in networkParamCollDataDic)
            {
                data.Add(dList.Key.ToString(), new List<object[]>());
                data[dList.Key.ToString()].Add(new object[] { networkParamCollDataDic[dList.Key] });
            }
            return data;
        }


    }

    /// <summary>
    /// Custom JSON converter for the TestRequirement class, handling serialization and deserialization.
    /// </summary>
    public class TestRequirementsConverter : JsonConverter<List<TestRequirement>>
    {
        /// <summary>
        /// Reads a JSON object and converts it into a TestRequirement instance.
        /// This method handles dynamic deserialization of properties like Name, Limit, and CharacteristicParameter.
        /// </summary>
        public override List<TestRequirement> ReadJson(JsonReader reader, Type objectType, List<TestRequirement> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Load the array of TestRequirements
            JArray array = JArray.Load(reader);

            var testRequirements = new List<TestRequirement>();

            // Iterate over the array and deserialize each object
            foreach (var item in array)
            {
                var parentObject = new TestRequirement
                {
                    Name = item["Name"]?.ToString(),
                    Limit = CreateLimitFromJson((JObject)item, serializer)
                };

                parentObject.CharacteristicParameter = CreateGenericParameterFromJson((JObject)item, serializer, parentObject);

                testRequirements.Add(parentObject);
            }

            return testRequirements;
        }

        /// <summary>
        /// Writes a TestRequirement instance as a JSON object.
        /// This method serializes properties like Name, Limit, and CharacteristicParameter.
        /// </summary>
        public override void WriteJson(JsonWriter writer, List<TestRequirement> values, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            writer.Formatting = Formatting.Indented;

            foreach (var value in values)
            {
                writer.WriteStartObject();
                // Serialize Name
                writer.WritePropertyName("Name");
                serializer.Serialize(writer, value.Name);

                // Serialize Limit (which can be of different types dynamically)
                if (value.Limit != null)
                {
                    string limitTypeName = value.Limit.GetType().Name; // Get the actual type name
                    writer.WritePropertyName(limitTypeName);

                    writer.WriteStartObject();

                    var validatorName = value.Limit?.Validator?.GetType()?.Name?.Split("`")[0];
                    if (value.Limit.Validator != null)
                    {
                        var validatorValue = value.Limit.Validator;
                        if (validatorValue != null)
                        {
                            writer.WritePropertyName(validatorName);
                            serializer.Serialize(writer, validatorValue);
                        }
                    }

                    // Serialize remaining properties of Limit dynamically
                    foreach (var prop in value.Limit.GetType().GetProperties())
                    {
                        if (prop.Name != validatorName) // Avoid re-serializing the validator
                        {
                            var jsonPropertyAttribute = prop.GetCustomAttribute<JsonPropertyAttribute>();
                            string propertyName = jsonPropertyAttribute?.PropertyName ?? prop.Name;

                            writer.WritePropertyName(propertyName);
                            serializer.Serialize(writer, prop.GetValue(value.Limit));
                        }
                    }
                    writer.WriteEndObject();
                }

                if (value.CharacteristicParameter != null)
                {
                    var characteristicParameterTypeName = value.CharacteristicParameter.GetType()?.Name;
                    writer.WritePropertyName(characteristicParameterTypeName);
                    serializer.Serialize(writer, value.CharacteristicParameter);

                    // Serialize remaining Parameters of CharacteristicParameter dynamically
                    foreach (var prop in value.CharacteristicParameter.GetType().GetProperties())
                    {
                        if (prop.Name != characteristicParameterTypeName) // Avoid re-serializing the Parameter
                        {
                            var jsonPropertyAttribute = prop.GetCustomAttribute<JsonPropertyAttribute>();
                            string propertyName = jsonPropertyAttribute?.PropertyName ?? prop.Name;

                            writer.WritePropertyName(propertyName);
                            serializer.Serialize(writer, prop.GetValue(value.CharacteristicParameter));
                        }
                    }
                }
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
        }

        /// <summary>
        /// Dynamically determines and creates the appropriate Limit object from JSON.
        /// This method matches the type of Limit in the JSON and creates a corresponding instance.
        /// </summary>
        public GenericParameter CreateGenericParameterFromJson(JObject jo, JsonSerializer serializer, TestRequirement testRequirement)
        {
            var genericParameterTypes = GenericParameter.GetGenericParameterTypes();
            List<string> typeValues = FindAllTypeValues(jo);

            foreach (var typeValue in typeValues)
            {
                var targetType = Type.GetType(typeValue);
                genericParameterTypes.TryGetValue(targetType.Name.Split("`")[0], out var genericParameterType);

                if (genericParameterType != null)
                {
                    GenericParameter limitInstance = (GenericParameter)Activator.CreateInstance(genericParameterType);
                    var parameterProperty = FindPropertyObject(jo, genericParameterType.Name);
                    serializer.Populate(parameterProperty.CreateReader(), limitInstance);
                    return limitInstance;
                }
            }

            foreach (var parameterName in genericParameterTypes.Keys)
            {
                var parameterProperty = jo[parameterName];
                if (parameterProperty != null)
                {
                    Type parameterType = genericParameterTypes[parameterName];
                    GenericParameter limitInstance = (GenericParameter)Activator.CreateInstance(parameterType);
                    serializer.Populate(parameterProperty.CreateReader(), limitInstance);
                    return limitInstance;
                }
            }
            return null;
        }

        /// <summary>
        /// Provides helper methods for JSON serialization and deserialization.
        /// Searches for a property with the specified key in the JSON object, recursively if necessary.
        /// </summary>
        static JObject FindPropertyObject(JObject obj, string key)
        {
            foreach (var property in obj.Properties())
            {
                if (property.Name == key && property.Value.Type == JTokenType.Object)
                {
                    return (JObject)property.Value;
                }

                if (property.Value.Type == JTokenType.Object)
                {
                    JObject result = FindPropertyObject((JObject)property.Value, key);
                    if (result != null) return result;
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var item in (JArray)property.Value)
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            JObject result = FindPropertyObject((JObject)item, key);
                            if (result != null) return result;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Recursively searches for all type values in the JSON object.
        /// </summary>
        static List<string> FindAllTypeValues(JObject obj)
        {
            List<string> typeValues = new List<string>();

            foreach (var property in obj.Properties())
            {
                if (property.Name == "$type" && property.Value.Type == JTokenType.String)
                {
                    typeValues.Add(property.Value.ToString());
                }

                if (property.Value.Type == JTokenType.Object)
                {
                    typeValues.AddRange(FindAllTypeValues((JObject)property.Value));
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var item in (JArray)property.Value)
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            typeValues.AddRange(FindAllTypeValues((JObject)item));
                        }
                    }
                }
            }

            return typeValues;
        }

        /// <summary>
        /// Creates and populates a Limit object from the JSON representation.
        /// This method deserializes properties into the correct Limit type based on its name in the JSON.
        /// </summary>
        public GenericLimit CreateLimitFromJson(JObject jo, JsonSerializer serializer)
        {
            var limitTypes = GenericLimit.GetLimitTypes();
            foreach (var limitName in limitTypes.Keys)
            {
                var limitProperty = jo[limitName];

                if (limitProperty != null)
                {
                    Type limitType = limitTypes[limitName];
                    GenericLimit limitInstance = (GenericLimit)Activator.CreateInstance(limitType);
                    serializer.Populate(limitProperty.CreateReader(), limitInstance);

                    var lProperty = limitProperty as JObject;
                    var validatorProperty = lProperty.Properties().FirstOrDefault(p => p.Name.EndsWith("Validator"));
                    if (validatorProperty != null)
                    {
                        var validatorType = GetGenericParameterTypeFromName(validatorProperty.Name);
                        if (validatorType != null)
                        {
                            var genericArgumentType = typeof(double);
                            var genericValidatorType = validatorType.MakeGenericType(genericArgumentType);
                            var validator = validatorProperty.Value.ToObject(genericValidatorType, serializer);
                            limitInstance.SetValidator(validator);
                        }
                    }

                    return limitInstance;
                }
            }

            return null;
        }

        /// <summary>
        /// Resolves a validator type based on the parameter name.
        /// </summary>
        private Type GetGenericParameterTypeFromName(string paramName)
        {
            var validatorTyps = ValidatorHelper.GetValidatorTypes();
            var validatorExist = validatorTyps.TryGetValue(paramName, out var validatorType);

            if (validatorExist)
            {
                return validatorType;
            }
            return null;
        }
    }

    /// <summary>
    /// Custom JSON converter for the GenericValidator class, handling serialization and deserialization of the GenericValidator<T> type.
    /// </summary>
    public class GenericValidatorConverter : JsonConverter<GenericValidator<double>>
    {
        /// <summary>
        /// Reads a JSON object and converts it into a GenericValidator instance.
        /// </summary>
        public override GenericValidator<double> ReadJson(JsonReader reader, Type objectType, GenericValidator<double> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var typeName = jo["$type"]?.ToString();
            Type targetType = null;

            if (!string.IsNullOrEmpty(typeName))
            {
                targetType = Type.GetType(typeName);
            }

            if (targetType == null)
            {
                // Default to a fallback type if no type info exists
            }

            return (GenericValidator<double>)serializer.Deserialize(jo.CreateReader(), targetType);
        }

        /// <summary>
        /// Writes a GenericValidator instance as a JSON object.
        /// </summary>
        public override void WriteJson(JsonWriter writer, GenericValidator<double> value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("$type");
            writer.WriteValue(value.GetType().AssemblyQualifiedName);

            foreach (var prop in value.GetType().GetProperties())
            {
                writer.WritePropertyName(prop.Name);
                serializer.Serialize(writer, prop.GetValue(value));
            }

            writer.WriteEndObject();
        }
    }

    /// <summary>
    /// Custom JSON converter for the GenericParameter class, handling serialization and deserialization of the GenericParameter type.
    /// </summary>
    //public class CharacteristicParameterConverter : JsonConverter<GenericParameter>
    //{
    //    /// <summary>
    //    /// Reads a JSON object and converts it into a GenericParameter instance.
    //    /// </summary>
    //    public override GenericParameter ReadJson(JsonReader reader, Type objectType, GenericParameter existingValue, bool hasExistingValue, JsonSerializer serializer)
    //    {
    //        JObject jo = JObject.Load(reader);

    //        //var typeName = jo["$type"]?.ToString();
    //        //Type targetType = null;

    //        //if (!string.IsNullOrEmpty(typeName))
    //        //{
    //        //    targetType = Type.GetType(typeName);
    //        //}
    //        return (GenericParameter)serializer.Deserialize(jo.CreateReader(), objectType);
    //    }

    //    /// <summary>
    //    /// Writes a GenericParameter instance as a JSON object.
    //    /// </summary>
    //    public override void WriteJson(JsonWriter writer, GenericParameter value, JsonSerializer serializer)
    //    {
    //        writer.WriteStartObject();

    //        writer.WritePropertyName("$type");
    //        writer.WriteValue(value.GetType().AssemblyQualifiedName);

    //        foreach (var prop in value.GetType().GetProperties())
    //        {
    //            writer.WritePropertyName(prop.Name);
    //            serializer.Serialize(writer, prop.GetValue(value));
    //        }

    //        writer.WriteEndObject();
    //    }
    //}


}

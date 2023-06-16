using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Nuvo.Math.Misc
{
	/// <summary>
	/// Static Storage Class.
	/// </summary>
	public static class Storage
	{
		/// <summary>
		/// Binary Serialize an Object to a file.
		/// </summary>
		/// <param name="a">Object</param>
		/// <param name="filepath">File Path</param>
		public static void BinarySerialize(object a, string filepath)
		{
			FileStream fs = new FileStream(filepath, FileMode.Create);
			new BinaryFormatter().Serialize(fs, a);
			fs.Close();
		}

		/// <summary>
		/// Binary Deserialize an Object from a file.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		public static T BinaryDeserialize<T>(string filepath)
		{
			FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
			T result;
			try
			{
				result = (T)((object)new BinaryFormatter
				{
					AssemblyFormat = FormatterAssemblyStyle.Simple,
					Binder = new SimpleDeserializationBinder()
				}.Deserialize(fs));
			}
			finally
			{
				fs.Close();
			}
			return result;
		}

		/// <summary>
		/// Binary Serialize an Object to a byte array.
		/// </summary>
		/// <param name="a">Object</param>
		/// <returns>Binary Data</returns>
		public static byte[] BinarySerializeToByteArray(object a)
		{
			MemoryStream ms = new MemoryStream();
			new BinaryFormatter().Serialize(ms, a);
			return ms.ToArray();
		}

		/// <summary>
		/// Binary Deserialize an Object from a byte array.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="data">Binary Data</param>
		/// <returns>Object</returns>
		public static T BinaryDeserializeFromByteArray<T>(byte[] data)
		{
			MemoryStream ms = new MemoryStream(data);
			T result;
			try
			{
				result = (T)((object)new BinaryFormatter
				{
					AssemblyFormat = FormatterAssemblyStyle.Simple,
					Binder = new SimpleDeserializationBinder()
				}.Deserialize(ms));
			}
			finally
			{
				ms.Close();
			}
			return result;
		}

		/// <summary>
		/// Xml Serialize an Object to a file.
		/// </summary>
		/// <param name="a">Object</param>
		/// <param name="filepath">File Path</param>
		public static void XmlSerialize(object a, string filepath)
		{
			FileStream fs = new FileStream(filepath, FileMode.Create);
			new XmlSerializer(a.GetType()).Serialize(fs, a);
			fs.Close();
		}

		/// <summary>
		/// Xml Deserialize an Object from a file.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		public static T XmlDeserialize<T>(string filepath)
		{
			FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
			T result;
			try
			{
				result = (T)((object)new XmlSerializer(typeof(T)).Deserialize(fs));
			}
			finally
			{
				fs.Close();
			}
			return result;
		}

		/// <summary>
		/// Xml Serialize an Object to an string.
		/// </summary>
		/// <param name="a">Object</param>
		/// <returns>XML String</returns>
		public static string XmlSerializeToString(object a)
		{
			StringWriter sw = new StringWriter();
			new XmlSerializer(a.GetType()).Serialize(sw, a);
			return sw.ToString();
		}

		/// <summary>
		/// Xml Deserialize an Object from a string.
		/// </summary>
		/// <param name="xml_string">XML String</param>
		/// <typeparam name="T">Type</typeparam>
		/// <returns>Object</returns>
		public static T XmlDeserializeFromString<T>(string xml_string)
		{
			StringReader sw = new StringReader(xml_string);
			return (T)((object)new XmlSerializer(typeof(T)).Deserialize(sw));
		}
	}
}

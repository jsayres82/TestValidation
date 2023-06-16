using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Nuvo.Math.Core.Misc
{
	/// <summary>
	/// Static Storage Class.
	/// </summary>
	// Token: 0x02000010 RID: 16
	public static class Storage
	{
		/// <summary>
		/// Binary Serialize an Object to a file.
		/// </summary>
		/// <param name="a">Object</param>
		/// <param name="filepath">File Path</param>
		// Token: 0x06000126 RID: 294 RVA: 0x00007544 File Offset: 0x00005744
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
		// Token: 0x06000127 RID: 295 RVA: 0x0000756C File Offset: 0x0000576C
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
		// Token: 0x06000128 RID: 296 RVA: 0x000075C0 File Offset: 0x000057C0
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
		// Token: 0x06000129 RID: 297 RVA: 0x000075E8 File Offset: 0x000057E8
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
		// Token: 0x0600012A RID: 298 RVA: 0x0000763C File Offset: 0x0000583C
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
		// Token: 0x0600012B RID: 299 RVA: 0x0000766C File Offset: 0x0000586C
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
		// Token: 0x0600012C RID: 300 RVA: 0x000076B8 File Offset: 0x000058B8
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
		// Token: 0x0600012D RID: 301 RVA: 0x000076E4 File Offset: 0x000058E4
		public static T XmlDeserializeFromString<T>(string xml_string)
		{
			StringReader sw = new StringReader(xml_string);
			return (T)((object)new XmlSerializer(typeof(T)).Deserialize(sw));
		}
	}
}

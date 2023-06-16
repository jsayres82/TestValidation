using System;
using System.IO;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Storage Interface.
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	public interface IStorage<T>
	{
		/// <summary>
		/// Write object data to Binary Writer.
		/// </summary>
		/// <param name="writer">Binary Writer</param>
		void BinaryWriteDataTo(BinaryWriter writer);

		/// <summary>
		/// Set object data from Binary Reader.
		/// </summary>
		/// <param name="reader">Binary Reader</param>
		void BinarySetDataFrom(BinaryReader reader);

		/// <summary>
		/// Binary Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		void BinarySerialize(string filepath);

		/// <summary>
		/// Binary Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		T BinaryDeserialize(string filepath);

		/// <summary>
		/// Binary Serialize an Object to a byte array.
		/// </summary>
		/// <returns>Binary Data</returns>
		byte[] BinarySerializeToByteArray();

		/// <summary>
		/// Binary Deserialize an Object from a byte array.
		/// </summary>
		/// <param name="data">Binary Data</param>
		/// <returns>Object</returns>
		T BinaryDeserializeFromByteArray(byte[] data);

		/// <summary>
		/// Xml Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		void XmlSerialize(string filepath);

		/// <summary>
		/// Xml Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		T XmlDeserialize(string filepath);

		/// <summary>
		/// Xml Serialize an Object to String.
		/// </summary>
		/// <returns>XML String</returns>
		string XmlSerializeToString();

		/// <summary>
		/// Xml Deserialize an Object from String.
		/// </summary>
		/// <param name="xml_string">Xml String</param>
		/// <returns>Object</returns>
		T XmlDeserializeFromString(string xml_string);
	}
}

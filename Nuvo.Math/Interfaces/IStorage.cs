using System;
using System.IO;

namespace Nuvo.Math.Interface
{
	/// <summary>
	/// Storage Interface.
	/// </summary>
	/// <typeparam name="T">Type</typeparam>
	// Token: 0x02000020 RID: 32
	public interface IStorage<T>
	{
		/// <summary>
		/// Write object data to Binary Writer.
		/// </summary>
		/// <param name="writer">Binary Writer</param>
		// Token: 0x0600017C RID: 380
		void BinaryWriteDataTo(BinaryWriter writer);

		/// <summary>
		/// Set object data from Binary Reader.
		/// </summary>
		/// <param name="reader">Binary Reader</param>
		// Token: 0x0600017D RID: 381
		void BinarySetDataFrom(BinaryReader reader);

		/// <summary>
		/// Binary Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		// Token: 0x0600017E RID: 382
		void BinarySerialize(string filepath);

		/// <summary>
		/// Binary Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		// Token: 0x0600017F RID: 383
		T BinaryDeserialize(string filepath);

		/// <summary>
		/// Binary Serialize an Object to a byte array.
		/// </summary>
		/// <returns>Binary Data</returns>
		// Token: 0x06000180 RID: 384
		byte[] BinarySerializeToByteArray();

		/// <summary>
		/// Binary Deserialize an Object from a byte array.
		/// </summary>
		/// <param name="data">Binary Data</param>
		/// <returns>Object</returns>
		// Token: 0x06000181 RID: 385
		T BinaryDeserializeFromByteArray(byte[] data);

		/// <summary>
		/// Xml Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		// Token: 0x06000182 RID: 386
		void XmlSerialize(string filepath);

		/// <summary>
		/// Xml Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		// Token: 0x06000183 RID: 387
		T XmlDeserialize(string filepath);

		/// <summary>
		/// Xml Serialize an Object to String.
		/// </summary>
		/// <returns>XML String</returns>
		// Token: 0x06000184 RID: 388
		string XmlSerializeToString();

		/// <summary>
		/// Xml Deserialize an Object from String.
		/// </summary>
		/// <param name="xml_string">Xml String</param>
		/// <returns>Object</returns>
		// Token: 0x06000185 RID: 389
		T XmlDeserializeFromString(string xml_string);
	}
}

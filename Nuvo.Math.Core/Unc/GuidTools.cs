using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nuvo.Math.Core.Unc
{
	/// <summary>
	/// GUID Tools
	/// </summary>
	// Token: 0x02000022 RID: 34
	public static class GuidTools
	{
		/// <summary>
		/// Creates a name-based UUID using the algorithm from RFC 4122 §4.3.
		/// </summary>
		/// <param name="fi">File Info</param>
		/// <returns>A UUID derived from hash of the file.</returns>
		// Token: 0x060001E4 RID: 484 RVA: 0x00008CF0 File Offset: 0x00006EF0
		public static Guid CreateFromFile(FileInfo fi)
		{
			Guid id;
			using (FileStream fs = File.OpenRead(fi.FullName))
			{
				id = GuidTools.CreateFromStream(fs);
			}
			return id;
		}

		/// <summary>
		/// Creates a name-based UUID using the algorithm from RFC 4122 §4.3.
		/// </summary>
		/// <param name="fs">Stream</param>
		/// <returns>A UUID derived from hash of the stream.</returns>
		// Token: 0x060001E5 RID: 485 RVA: 0x00008D30 File Offset: 0x00006F30
		public static Guid CreateFromStream(Stream fs)
		{
			if (fs != null && fs.CanSeek && fs.CanRead)
			{
				HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider();
				long pos = fs.Position;
				byte[] data = hashAlgorithm.ComputeHash(fs);
				fs.Position = pos;
				StringBuilder sBuilder = new StringBuilder();
				for (int i = 0; i < data.Length; i++)
				{
					sBuilder.Append(data[i].ToString("x2"));
				}
				string s = sBuilder.ToString();
				return GuidTools.Create(GuidTools.IsoOidNamespace, s);
			}
			return Guid.NewGuid();
		}

		/// <summary>
		/// Is name-based UUID?
		/// </summary>
		/// <param name="id">UUID</param>
		/// <returns></returns>
		// Token: 0x060001E6 RID: 486 RVA: 0x00008DB4 File Offset: 0x00006FB4
		public static bool IsNameBased(Guid id)
		{
			byte version = GuidTools.GetVersion(id);
			return version == 3 || version == 5;
		}

		/// <summary>
		/// Gets version of UUID
		/// </summary>
		/// <param name="id">UUID</param>
		/// <returns></returns>
		// Token: 0x060001E7 RID: 487 RVA: 0x00008DD2 File Offset: 0x00006FD2
		public static byte GetVersion(Guid id)
		{
			return (byte)(id.ToByteArray()[7] >> 4);
		}

		/// <summary>
		/// Creates a name-based UUID using the algorithm from RFC 4122 §4.3.
		/// </summary>
		/// <param name="namespaceId">The ID of the namespace.</param>
		/// <param name="name">The name (within that namespace).</param>
		/// <returns>A UUID derived from the namespace and name.</returns>
		// Token: 0x060001E8 RID: 488 RVA: 0x00008DE0 File Offset: 0x00006FE0
		public static Guid Create(Guid namespaceId, string name)
		{
			return GuidTools.Create(namespaceId, name, 5);
		}

		/// <summary>
		/// Creates a name-based UUID using the algorithm from RFC 4122 §4.3.
		/// </summary>
		/// <param name="namespaceId">The ID of the namespace.</param>
		/// <param name="name">The name (within that namespace).</param>
		/// <param name="version">The version number of the UUID to create; this value must be either
		/// 3 (for MD5 hashing) or 5 (for SHA-1 hashing).</param>
		/// <returns>A UUID derived from the namespace and name.</returns>
		// Token: 0x060001E9 RID: 489 RVA: 0x00008DEC File Offset: 0x00006FEC
		public static Guid Create(Guid namespaceId, string name, int version)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (version != 3 && version != 5)
			{
				throw new ArgumentOutOfRangeException("version", "version must be either 3 or 5.");
			}
			byte[] nameBytes = Encoding.UTF8.GetBytes(name);
			byte[] namespaceBytes = namespaceId.ToByteArray();
			GuidTools.SwapByteOrder(namespaceBytes);
			byte[] hash;
			using (HashAlgorithm algorithm = ((version == 3) ? MD5.Create() : SHA1.Create()))
			{
				algorithm.TransformBlock(namespaceBytes, 0, namespaceBytes.Length, null, 0);
				algorithm.TransformFinalBlock(nameBytes, 0, nameBytes.Length);
				hash = algorithm.Hash;
			}
			byte[] newGuid = new byte[16];
			System.Array.Copy(hash, 0, newGuid, 0, 16);
			newGuid[6] = (byte)((int)(newGuid[6] & 15) | version << 4);
			newGuid[8] = (byte)((int)(newGuid[8] & 63) | 128);
			GuidTools.SwapByteOrder(newGuid);
			return new Guid(newGuid);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00008ECC File Offset: 0x000070CC
		private static void SwapByteOrder(byte[] guid)
		{
			GuidTools.SwapBytes(guid, 0, 3);
			GuidTools.SwapBytes(guid, 1, 2);
			GuidTools.SwapBytes(guid, 4, 5);
			GuidTools.SwapBytes(guid, 6, 7);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00008EF0 File Offset: 0x000070F0
		private static void SwapBytes(byte[] guid, int left, int right)
		{
			byte temp = guid[left];
			guid[left] = guid[right];
			guid[right] = temp;
		}

		/// <summary>
		/// The namespace for fully-qualified domain names (from RFC 4122, Appendix C).
		/// </summary>
		// Token: 0x0400000F RID: 15
		public static readonly Guid DnsNamespace = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8");

		/// <summary>
		/// The namespace for URLs (from RFC 4122, Appendix C).
		/// </summary>
		// Token: 0x04000010 RID: 16
		public static readonly Guid UrlNamespace = new Guid("6ba7b811-9dad-11d1-80b4-00c04fd430c8");

		/// <summary>
		/// The namespace for ISO OIDs (from RFC 4122, Appendix C).
		/// </summary>
		// Token: 0x04000011 RID: 17
		public static readonly Guid IsoOidNamespace = new Guid("6ba7b812-9dad-11d1-80b4-00c04fd430c8");
	}
}

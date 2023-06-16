using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Nuvo.Math.Core.Unc
{
	/// <summary>
	/// Input Id
	/// </summary>
	// Token: 0x02000023 RID: 35
	[Serializable]
	public struct InputId : IXmlSerializable, IEquatable<InputId>
	{
		/// <summary>
		/// Length
		/// </summary>
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00008F3A File Offset: 0x0000713A
		public int Length
		{
			get
			{
				return this._b.Length;
			}
		}

		/// <summary>
		/// Input Id
		/// </summary>
		/// <param name="id">Id</param>
		// Token: 0x060001EE RID: 494 RVA: 0x00008F44 File Offset: 0x00007144
		public InputId(byte[] id)
		{
			this._b = id;
		}

		/// <summary>
		/// Input Id (old version)
		/// </summary>
		/// <param name="b">Byte Array (16, 20, 24 or 28 Bytes)</param>
		/// <param name="l">Length</param>
		// Token: 0x060001EF RID: 495 RVA: 0x00008F50 File Offset: 0x00007150
		public InputId(byte[] b, int l)
		{
			Guid _g;
			uint _i;
			ulong _c;
			if (l == 28)
			{
				byte[] _guid = new byte[16];
				System.Array.Copy(b, _guid, 16);
				_g = new Guid(_guid);
				_i = BitConverter.ToUInt32(b, 16);
				_c = BitConverter.ToUInt64(b, 20);
			}
			else if (l == 24)
			{
				byte[] _guid2 = new byte[16];
				System.Array.Copy(b, _guid2, 16);
				_g = new Guid(_guid2);
				_i = 0U;
				_c = BitConverter.ToUInt64(b, 16);
			}
			else if (l == 20)
			{
				byte[] _guid3 = new byte[16];
				System.Array.Copy(b, _guid3, 16);
				_g = new Guid(_guid3);
				_i = 0U;
				_c = (ulong)BitConverter.ToUInt32(b, 16);
			}
			else
			{
				_g = new Guid(b);
				_i = 0U;
				_c = 0UL;
			}
			this._b = new byte[28];
			byte[] _bg = _g.ToByteArray();
			this._b[0] = _bg[3];
			this._b[1] = _bg[2];
			this._b[2] = _bg[1];
			this._b[3] = _bg[0];
			this._b[4] = _bg[5];
			this._b[5] = _bg[4];
			this._b[6] = _bg[7];
			this._b[7] = _bg[6];
			this._b[8] = _bg[8];
			this._b[9] = _bg[9];
			this._b[10] = _bg[10];
			this._b[11] = _bg[11];
			this._b[12] = _bg[12];
			this._b[13] = _bg[13];
			this._b[14] = _bg[14];
			this._b[15] = _bg[15];
			byte[] _bi = BitConverter.GetBytes(_i);
			this._b[16] = _bi[3];
			this._b[17] = _bi[2];
			this._b[18] = _bi[1];
			this._b[19] = _bi[0];
			byte[] _bc = BitConverter.GetBytes(_c);
			this._b[20] = _bc[7];
			this._b[21] = _bc[6];
			this._b[22] = _bc[5];
			this._b[23] = _bc[4];
			this._b[24] = _bc[3];
			this._b[25] = _bc[2];
			this._b[26] = _bc[1];
			this._b[27] = _bc[0];
		}

		/// <summary>
		/// Input Id
		/// </summary>
		/// <param name="s"></param>
		// Token: 0x060001F0 RID: 496 RVA: 0x0000917B File Offset: 0x0000737B
		public InputId(string s)
		{
			this._b = InputId.HexStringToByteArray(s);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000918C File Offset: 0x0000738C
		private static byte[] HexStringToByteArray(string s)
		{
			string s2 = s.Replace("-", "");
			int i = s2.Length / 2;
			byte[] b = new byte[i];
			for (int j = 0; j < i; j++)
			{
				b[j] = Convert.ToByte(s2.Substring(2 * j, 2), 16);
			}
			return b;
		}

		/// <summary>
		/// Input Id
		/// </summary>
		/// <param name="g"></param>
		// Token: 0x060001F2 RID: 498 RVA: 0x000091DC File Offset: 0x000073DC
		public InputId(Guid g)
		{
			this._b = new byte[16];
			byte[] _bg = g.ToByteArray();
			this._b[0] = _bg[3];
			this._b[1] = _bg[2];
			this._b[2] = _bg[1];
			this._b[3] = _bg[0];
			this._b[4] = _bg[5];
			this._b[5] = _bg[4];
			this._b[6] = _bg[7];
			this._b[7] = _bg[6];
			this._b[8] = _bg[8];
			this._b[9] = _bg[9];
			this._b[10] = _bg[10];
			this._b[11] = _bg[11];
			this._b[12] = _bg[12];
			this._b[13] = _bg[13];
			this._b[14] = _bg[14];
			this._b[15] = _bg[15];
		}

		/// <summary>
		/// Initializes a new instance of the Input Id class.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060001F3 RID: 499 RVA: 0x000092BC File Offset: 0x000074BC
		public static InputId NewInputId()
		{
			return new InputId(Guid.NewGuid());
		}

		/// <summary>
		/// To String
		/// </summary>
		/// <returns></returns>
		// Token: 0x060001F4 RID: 500 RVA: 0x000092C8 File Offset: 0x000074C8
		public override string ToString()
		{
			return BitConverter.ToString(this._b);
		}

		/// <summary>
		/// To Byte Array
		/// </summary>
		/// <returns></returns>
		// Token: 0x060001F5 RID: 501 RVA: 0x000092D5 File Offset: 0x000074D5
		public byte[] ToByteArray()
		{
			return this._b;
		}

		/// <summary>
		/// To Unsigned Integer Array
		/// </summary>
		/// <returns></returns>
		// Token: 0x060001F6 RID: 502 RVA: 0x000092E0 File Offset: 0x000074E0
		public uint[] ToUIntArray()
		{
			uint[] d = new uint[(this._b.Length + 4 - 1) / 4];
			Buffer.BlockCopy(this._b, 0, d, 0, this._b.Length);
			return d;
		}

		/// <summary>
		/// Increment
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		// Token: 0x060001F7 RID: 503 RVA: 0x00009318 File Offset: 0x00007518
		public static InputId operator ++(InputId id)
		{
			int i = id.Length;
			byte[] b = new byte[i];
			System.Array.Copy(id._b, 0, b, 0, i);
			for (int j = i - 1; j >= 0; j--)
			{
				byte[] array = b;
				int num = j;
				array[num] += 1;
				if (b[j] != 0)
				{
					break;
				}
			}
			return new InputId(b);
		}

		/// <summary>
		/// Get Schema
		/// </summary>
		/// <returns></returns>
		// Token: 0x060001F8 RID: 504 RVA: 0x00009369 File Offset: 0x00007569
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Read Xml
		/// </summary>
		/// <param name="reader"></param>
		// Token: 0x060001F9 RID: 505 RVA: 0x0000936C File Offset: 0x0000756C
		public void ReadXml(XmlReader reader)
		{
			string s = reader.ReadString();
			reader.ReadEndElement();
			this._b = InputId.HexStringToByteArray(s);
		}

		/// <summary>
		/// Write Xml
		/// </summary>
		/// <param name="writer"></param>
		// Token: 0x060001FA RID: 506 RVA: 0x00009392 File Offset: 0x00007592
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteString(this.ToString());
		}

		/// <summary>
		/// Equals
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		// Token: 0x060001FB RID: 507 RVA: 0x000093A8 File Offset: 0x000075A8
		public bool Equals(InputId other)
		{
			if (this._b == null || other._b == null)
			{
				return false;
			}
			if (this._b.Length != other._b.Length)
			{
				return false;
			}
			for (int i = 0; i < this._b.Length; i++)
			{
				if (this._b[i] != other._b[i])
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Get Hash Code
		/// </summary>
		/// <returns></returns>
		// Token: 0x060001FC RID: 508 RVA: 0x00009404 File Offset: 0x00007604
		public override int GetHashCode()
		{
			if (this._b != null)
			{
				int p = 16777619;
				int hash = -2128831035;
				for (int i = 0; i < this._b.Length; i++)
				{
					hash = (hash ^ (int)this._b[i]) * p;
				}
				hash += hash << 13;
				hash ^= hash >> 7;
				hash += hash << 3;
				hash ^= hash >> 17;
				return hash + (hash << 5);
			}
			return 0;
		}

		// Token: 0x04000012 RID: 18
		private byte[] _b;
	}
}

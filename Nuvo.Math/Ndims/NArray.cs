using System;
using System.IO;
using System.Xml.Serialization;
using Nuvo.Math.Interface;
using Nuvo.Math.Misc;
using Nuvo.Math.Ndims.Interface;

namespace Nuvo.Math.Ndims
{

	public interface IStorageOperations<D>
	{
		// Define storage operations specific to T
		// For example: InitNd, Get, Set, etc.
	}
	/// <summary>
	/// Generic Array
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	[Serializable]
	public class NArray<T, D> : INArray<T, D>, IConsole, IStorage<T>, IArrayArithmetic<T, D>, IArithmetic<T>, IArrayMath<T, D>, IMath<T> where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Number of dimensions
		/// </summary>
		[XmlElement("NDims")]
		public int ndims { get; set; }

		/// <summary>
		/// Size
		/// </summary>
		[XmlArray("Size")]
		public int[] size { get; set; }

		/// <summary>
		/// Data
		/// </summary>
		[XmlArray("Data")]
		public D[] data { get; set; }

		/// <summary>
		/// Number of elements
		/// </summary>
		public int numel
		{
			get
			{
				return this.data.Length;
			}
		}

		/// <summary>
		/// Returns true if it's a matrix
		/// </summary>
		public bool IsMatrix
		{
			get
			{
				return this.ndims == 2;
			}
		}

		/// <summary>
		/// Returns true if it's a row vector
		/// </summary>
		public bool IsRowVector
		{
			get
			{
				return this.ndims == 1 | (this.ndims == 2 & this.size[0] == 1);
			}
		}

		/// <summary>
		/// Returns true if it's a column vector
		/// </summary>
		public bool IsColVector
		{
			get
			{
				return this.ndims == 1 | (this.ndims == 2 & this.size[0] == this.numel);
			}
		}

		/// <summary>
		/// Returns a vector if it's a vector
		/// </summary>
		public D[] Vector
		{
			get
			{
				if (this.IsRowVector | this.IsColVector)
				{
					return this.data;
				}
				return null;
			}
		}

		/// <summary>
		/// Returns a matrix if it's a matrix
		/// </summary>
		public D[][] Matrix
		{
			get
			{
				if (this.IsMatrix)
				{
					int n = this.size[0];
					int n2 = this.size[1];
					D[][] d = new D[n][];
					for (int i = 0; i < n; i++)
					{
						d[i] = new D[n2];
						for (int i2 = 0; i2 < n2; i2++)
						{
							d[i][i2] = this[i, i2];
						}
					}
					return d;
				}
				return null;
			}
		}

		private int FlatIndex(int index1, int index2)
		{
			return index1 + index2 * this.size[0];
		}

		private int FlatIndex(int index1, int index2, int index3)
		{
			return index1 + index2 * this.size[0] + index3 * this.size[0] * this.size[1];
		}

		private int FlatIndex(int[] indices)
		{
			int flat_index = 0;
			int temp = 1;
			for (int i = 0; i < indices.Length; i++)
			{
				flat_index += indices[i] * temp;
				temp *= this.size[i];
			}
			return flat_index;
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <returns></returns>
		public D this[int index1]
		{
			get
			{
				return this.data[index1];
			}
			set
			{
				this.data[index1] = value;
			}
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <returns></returns>
		public D this[int index1, int index2]
		{
			get
			{
				return this.data[this.FlatIndex(index1, index2)];
			}
			set
			{
				this.data[this.FlatIndex(index1, index2)] = value;
			}
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <returns></returns>
		public D this[int index1, int index2, int index3]
		{
			get
			{
				return this.data[this.FlatIndex(index1, index2, index3)];
			}
			set
			{
				this.data[this.FlatIndex(index1, index2, index3)] = value;
			}
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns></returns>
		public D this[int[] indices]
		{
			get
			{
				return this.data[this.FlatIndex(indices)];
			}
			set
			{
				this.data[this.FlatIndex(indices)] = value;
			}
		}

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <returns>Item</returns>
		public D GetItem1d(int index1)
		{
			return this[index1];
		}

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <returns>Item</returns>
		public D GetItem2d(int index1, int index2)
		{
			return this[index1, index2];
		}

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <returns>Item</returns>
		public D GetItem3d(int index1, int index2, int index3)
		{
			return this[index1, index2, index3];
		}

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Item</returns>
		public D GetItemNd(int[] indices)
		{
			return this[indices];
		}

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		public D[] GetItems1d(int[] indices)
		{
			int i = indices.Length;
			D[] items = new D[i];
			for (int j = 0; j < i; j++)
			{
				items[j] = this.GetItem1d(indices[j]);
			}
			return items;
		}

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		public D[] GetItemsNd(int[][] indices)
		{
			int i = indices.Length;
			D[] items = new D[i];
			for (int j = 0; j < i; j++)
			{
				items[j] = this.GetItemNd(indices[j]);
			}
			return items;
		}

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="value">Item</param>
		public void SetItem1d(int index1, D value)
		{
			this[index1] = value;
		}

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="value">Item</param>
		public void SetItem2d(int index1, int index2, D value)
		{
			this[index1, index2] = value;
		}

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <param name="value">Item</param>
		public void SetItem3d(int index1, int index2, int index3, D value)
		{
			this[index1, index2, index3] = value;
		}

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		public void SetItemNd(int[] indices, D value)
		{
			this[indices] = value;
		}

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Values</param>
		public void SetItems1d(int[] indices, D[] values)
		{
			int i = indices.Length;
			for (int j = 0; j < i; j++)
			{
				this.SetItem1d(indices[j], values[j]);
			}
		}

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Values</param>
		public void SetItemsNd(int[][] indices, D[] values)
		{
			int i = indices.Length;
			for (int j = 0; j < i; j++)
			{
				this.SetItemNd(indices[j], values[j]);
			}
		}

		/// <summary>
		/// Set Same Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Value</param>
		public void SetSameItem1d(int[] indices, D value)
		{
			int i = indices.Length;
			for (int j = 0; j < i; j++)
			{
				this.SetItem1d(indices[j], value);
			}
		}

		/// <summary>
		/// Set Same Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Value</param>
		public void SetSameItemNd(int[][] indices, D value)
		{
			int i = indices.Length;
			for (int j = 0; j < i; j++)
			{
				this.SetItemNd(indices[j], value);
			}
		}

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		public void Init1d(int n1)
		{
			this.InitNd(new int[]
			{
				n1
			});
		}

		/// <summary>
		/// Initializes a 2D-Array (Matrix)
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		public void Init2d(int n1, int n2)
		{
			this.InitNd(new int[]
			{
				n1,
				n2
			});
		}

		/// <summary>
		/// Initializes a 3D-Array
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		public void Init3d(int n1, int n2, int n3)
		{
			this.InitNd(new int[]
			{
				n1,
				n2,
				n3
			});
		}

		/// <summary>
		/// Initializes a ND-Array
		/// </summary>
		/// <param name="size">size</param>
		public void InitNd(int[] size)
		{
			int i = 1;
			foreach (int nx in size)
			{
				i *= nx;
			}
			this.ndims = size.Length;
			this.size = size;
			this.data = new D[i];
		}

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// and creates a copy of the data
		/// </summary>
		/// <param name="data">Data</param>
		public void Init1dData(D[] data)
		{
			this.Init1dData(data, true);
		}

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="copy">Copy Data</param>
		public void Init1dData(D[] data, bool copy)
		{
			this.ndims = 1;
			this.size = new int[]
			{
				data.Length
			};
			if (copy)
			{
				this.data = new D[data.Length];
				data.CopyTo(this.data, 0);
				return;
			}
			this.data = data;
		}

		public void Init2dData(D[,] data)
		{
			int n = data.GetLength(0);
			int n2 = data.GetLength(1);
			this.InitNd(new int[]
			{
				n,
				n2
			});
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					this[i, i2] = data[i, i2];
				}
			}
		}

		/// <summary>
		/// Initializes a 2D-Array (Matrix)
		/// </summary>
		/// <param name="data">Data</param>
		public void Init2dData(D[][] data)
		{
			int n = data.Length;
			int n2 = 0;
			if (n > 0)
			{
				n2 = data[0].Length;
			}
			this.InitNd(new int[]
			{
				n,
				n2
			});
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					this[i, i2] = data[i][i2];
				}
			}
		}

		public void Init3dData(D[,,] data)
		{
			int n = data.GetLength(0);
			int n2 = data.GetLength(1);
			int n3 = data.GetLength(3);
			this.InitNd(new int[]
			{
				n,
				n2,
				n3
			});
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					for (int i3 = 0; i3 < n3; i3++)
					{
						this[i, i2, i3] = data[i, i2, i3];
					}
				}
			}
		}

		/// <summary>
		/// Initializes a 3D-Array
		/// </summary>
		/// <param name="data">Data</param>
		public void Init3dData(D[][][] data)
		{
			int n = data.Length;
			int n2 = 0;
			int n3 = 0;
			if (n > 0)
			{
				n2 = data[0].Length;
			}
			if (n2 > 0)
			{
				n3 = data[0][0].Length;
			}
			this.InitNd(new int[]
			{
				n,
				n2,
				n3
			});
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					for (int i3 = 0; i3 < n3; i3++)
					{
						this[i, i2, i3] = data[i][i2][i3];
					}
				}
			}
		}

		/// <summary>
		/// Initializes a Array.
		/// </summary>
		/// <param name="value">Value</param>
		public void InitDbl(double[] value)
		{
			int i = value.Length;
			this.Init1d(i);
			for (int j = 0; j < i; j++)
			{
				this.data[j] = Activator.CreateInstance<D>();
				this.data[j].InitDbl(value[j]);
			}
		}

		/// <summary>
		/// Initializes a 1D-Array (Vector) with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		public void Zeros1d(int n1)
		{
			this.ZerosNd(new int[]
			{
				n1
			});
		}

		/// <summary>
		/// Initializes a 2D-Array (Matrix) with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		public void Zeros2d(int n1, int n2)
		{
			this.ZerosNd(new int[]
			{
				n1,
				n2
			});
		}

		/// <summary>
		/// Initializes a 3D-Array with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		public void Zeros3d(int n1, int n2, int n3)
		{
			this.ZerosNd(new int[]
			{
				n1,
				n2,
				n3
			});
		}

		/// <summary>
		/// Initializes a ND-Array with all values = 0
		/// </summary>
		/// <param name="size">Size</param>
		public void ZerosNd(int[] size)
		{
			this.InitNd(size);
			D d = Activator.CreateInstance<D>();
			D zero = d.Zero;
			for (int i = 0; i < this.numel; i++)
			{
				this.data[i] = zero;
			}
		}

		/// <summary>
		/// Initializes a 1D-Array (Vector) with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		public void Ones1d(int n1)
		{
			this.OnesNd(new int[]
			{
				n1
			});
		}

		/// <summary>
		/// Initializes a 2D-Array (Matrix) with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		public void Ones2d(int n1, int n2)
		{
			this.OnesNd(new int[]
			{
				n1,
				n2
			});
		}

		/// <summary>
		/// Initializes a 3D-Array with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		public void Ones3d(int n1, int n2, int n3)
		{
			this.OnesNd(new int[]
			{
				n1,
				n2,
				n3
			});
		}

		/// <summary>
		/// Initializes a ND-Array with all values = 1
		/// </summary>
		/// <param name="size">Size</param>
		public void OnesNd(int[] size)
		{
			this.InitNd(size);
			D d = Activator.CreateInstance<D>();
			D one = d.One;
			for (int i = 0; i < this.numel; i++)
			{
				this.data[i] = one;
			}
		}

		/// <summary>
		/// Reshapes the array
		/// </summary>
		/// <param name="size">Size</param>
		public void Reshape(int[] size)
		{
			int i = 1;
			foreach (int nx in size)
			{
				i *= nx;
			}
			if (this.numel != i)
			{
				throw new Exception("The number of elements must not change");
			}
			this.ndims = size.Length;
			this.size = size;
		}

		/// <summary>
		/// Returns a copy of the array
		/// </summary>
		/// <returns></returns>
		public T Copy()
		{
			T b = Activator.CreateInstance<T>();
			b.InitNd(this.size);
			this.data.CopyTo(b.data, 0);
			return b;
		}

		/// <summary>
		/// Initializes a Identity 2D-Array (Matrix)
		/// </summary>
		/// <param name="n">Number of Rows and Cols</param>
		public void Identity(int n)
		{
			this.Zeros2d(n, n);
			D d = Activator.CreateInstance<D>();
			D one = d.One;
			for (int i = 0; i < n; i++)
			{
				this[i, i] = one;
			}
		}

		/// <summary>
		/// Interchange Rows in 2D-Array (Matrix)
		/// </summary>
		/// <param name="index_1">Row Index 1</param>
		/// <param name="index_2">Row Index 2</param>
		public void InterchangeRows(int index_1, int index_2)
		{
			if (!this.IsMatrix)
			{
				throw new Exception("Array must be a matrix");
			}
			int n_col = this.size[1];
			for (int i = 0; i < n_col; i++)
			{
				D temp = this[index_1, i];
				this[index_1, i] = this[index_2, i];
				this[index_2, i] = temp;
			}
		}

		/// <summary>
		/// Transpose 2D-Array (Matrix)
		/// </summary>
		/// <returns></returns>
		public T Transpose()
		{
			if (this.ndims == 1)
			{
				this.Reshape(new int[]
				{
					this.numel,
					1
				});
			}
			if (!this.IsMatrix)
			{
				throw new Exception("Array must be a matrix");
			}
			int n = this.size[0];
			int n2 = this.size[1];
			T b = Activator.CreateInstance<T>();
			b.Init2d(n2, n);
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					b[i2, i] = this[i, i2];
				}
			}
			return b;
		}

		/// <summary>
		/// Concatenate 2D-Arrays (Matrixes) horizontally
		/// </summary>
		/// <param name="b">The second matrix</param>
		/// <returns></returns>
		public T HorzCat(T b)
		{
			if (!this.IsMatrix)
			{
				throw new Exception("Array must be a matrix");
			}
			if (!b.IsMatrix)
			{
				throw new Exception("Second array must be a matrix");
			}
			int n = this.size[0];
			int n2 = this.size[1];
			int n3 = b.size[0];
			int n4 = b.size[1];
			if (n != n3)
			{
				throw new Exception("Matrix dimensions must agree");
			}
			T c = Activator.CreateInstance<T>();
			c.Init2d(n, n2 + n4);
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					c[i, i2] = this[i, i2];
				}
				for (int i3 = 0; i3 < n4; i3++)
				{
					c[i, n2 + i3] = b[i, i3];
				}
			}
			return c;
		}

		/// <summary>
		/// Concatenate 2D-Arrays (Matrixes) vertically
		/// </summary>
		/// <param name="b">The second matrix</param>
		/// <returns></returns>
		public T VertCat(T b)
		{
			if (!this.IsMatrix)
			{
				throw new Exception("Array must be a matrix");
			}
			if (!b.IsMatrix)
			{
				throw new Exception("Second array must be a matrix");
			}
			int n = this.size[0];
			int n2 = this.size[1];
			int n3 = b.size[0];
			int n4 = b.size[1];
			if (n2 != n4)
			{
				throw new Exception("Matrix dimensions must agree");
			}
			T c = Activator.CreateInstance<T>();
			c.Init2d(n + n3, n2);
			for (int i = 0; i < n; i++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					c[i, i2] = this[i, i2];
				}
			}
			for (int i3 = 0; i3 < n3; i3++)
			{
				for (int i4 = 0; i4 < n2; i4++)
				{
					c[n + i3, i4] = b[i3, i4];
				}
			}
			return c;
		}

		/// <summary>
		/// Number of bytes allocated for the Object.
		/// </summary>
		public int memsize
		{
			get
			{
				int s = 0;
				for (int i = 0; i < this.numel; i++)
				{
					int num = s;
					D d = this[i];
					s = num + d.memsize;
				}
				return s + this.size.Length * 4;
			}
		}

		/// <summary>
		/// Debug an Object
		/// </summary>
		public void Debug()
		{
			Nuvo.Math.Misc.Console.Debug(this);
		}

		/// <summary>
		/// Write object data to Binary Writer.
		/// </summary>
		/// <param name="writer">Binary Writer</param>
		public void BinaryWriteDataTo(BinaryWriter writer)
		{
			int version = 1;
			writer.Write(version);
			int n = this.ndims;
			writer.Write(n);
			for (int i = 0; i < n; i++)
			{
				writer.Write(this.size[i]);
			}
			int n2 = this.numel;
			writer.Write(n2);
			for (int j = 0; j < n2; j++)
			{
				this.data[j].BinaryWriteDataTo(writer);
			}
		}

		/// <summary>
		/// Set object data from Binary Reader.
		/// </summary>
		/// <param name="reader">Binary Reader</param>
		public void BinarySetDataFrom(BinaryReader reader)
		{
			reader.ReadInt32();
			int n = reader.ReadInt32();
			this.ndims = n;
			this.size = new int[n];
			for (int i = 0; i < n; i++)
			{
				this.size[i] = reader.ReadInt32();
			}
			int n2 = reader.ReadInt32();
			this.data = new D[n2];
			for (int j = 0; j < n2; j++)
			{
				this.data[j] = Activator.CreateInstance<D>();
				this.data[j].BinarySetDataFrom(reader);
			}
		}

		/// <summary>
		/// Binary Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		public void BinarySerialize(string filepath)
		{
			Storage.BinarySerialize(this, filepath);
		}

		/// <summary>
		/// Binary Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		public T BinaryDeserialize(string filepath)
		{
			return Storage.BinaryDeserialize<T>(filepath);
		}

		/// <summary>
		/// Binary Serialize an Object to a byte array.
		/// </summary>
		/// <returns>Binary Data</returns>
		public byte[] BinarySerializeToByteArray()
		{
			return Storage.BinarySerializeToByteArray(this);
		}

		/// <summary>
		/// Binary Deserialize an Object from a byte array.
		/// </summary>
		/// <param name="data">Binary Data</param>
		/// <returns>Object</returns>
		public T BinaryDeserializeFromByteArray(byte[] data)
		{
			return Storage.BinaryDeserializeFromByteArray<T>(data);
		}

		/// <summary>
		/// Xml Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		public void XmlSerialize(string filepath)
		{
			Storage.XmlSerialize(this, filepath);
		}

		/// <summary>
		/// Xml Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		public T XmlDeserialize(string filepath)
		{
			return Storage.XmlDeserialize<T>(filepath);
		}

		/// <summary>
		/// Xml Serialize an Object to String.
		/// </summary>
		/// <returns>XML String</returns>
		public string XmlSerializeToString()
		{
			return Storage.XmlSerializeToString(this);
		}

		/// <summary>
		/// Xml Deserialize an Object from String.
		/// </summary>
		/// <param name="xml_string">Xml String</param>
		/// <returns>Object</returns>
		public T XmlDeserializeFromString(string xml_string)
		{
			return Storage.XmlDeserializeFromString<T>(xml_string);
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T operator +(NArray<T, D> a)
		{
			T result = Activator.CreateInstance<T>();
			result.data = a.data;
			result.ndims = a.ndims;
			result.size = a.size;
			return result;
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public static T operator -(NArray<T, D> a)
		{
			return a.Negative();
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator +(NArray<T, D> a, T b)
		{
			return a.Add(b);
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator -(NArray<T, D> a, T b)
		{
			return a.Subtract(b);
		}

		/// <summary>
		/// Overloading '*' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator *(NArray<T, D> a, T b)
		{
			return a.Multiply(b);
		}

		/// <summary>
		/// Overloading '/' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator /(NArray<T, D> a, T b)
		{
			return a.Divide(b);
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator +(NArray<T, D> a, D b)
		{
			return a.LAdd(b);
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator -(NArray<T, D> a, D b)
		{
			return a.LSubtract(b);
		}

		/// <summary>
		/// Overloading '*' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator *(NArray<T, D> a, D b)
		{
			return a.LMultiply(b);
		}

		/// <summary>
		/// Overloading '/' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator /(NArray<T, D> a, D b)
		{
			return a.LDivide(b);
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator +(D a, NArray<T, D> b)
		{
			return b.RAdd(a);
		}

		/// <summary>
		/// Overloading '-' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator -(D a, NArray<T, D> b)
		{
			return b.RSubtract(a);
		}

		/// <summary>
		/// Overloading '*' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator *(D a, NArray<T, D> b)
		{
			return b.RMultiply(a);
		}

		/// <summary>
		/// Overloading '/' operator
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static T operator /(D a, NArray<T, D> b)
		{
			return b.RDivide(a);
		}

		internal T ElementUnOp(UnaryOperation<D> op)
		{
			int n = this.numel;
			T b = Activator.CreateInstance<T>();
			b.InitNd(this.size);
			for (int i = 0; i < n; i++)
			{
				b[i] = op(this[i]);
			}
			return b;
		}

		internal T ElementBinOp(BinaryOperation<D> op, T b)
		{
			int d = this.ndims;
			if (d != b.ndims)
			{
				throw new Exception("Array dimensions must agree");
			}
			for (int i = 0; i < d; i++)
			{
				if (this.size[i] != b.size[i])
				{
					throw new Exception("Array dimensions must agree");
				}
			}
			int n = this.numel;
			T c = Activator.CreateInstance<T>();
			c.InitNd(this.size);
			for (int j = 0; j < n; j++)
			{
				c[j] = op(this[j], b[j]);
			}
			return c;
		}

		internal T LElementBinOp(BinaryOperation<D> op, D b)
		{
			int n = this.numel;
			T c = Activator.CreateInstance<T>();
			c.InitNd(this.size);
			for (int i = 0; i < n; i++)
			{
				c[i] = op(this[i], b);
			}
			return c;
		}

		internal T LElementBinOp2(BinaryOperation2<D> op, int b)
		{
			int n = this.numel;
			T c = Activator.CreateInstance<T>();
			c.InitNd(this.size);
			for (int i = 0; i < n; i++)
			{
				c[i] = op(this[i], b);
			}
			return c;
		}

		internal T RElementBinOp(BinaryOperation<D> op, D a)
		{
			int n = this.numel;
			T c = Activator.CreateInstance<T>();
			c.InitNd(this.size);
			for (int i = 0; i < n; i++)
			{
				c[i] = op(a, this[i]);
			}
			return c;
		}

		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		public T LAdd(D b)
		{
			return LElementBinOp(Math.Add, b);
		}
		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		public T LSubtract(D b)
		{
			return LElementBinOp(Math.Subtract, b);
		}

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		public T LMultiply(D b)
		{
			return LElementBinOp(Math.Multiply, b);
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		public T LDivide(D b)
		{
			return LElementBinOp(Math.Divide, b);
		}

		/// <summary>
		/// Returns the sum of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the sum</returns>
		public T RAdd(D a)
		{
			return RElementBinOp(Math.Add, a);
		}

		/// <summary>
		/// Returns the difference of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the difference</returns>
		public T RSubtract(D a)
		{
			return RElementBinOp(Math.Subtract, a);
		}

		/// <summary>
		/// Returns the product of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the product</returns>
		public T RMultiply(D a)
		{
			return RElementBinOp(Math.Multiply, a);
		}

		/// <summary>
		/// Returns the quotient of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the quotient</returns>
		public T RDivide(D a)
		{
			return RElementBinOp(Math.Divide, a);
		}

		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		public T Add(T b)
		{
			return ElementBinOp(Math.Add, b);
		}

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		public T Subtract(T b)
		{
			return ElementBinOp(Math.Subtract, b);
		}

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		public T Negative()
		{
			return ElementUnOp(Math.Negative);
		}
		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		public T Multiply(T b)
		{
			return ElementBinOp(Math.Multiply, b);
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		public T Divide(T b)
		{
			return ElementBinOp(Math.Divide, b);
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		public T Exp()
		{
			return ElementUnOp(Math.Exp);
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public T Log()
		{
			return ElementUnOp(Math.Log);
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		public T Log(T newBase)
		{
			return ElementBinOp(Math.Log, newBase);
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		public T Log10()
		{
			return ElementUnOp(Math.Log10);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public T Pow(T b)
		{
			return ElementBinOp(Math.Pow, b);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public T Pow(int b)
		{
			return LElementBinOp2(Math.Pow, b);
		}

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		public T Sqrt()
		{
			return ElementUnOp(Math.Sqrt);
		}

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public T Sin()
		{
			return ElementUnOp(Math.Sin);
		}

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public T Cos()
		{
			return ElementUnOp(Math.Cos);
		}

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public T Tan()
		{
			return ElementUnOp(Math.Tan);
		}

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public T Asin()
		{
			return ElementUnOp(Math.Asin);
		}

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public T Acos()
		{
			return ElementUnOp(Math.Acos);
		}

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public T Atan()
		{
			return ElementUnOp(Math.Atan);
		}

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public T Sinh()
		{
			return ElementUnOp(Math.Sinh);
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		public T Cosh()
		{
			return ElementUnOp(Math.Cosh);
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		public T Tanh()
		{
			return this.ElementUnOp(Math.Tanh);
		}

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		public T Asinh()
		{
			return this.ElementUnOp(Math.Asinh);
		}

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		public T Acosh()
		{
			return this.ElementUnOp(Math.Acosh);
		}

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		public T Atanh()
		{
			return this.ElementUnOp(Math.Atanh);
		}

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		public T Conj()
		{
			return ElementUnOp(Math.Conj);
		}

		/// <summary>
		/// Returns the logarithm of a specified number (object) in a specified base (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		public T LLog(D b)
		{
			return LElementBinOp(Math.Log, b);
		}

		/// <summary>
		/// Returns the logarithm of a specified number (<paramref name="a" />) in a specified base (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		public T RLog(D a)
		{
			return RElementBinOp(Math.Log, a);
		}

		/// <summary>
		/// Returns a specified number (object) raised to the specified power (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		public T LPow(D b)
		{
			return LElementBinOp(Math.Pow, b);
		}

		/// <summary>
		/// Returns a specified number (<paramref name="a" />) raised to the specified power (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		public T RPow(D a)
		{
			return RElementBinOp(Math.Pow, a);
		}
	}
}

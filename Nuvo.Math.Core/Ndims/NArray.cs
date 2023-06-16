using System;
using System.IO;
using System.Xml.Serialization;
using Nuvo.Math.Core.Interface;
using Nuvo.Math.Core.Misc;
using Nuvo.Math.Core.Ndims.Interface;

namespace Nuvo.Math.Core.Ndims
{
	/// <summary>
	/// Generic Array
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	// Token: 0x02000038 RID: 56
	[Serializable]
	public class NArray<T, D> : INArray<T, D>, IConsole, IStorage<T>, IArrayArithmetic<T, D>, IArithmetic<T>, IArrayMath<D, T>, IMath<T> where T : INArray<T, D>, new() where D : INumber<D>, new()
	{
		/// <summary>
		/// Number of dimensions
		/// </summary>
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000BD92 File Offset: 0x00009F92
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000BD9A File Offset: 0x00009F9A
		[XmlElement("NDims")]
		public int ndims { get; set; }

		/// <summary>
		/// Size
		/// </summary>
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000BDA3 File Offset: 0x00009FA3
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0000BDAB File Offset: 0x00009FAB
		[XmlArray("Size")]
		public int[] size { get; set; }

		/// <summary>
		/// Data
		/// </summary>
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0000BDB4 File Offset: 0x00009FB4
		// (set) Token: 0x06000266 RID: 614 RVA: 0x0000BDBC File Offset: 0x00009FBC
		[XmlArray("Data")]
		public D[] data { get; set; }

		/// <summary>
		/// Number of elements
		/// </summary>
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000BDC5 File Offset: 0x00009FC5
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
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0000BDCF File Offset: 0x00009FCF
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
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000BDDA File Offset: 0x00009FDA
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
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600026A RID: 618 RVA: 0x0000BDFB File Offset: 0x00009FFB
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
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000BE21 File Offset: 0x0000A021
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
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000BE3C File Offset: 0x0000A03C
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

		// Token: 0x0600026D RID: 621 RVA: 0x0000BEA5 File Offset: 0x0000A0A5
		private int FlatIndex(int index1, int index2)
		{
			return index1 + index2 * this.size[0];
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000BEB3 File Offset: 0x0000A0B3
		private int FlatIndex(int index1, int index2, int index3)
		{
			return index1 + index2 * this.size[0] + index3 * this.size[0] * this.size[1];
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000BED8 File Offset: 0x0000A0D8
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
		// Token: 0x17000027 RID: 39
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
		// Token: 0x17000028 RID: 40
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
		// Token: 0x17000029 RID: 41
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
		// Token: 0x1700002A RID: 42
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
		// Token: 0x06000278 RID: 632 RVA: 0x0000BFAA File Offset: 0x0000A1AA
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
		// Token: 0x06000279 RID: 633 RVA: 0x0000BFB3 File Offset: 0x0000A1B3
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
		// Token: 0x0600027A RID: 634 RVA: 0x0000BFBD File Offset: 0x0000A1BD
		public D GetItem3d(int index1, int index2, int index3)
		{
			return this[index1, index2, index3];
		}

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Item</returns>
		// Token: 0x0600027B RID: 635 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		public D GetItemNd(int[] indices)
		{
			return this[indices];
		}

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		// Token: 0x0600027C RID: 636 RVA: 0x0000BFD4 File Offset: 0x0000A1D4
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
		// Token: 0x0600027D RID: 637 RVA: 0x0000C00C File Offset: 0x0000A20C
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
		// Token: 0x0600027E RID: 638 RVA: 0x0000C041 File Offset: 0x0000A241
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
		// Token: 0x0600027F RID: 639 RVA: 0x0000C04B File Offset: 0x0000A24B
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
		// Token: 0x06000280 RID: 640 RVA: 0x0000C056 File Offset: 0x0000A256
		public void SetItem3d(int index1, int index2, int index3, D value)
		{
			this[index1, index2, index3] = value;
		}

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		// Token: 0x06000281 RID: 641 RVA: 0x0000C063 File Offset: 0x0000A263
		public void SetItemNd(int[] indices, D value)
		{
			this[indices] = value;
		}

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Values</param>
		// Token: 0x06000282 RID: 642 RVA: 0x0000C070 File Offset: 0x0000A270
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
		// Token: 0x06000283 RID: 643 RVA: 0x0000C0A0 File Offset: 0x0000A2A0
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
		// Token: 0x06000284 RID: 644 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
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
		// Token: 0x06000285 RID: 645 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
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
		// Token: 0x06000286 RID: 646 RVA: 0x0000C11F File Offset: 0x0000A31F
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
		// Token: 0x06000287 RID: 647 RVA: 0x0000C131 File Offset: 0x0000A331
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
		// Token: 0x06000288 RID: 648 RVA: 0x0000C147 File Offset: 0x0000A347
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
		// Token: 0x06000289 RID: 649 RVA: 0x0000C164 File Offset: 0x0000A364
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
		// Token: 0x0600028A RID: 650 RVA: 0x0000C1A7 File Offset: 0x0000A3A7
		public void Init1dData(D[] data)
		{
			this.Init1dData(data, true);
		}

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="copy">Copy Data</param>
		// Token: 0x0600028B RID: 651 RVA: 0x0000C1B4 File Offset: 0x0000A3B4
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

		// Token: 0x0600028C RID: 652 RVA: 0x0000C200 File Offset: 0x0000A400
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
		// Token: 0x0600028D RID: 653 RVA: 0x0000C25C File Offset: 0x0000A45C
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

		// Token: 0x0600028E RID: 654 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
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
		// Token: 0x0600028F RID: 655 RVA: 0x0000C338 File Offset: 0x0000A538
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
		// Token: 0x06000290 RID: 656 RVA: 0x0000C3C0 File Offset: 0x0000A5C0
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
		// Token: 0x06000291 RID: 657 RVA: 0x0000C411 File Offset: 0x0000A611
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
		// Token: 0x06000292 RID: 658 RVA: 0x0000C423 File Offset: 0x0000A623
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
		// Token: 0x06000293 RID: 659 RVA: 0x0000C439 File Offset: 0x0000A639
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
		// Token: 0x06000294 RID: 660 RVA: 0x0000C454 File Offset: 0x0000A654
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
		// Token: 0x06000295 RID: 661 RVA: 0x0000C49A File Offset: 0x0000A69A
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
		// Token: 0x06000296 RID: 662 RVA: 0x0000C4AC File Offset: 0x0000A6AC
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
		// Token: 0x06000297 RID: 663 RVA: 0x0000C4C2 File Offset: 0x0000A6C2
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
		// Token: 0x06000298 RID: 664 RVA: 0x0000C4DC File Offset: 0x0000A6DC
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
		// Token: 0x06000299 RID: 665 RVA: 0x0000C524 File Offset: 0x0000A724
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
		// Token: 0x0600029A RID: 666 RVA: 0x0000C570 File Offset: 0x0000A770
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
		// Token: 0x0600029B RID: 667 RVA: 0x0000C5B0 File Offset: 0x0000A7B0
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
		// Token: 0x0600029C RID: 668 RVA: 0x0000C5F0 File Offset: 0x0000A7F0
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
		// Token: 0x0600029D RID: 669 RVA: 0x0000C648 File Offset: 0x0000A848
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
		// Token: 0x0600029E RID: 670 RVA: 0x0000C6E8 File Offset: 0x0000A8E8
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
		// Token: 0x0600029F RID: 671 RVA: 0x0000C7EC File Offset: 0x0000A9EC
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
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000C900 File Offset: 0x0000AB00
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
		// Token: 0x060002A1 RID: 673 RVA: 0x0000C946 File Offset: 0x0000AB46
		public void Debug()
		{
			Nuvo.Math.Core.Misc.Console.Debug(this);
		}

		/// <summary>
		/// Write object data to Binary Writer.
		/// </summary>
		/// <param name="writer">Binary Writer</param>
		// Token: 0x060002A2 RID: 674 RVA: 0x0000C950 File Offset: 0x0000AB50
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
		// Token: 0x060002A3 RID: 675 RVA: 0x0000C9C8 File Offset: 0x0000ABC8
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
		// Token: 0x060002A4 RID: 676 RVA: 0x0000CA5A File Offset: 0x0000AC5A
		public void BinarySerialize(string filepath)
		{
			Storage.BinarySerialize(this, filepath);
		}

		/// <summary>
		/// Binary Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		// Token: 0x060002A5 RID: 677 RVA: 0x0000CA63 File Offset: 0x0000AC63
		public T BinaryDeserialize(string filepath)
		{
			return Storage.BinaryDeserialize<T>(filepath);
		}

		/// <summary>
		/// Binary Serialize an Object to a byte array.
		/// </summary>
		/// <returns>Binary Data</returns>
		// Token: 0x060002A6 RID: 678 RVA: 0x0000CA6B File Offset: 0x0000AC6B
		public byte[] BinarySerializeToByteArray()
		{
			return Storage.BinarySerializeToByteArray(this);
		}

		/// <summary>
		/// Binary Deserialize an Object from a byte array.
		/// </summary>
		/// <param name="data">Binary Data</param>
		/// <returns>Object</returns>
		// Token: 0x060002A7 RID: 679 RVA: 0x0000CA73 File Offset: 0x0000AC73
		public T BinaryDeserializeFromByteArray(byte[] data)
		{
			return Storage.BinaryDeserializeFromByteArray<T>(data);
		}

		/// <summary>
		/// Xml Serialize an Object to File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		// Token: 0x060002A8 RID: 680 RVA: 0x0000CA7B File Offset: 0x0000AC7B
		public void XmlSerialize(string filepath)
		{
			Storage.XmlSerialize(this, filepath);
		}

		/// <summary>
		/// Xml Deserialize an Object from File.
		/// </summary>
		/// <param name="filepath">File Path</param>
		/// <returns>Object</returns>
		// Token: 0x060002A9 RID: 681 RVA: 0x0000CA84 File Offset: 0x0000AC84
		public T XmlDeserialize(string filepath)
		{
			return Storage.XmlDeserialize<T>(filepath);
		}

		/// <summary>
		/// Xml Serialize an Object to String.
		/// </summary>
		/// <returns>XML String</returns>
		// Token: 0x060002AA RID: 682 RVA: 0x0000CA8C File Offset: 0x0000AC8C
		public string XmlSerializeToString()
		{
			return Storage.XmlSerializeToString(this);
		}

		/// <summary>
		/// Xml Deserialize an Object from String.
		/// </summary>
		/// <param name="xml_string">Xml String</param>
		/// <returns>Object</returns>
		// Token: 0x060002AB RID: 683 RVA: 0x0000CA94 File Offset: 0x0000AC94
		public T XmlDeserializeFromString(string xml_string)
		{
			return Storage.XmlDeserializeFromString<T>(xml_string);
		}

		/// <summary>
		/// Overloading '+' operator
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		// Token: 0x060002AC RID: 684 RVA: 0x0000CA9C File Offset: 0x0000AC9C
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
		// Token: 0x060002AD RID: 685 RVA: 0x0000CAE9 File Offset: 0x0000ACE9
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
		// Token: 0x060002AE RID: 686 RVA: 0x0000CAF1 File Offset: 0x0000ACF1
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
		// Token: 0x060002AF RID: 687 RVA: 0x0000CAFA File Offset: 0x0000ACFA
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
		// Token: 0x060002B0 RID: 688 RVA: 0x0000CB03 File Offset: 0x0000AD03
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
		// Token: 0x060002B1 RID: 689 RVA: 0x0000CB0C File Offset: 0x0000AD0C
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
		// Token: 0x060002B2 RID: 690 RVA: 0x0000CB15 File Offset: 0x0000AD15
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
		// Token: 0x060002B3 RID: 691 RVA: 0x0000CB1E File Offset: 0x0000AD1E
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
		// Token: 0x060002B4 RID: 692 RVA: 0x0000CB27 File Offset: 0x0000AD27
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
		// Token: 0x060002B5 RID: 693 RVA: 0x0000CB30 File Offset: 0x0000AD30
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
		// Token: 0x060002B6 RID: 694 RVA: 0x0000CB39 File Offset: 0x0000AD39
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
		// Token: 0x060002B7 RID: 695 RVA: 0x0000CB42 File Offset: 0x0000AD42
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
		// Token: 0x060002B8 RID: 696 RVA: 0x0000CB4B File Offset: 0x0000AD4B
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
		// Token: 0x060002B9 RID: 697 RVA: 0x0000CB54 File Offset: 0x0000AD54
		public static T operator /(D a, NArray<T, D> b)
		{
			return b.RDivide(a);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000CB60 File Offset: 0x0000AD60
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

		// Token: 0x060002BB RID: 699 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
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

		// Token: 0x060002BC RID: 700 RVA: 0x0000CC74 File Offset: 0x0000AE74
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

		// Token: 0x060002BD RID: 701 RVA: 0x0000CCCC File Offset: 0x0000AECC
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

		// Token: 0x060002BE RID: 702 RVA: 0x0000CD24 File Offset: 0x0000AF24
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
		// Token: 0x060002BF RID: 703 RVA: 0x0000CD7A File Offset: 0x0000AF7A
		public T LAdd(D b)
		{
			return this.LElementBinOp(new BinaryOperation<D>(Math.Add<D>), b);
		}

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		// Token: 0x060002C0 RID: 704 RVA: 0x0000CD8F File Offset: 0x0000AF8F
		public T LSubtract(D b)
		{
			return this.LElementBinOp(new BinaryOperation<D>(Math.Subtract<D>), b);
		}

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		// Token: 0x060002C1 RID: 705 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		public T LMultiply(D b)
		{
			return this.LElementBinOp(new BinaryOperation<D>(Math.Multiply<D>), b);
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x060002C2 RID: 706 RVA: 0x0000CDB9 File Offset: 0x0000AFB9
		public T LDivide(D b)
		{
			return this.LElementBinOp(new BinaryOperation<D>(Math.Divide<D>), b);
		}

		/// <summary>
		/// Returns the sum of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the sum</returns>
		// Token: 0x060002C3 RID: 707 RVA: 0x0000CDCE File Offset: 0x0000AFCE
		public T RAdd(D a)
		{
			return this.RElementBinOp(new BinaryOperation<D>(Math.Add<D>), a);
		}

		/// <summary>
		/// Returns the difference of <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the difference</returns>
		// Token: 0x060002C4 RID: 708 RVA: 0x0000CDE3 File Offset: 0x0000AFE3
		public T RSubtract(D a)
		{
			return this.RElementBinOp(new BinaryOperation<D>(Math.Subtract<D>), a);
		}

		/// <summary>
		/// Returns the product of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the product</returns>
		// Token: 0x060002C5 RID: 709 RVA: 0x0000CDF8 File Offset: 0x0000AFF8
		public T RMultiply(D a)
		{
			return this.RElementBinOp(new BinaryOperation<D>(Math.Multiply<D>), a);
		}

		/// <summary>
		/// Returns the quotient of the <paramref name="a" /> and the object.
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x060002C6 RID: 710 RVA: 0x0000CE0D File Offset: 0x0000B00D
		public T RDivide(D a)
		{
			return this.RElementBinOp(new BinaryOperation<D>(Math.Divide<D>), a);
		}

		/// <summary>
		/// Returns the sum of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the sum</returns>
		// Token: 0x060002C7 RID: 711 RVA: 0x0000CE22 File Offset: 0x0000B022
		public T Add(T b)
		{
			return this.ElementBinOp(new BinaryOperation<D>(Math.Add<D>), b);
		}

		/// <summary>
		/// Returns the difference of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the difference</returns>
		// Token: 0x060002C8 RID: 712 RVA: 0x0000CE37 File Offset: 0x0000B037
		public T Subtract(T b)
		{
			return this.ElementBinOp(new BinaryOperation<D>(Math.Subtract<D>), b);
		}

		/// <summary>
		/// Returns the negative of the object.
		/// </summary>
		/// <returns>The negative</returns>
		// Token: 0x060002C9 RID: 713 RVA: 0x0000CE4C File Offset: 0x0000B04C
		public T Negative()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Negative<D>));
		}

		/// <summary>
		/// Returns the product of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the product</returns>
		// Token: 0x060002CA RID: 714 RVA: 0x0000CE60 File Offset: 0x0000B060
		public T Multiply(T b)
		{
			return this.ElementBinOp(new BinaryOperation<D>(Math.Multiply<D>), b);
		}

		/// <summary>
		/// Returns the quotient of the object and <paramref name="b" />.
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns>the quotient</returns>
		// Token: 0x060002CB RID: 715 RVA: 0x0000CE75 File Offset: 0x0000B075
		public T Divide(T b)
		{
			return this.ElementBinOp(new BinaryOperation<D>(Math.Divide<D>), b);
		}

		/// <summary>
		/// Returns e raised to the specified power.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002CC RID: 716 RVA: 0x0000CE8A File Offset: 0x0000B08A
		public T Exp()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Exp<D>));
		}

		/// <summary>
		/// Returns the natural (base e) logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002CD RID: 717 RVA: 0x0000CE9E File Offset: 0x0000B09E
		public T Log()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Log<D>));
		}

		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="newBase"></param>
		/// <returns></returns>
		// Token: 0x060002CE RID: 718 RVA: 0x0000CEB2 File Offset: 0x0000B0B2
		public T Log(T newBase)
		{
			return this.ElementBinOp(new BinaryOperation<D>(Math.Log<D>), newBase);
		}

		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002CF RID: 719 RVA: 0x0000CEC7 File Offset: 0x0000B0C7
		public T Log10()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Log10<D>));
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x060002D0 RID: 720 RVA: 0x0000CEDB File Offset: 0x0000B0DB
		public T Pow(T b)
		{
			return this.ElementBinOp(new BinaryOperation<D>(Math.Pow<D>), b);
		}

		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		// Token: 0x060002D1 RID: 721 RVA: 0x0000CEF0 File Offset: 0x0000B0F0
		public T Pow(int b)
		{
			return this.LElementBinOp2(new BinaryOperation2<D>(Math.Pow<D>), b);
		}

		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D2 RID: 722 RVA: 0x0000CF05 File Offset: 0x0000B105
		public T Sqrt()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Sqrt<D>));
		}

		/// <summary>
		/// Returns the sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D3 RID: 723 RVA: 0x0000CF19 File Offset: 0x0000B119
		public T Sin()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Sin<D>));
		}

		/// <summary>
		/// Returns the cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D4 RID: 724 RVA: 0x0000CF2D File Offset: 0x0000B12D
		public T Cos()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Cos<D>));
		}

		/// <summary>
		/// Returns the tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D5 RID: 725 RVA: 0x0000CF41 File Offset: 0x0000B141
		public T Tan()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Tan<D>));
		}

		/// <summary>
		/// Returns the angle whose sine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D6 RID: 726 RVA: 0x0000CF55 File Offset: 0x0000B155
		public T Asin()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Asin<D>));
		}

		/// <summary>
		/// Returns the angle whose cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D7 RID: 727 RVA: 0x0000CF69 File Offset: 0x0000B169
		public T Acos()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Acos<D>));
		}

		/// <summary>
		/// Returns the angle whose tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D8 RID: 728 RVA: 0x0000CF7D File Offset: 0x0000B17D
		public T Atan()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Atan<D>));
		}

		/// <summary>
		/// Returns the hyperbolic sine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002D9 RID: 729 RVA: 0x0000CF91 File Offset: 0x0000B191
		public T Sinh()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Sinh<D>));
		}

		/// <summary>
		/// Returns the hyperbolic cosine of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002DA RID: 730 RVA: 0x0000CFA5 File Offset: 0x0000B1A5
		public T Cosh()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Cosh<D>));
		}

		/// <summary>
		/// Returns the hyperbolic tangent of the specified angle.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002DB RID: 731 RVA: 0x0000CFB9 File Offset: 0x0000B1B9
		public T Tanh()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Tanh<D>));
		}

		/// <summary>
		/// Returns the angle whose hyperbolic sine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002DC RID: 732 RVA: 0x0000CFCD File Offset: 0x0000B1CD
		public T Asinh()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Asinh<D>));
		}

		/// <summary>
		/// Returns the angle whose hyperbolic cosine is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002DD RID: 733 RVA: 0x0000CFE1 File Offset: 0x0000B1E1
		public T Acosh()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Acosh<D>));
		}

		/// <summary>
		/// Returns the angle whose hyperbolic tangent is the specified number.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002DE RID: 734 RVA: 0x0000CFF5 File Offset: 0x0000B1F5
		public T Atanh()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Atanh<D>));
		}

		/// <summary>
		/// Returns the complex conjugate.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060002DF RID: 735 RVA: 0x0000D009 File Offset: 0x0000B209
		public T Conj()
		{
			return this.ElementUnOp(new UnaryOperation<D>(Math.Conj<D>));
		}

		/// <summary>
		/// Returns the logarithm of a specified number (object) in a specified base (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		// Token: 0x060002E0 RID: 736 RVA: 0x0000D01D File Offset: 0x0000B21D
		public T LLog(D b)
		{
			return this.LElementBinOp(new BinaryOperation<D>(Math.Log<D>), b);
		}

		/// <summary>
		/// Returns the logarithm of a specified number (<paramref name="a" />) in a specified base (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		// Token: 0x060002E1 RID: 737 RVA: 0x0000D032 File Offset: 0x0000B232
		public T RLog(D a)
		{
			return this.RElementBinOp(new BinaryOperation<D>(Math.Log<D>), a);
		}

		/// <summary>
		/// Returns a specified number (object) raised to the specified power (<paramref name="b" />).
		/// </summary>
		/// <param name="b">The second operand</param>
		/// <returns></returns>
		// Token: 0x060002E2 RID: 738 RVA: 0x0000D047 File Offset: 0x0000B247
		public T LPow(D b)
		{
			return this.LElementBinOp(new BinaryOperation<D>(Math.Pow<D>), b);
		}

		/// <summary>
		/// Returns a specified number (<paramref name="a" />) raised to the specified power (object).
		/// </summary>
		/// <param name="a">The first operand</param>
		/// <returns></returns>
		// Token: 0x060002E3 RID: 739 RVA: 0x0000D05C File Offset: 0x0000B25C
		public T RPow(D a)
		{
			return this.RElementBinOp(new BinaryOperation<D>(Math.Pow<D>), a);
		}
	}
}

using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims.Interface
{
	/// <summary>
	/// Interface Array.
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	// Token: 0x02000044 RID: 68
	public interface INArray<T, D> : IConsole, IStorage<D>, IArrayArithmetic<T, D>, IArithmetic<D>, IArrayMath<T, D>, IMath<D> where T : INArray<T, D> where D : INumber<D>
	{
		/// <summary>
		/// Number of dimensions
		/// </summary>
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000331 RID: 817
		// (set) Token: 0x06000332 RID: 818
		int ndims { get; set; }

		/// <summary>
		/// Size
		/// </summary>
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000333 RID: 819
		// (set) Token: 0x06000334 RID: 820
		int[] size { get; set; }

		/// <summary>
		/// Data
		/// </summary>
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000335 RID: 821
		// (set) Token: 0x06000336 RID: 822
		D[] data { get; set; }

		/// <summary>
		/// Number of elements
		/// </summary>
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000337 RID: 823
		int numel { get; }

		/// <summary>
		/// Returns true if it's a matrix
		/// </summary>
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000338 RID: 824
		bool IsMatrix { get; }

		/// <summary>
		/// Returns true if it's a row vector
		/// </summary>
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000339 RID: 825
		bool IsRowVector { get; }

		/// <summary>
		/// Returns true if it's a column vector
		/// </summary>
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600033A RID: 826
		bool IsColVector { get; }

		/// <summary>
		/// Returns a vector if it's a vector
		/// </summary>
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600033B RID: 827
		D[] Vector { get; }

		/// <summary>
		/// Returns a matrix if it's a matrix
		/// </summary>
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600033C RID: 828
		D[][] Matrix { get; }

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <returns></returns>
		// Token: 0x17000039 RID: 57
		D this[int index1]
		{
			get;
			set;
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <returns></returns>
		// Token: 0x1700003A RID: 58
		D this[int index1, int index2]
		{
			get;
			set;
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <returns></returns>
		// Token: 0x1700003B RID: 59
		D this[int index1, int index2, int index3]
		{
			get;
			set;
		}

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns></returns>
		// Token: 0x1700003C RID: 60
		D this[int[] indices]
		{
			get;
			set;
		}

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <returns>Item</returns>
		// Token: 0x06000345 RID: 837
		D GetItem1d(int index1);

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <returns>Item</returns>
		// Token: 0x06000346 RID: 838
		D GetItem2d(int index1, int index2);

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <returns>Item</returns>
		// Token: 0x06000347 RID: 839
		D GetItem3d(int index1, int index2, int index3);

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Item</returns>
		// Token: 0x06000348 RID: 840
		D GetItemNd(int[] indices);

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		// Token: 0x06000349 RID: 841
		D[] GetItems1d(int[] indices);

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		// Token: 0x0600034A RID: 842
		D[] GetItemsNd(int[][] indices);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="value">Item</param>
		// Token: 0x0600034B RID: 843
		void SetItem1d(int index1, D value);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="value">Item</param>
		// Token: 0x0600034C RID: 844
		void SetItem2d(int index1, int index2, D value);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <param name="value">Item</param>
		// Token: 0x0600034D RID: 845
		void SetItem3d(int index1, int index2, int index3, D value);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		// Token: 0x0600034E RID: 846
		void SetItemNd(int[] indices, D value);

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Items</param>
		// Token: 0x0600034F RID: 847
		void SetItems1d(int[] indices, D[] values);

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Items</param>
		// Token: 0x06000350 RID: 848
		void SetItemsNd(int[][] indices, D[] values);

		/// <summary>
		/// Set Same Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		// Token: 0x06000351 RID: 849
		void SetSameItem1d(int[] indices, D value);

		/// <summary>
		/// Set Same Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		// Token: 0x06000352 RID: 850
		void SetSameItemNd(int[][] indices, D value);

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		// Token: 0x06000353 RID: 851
		void Init1d(int n1);

		/// <summary>
		/// Initializes a 2D-Array (Matrix)
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		// Token: 0x06000354 RID: 852
		void Init2d(int n1, int n2);

		/// <summary>
		/// Initializes a 3D-Array
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		// Token: 0x06000355 RID: 853
		void Init3d(int n1, int n2, int n3);

		/// <summary>
		/// Initializes a ND-Array
		/// </summary>
		/// <param name="size">size</param>
		// Token: 0x06000356 RID: 854
		void InitNd(int[] size);

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// and creates a copy of the data
		/// </summary>
		/// <param name="data">Data</param>
		// Token: 0x06000357 RID: 855
		void Init1dData(D[] data);

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="copy">Copy data</param>
		// Token: 0x06000358 RID: 856
		void Init1dData(D[] data, bool copy);

		// Token: 0x06000359 RID: 857
		void Init2dData(D[,] data);

		/// <summary>
		/// Initializes a 2D-Array (Matrix)
		/// </summary>
		/// <param name="data">Data</param>
		// Token: 0x0600035A RID: 858
		void Init2dData(D[][] data);

		// Token: 0x0600035B RID: 859
		void Init3dData(D[,,] data);

		/// <summary>
		/// Initializes a 3D-Array (Matrix)
		/// </summary>
		/// <param name="data">Data</param>
		// Token: 0x0600035C RID: 860
		void Init3dData(D[][][] data);

		/// <summary>
		/// Initializes a Array.
		/// </summary>
		/// <param name="value">Value</param>
		// Token: 0x0600035D RID: 861
		void InitDbl(double[] value);

		/// <summary>
		/// Initializes a 1D-Array (Vector) with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		// Token: 0x0600035E RID: 862
		void Zeros1d(int n1);

		/// <summary>
		/// Initializes a 2D-Array (Matrix) with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		// Token: 0x0600035F RID: 863
		void Zeros2d(int n1, int n2);

		/// <summary>
		/// Initializes a 3D-Array with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		// Token: 0x06000360 RID: 864
		void Zeros3d(int n1, int n2, int n3);

		/// <summary>
		/// Initializes a ND-Array with all values = 0
		/// </summary>
		/// <param name="size">Size</param>
		// Token: 0x06000361 RID: 865
		void ZerosNd(int[] size);

		/// <summary>
		/// Initializes a 1D-Array (Vector) with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		// Token: 0x06000362 RID: 866
		void Ones1d(int n1);

		/// <summary>
		/// Initializes a 2D-Array (Matrix) with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		// Token: 0x06000363 RID: 867
		void Ones2d(int n1, int n2);

		/// <summary>
		/// Initializes a 3D-Array with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		// Token: 0x06000364 RID: 868
		void Ones3d(int n1, int n2, int n3);

		/// <summary>
		/// Initializes a ND-Array with all values = 1
		/// </summary>
		/// <param name="size">Size</param>
		// Token: 0x06000365 RID: 869
		void OnesNd(int[] size);

		/// <summary>
		/// Reshapes the array
		/// </summary>
		/// <param name="size">Size</param>
		// Token: 0x06000366 RID: 870
		void Reshape(int[] size);

		/// <summary>
		/// Returns a copy of the array
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000367 RID: 871
		T Copy();

		/// <summary>
		/// Initializes a Identity 2D-Array (Matrix)
		/// </summary>
		/// <param name="n">Number of Rows and Cols</param>
		// Token: 0x06000368 RID: 872
		void Identity(int n);

		/// <summary>
		/// Interchange Rows in 2D-Array (Matrix)
		/// </summary>
		/// <param name="index_1">Row Index 1</param>
		/// <param name="index_2">Row Index 2</param>
		// Token: 0x06000369 RID: 873
		void InterchangeRows(int index_1, int index_2);

		/// <summary>
		/// Transpose 2D-Array (Matrix)
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600036A RID: 874
		T Transpose();

		/// <summary>
		/// Concatenate 2D-Arrays (Matrixes) horizontally
		/// </summary>
		/// <param name="b">The second matrix</param>
		/// <returns></returns>
		// Token: 0x0600036B RID: 875
		T HorzCat(T b);

		/// <summary>
		/// Concatenate 2D-Arrays (Matrixes) vertically
		/// </summary>
		/// <param name="b">The second matrix</param>
		/// <returns></returns>
		// Token: 0x0600036C RID: 876
		T VertCat(T b);
	}
}

using System;
using Nuvo.Math.Interface;

namespace Nuvo.Math.Ndims.Interface
{
	/// <summary>
	/// Interface Array.
	/// </summary>
	/// <typeparam name="T">Array Type</typeparam>
	/// <typeparam name="D">Element Type</typeparam>
	public interface INArray<T, D> : IConsole, IStorage<D>, IArrayArithmetic<T, D>, IArithmetic<D>, IArrayMath<T, D>, IMath<D> where T : INArray<T, D> where D : INumber<D>
	{
		/// <summary>
		/// Number of dimensions
		/// </summary>
		int ndims { get; set; }

		/// <summary>
		/// Size
		/// </summary>
		int[] size { get; set; }

		/// <summary>
		/// Data
		/// </summary>
		D[] data { get; set; }

		/// <summary>
		/// Number of elements
		/// </summary>
		int numel { get; }

		/// <summary>
		/// Returns true if it's a matrix
		/// </summary>
		bool IsMatrix { get; }

		/// <summary>
		/// Returns true if it's a row vector
		/// </summary>
		bool IsRowVector { get; }

		/// <summary>
		/// Returns true if it's a column vector
		/// </summary>
		bool IsColVector { get; }

		/// <summary>
		/// Returns a vector if it's a vector
		/// </summary>
		D[] Vector { get; }

		/// <summary>
		/// Returns a matrix if it's a matrix
		/// </summary>
		D[][] Matrix { get; }

		/// <summary>
		/// Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <returns></returns>
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
		D GetItem1d(int index1);

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <returns>Item</returns>
		D GetItem2d(int index1, int index2);

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <returns>Item</returns>
		D GetItem3d(int index1, int index2, int index3);

		/// <summary>
		/// Get Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Item</returns>
		D GetItemNd(int[] indices);

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		D[] GetItems1d(int[] indices);

		/// <summary>
		/// Get Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <returns>Items</returns>
		D[] GetItemsNd(int[][] indices);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="value">Item</param>
		void SetItem1d(int index1, D value);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="value">Item</param>
		void SetItem2d(int index1, int index2, D value);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="index1">Index 1</param>
		/// <param name="index2">Index 2</param>
		/// <param name="index3">Index 3</param>
		/// <param name="value">Item</param>
		void SetItem3d(int index1, int index2, int index3, D value);

		/// <summary>
		/// Set Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		void SetItemNd(int[] indices, D value);

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Items</param>
		void SetItems1d(int[] indices, D[] values);

		/// <summary>
		/// Set Items
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="values">Items</param>
		void SetItemsNd(int[][] indices, D[] values);

		/// <summary>
		/// Set Same Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		void SetSameItem1d(int[] indices, D value);

		/// <summary>
		/// Set Same Item
		/// </summary>
		/// <param name="indices">Indices</param>
		/// <param name="value">Item</param>
		void SetSameItemNd(int[][] indices, D value);

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		void Init1d(int n1);

		/// <summary>
		/// Initializes a 2D-Array (Matrix)
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		void Init2d(int n1, int n2);

		/// <summary>
		/// Initializes a 3D-Array
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		void Init3d(int n1, int n2, int n3);

		/// <summary>
		/// Initializes a ND-Array
		/// </summary>
		/// <param name="size">size</param>
		void InitNd(int[] size);

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// and creates a copy of the data
		/// </summary>
		/// <param name="data">Data</param>
		void Init1dData(D[] data);

		/// <summary>
		/// Initializes a 1D-Array (Vector)
		/// </summary>
		/// <param name="data">Data</param>
		/// <param name="copy">Copy data</param>
		void Init1dData(D[] data, bool copy);

		void Init2dData(D[,] data);

		/// <summary>
		/// Initializes a 2D-Array (Matrix)
		/// </summary>
		/// <param name="data">Data</param>
		void Init2dData(D[][] data);

		void Init3dData(D[,,] data);

		/// <summary>
		/// Initializes a 3D-Array (Matrix)
		/// </summary>
		/// <param name="data">Data</param>
		void Init3dData(D[][][] data);

		/// <summary>
		/// Initializes a Array.
		/// </summary>
		/// <param name="value">Value</param>
		void InitDbl(double[] value);

		/// <summary>
		/// Initializes a 1D-Array (Vector) with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		void Zeros1d(int n1);

		/// <summary>
		/// Initializes a 2D-Array (Matrix) with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		void Zeros2d(int n1, int n2);

		/// <summary>
		/// Initializes a 3D-Array with all values = 0
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		void Zeros3d(int n1, int n2, int n3);

		/// <summary>
		/// Initializes a ND-Array with all values = 0
		/// </summary>
		/// <param name="size">Size</param>
		void ZerosNd(int[] size);

		/// <summary>
		/// Initializes a 1D-Array (Vector) with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		void Ones1d(int n1);

		/// <summary>
		/// Initializes a 2D-Array (Matrix) with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements (rows)</param>
		/// <param name="n2">Dim: 2, Number of elements (cols)</param>
		void Ones2d(int n1, int n2);

		/// <summary>
		/// Initializes a 3D-Array with all values = 1
		/// </summary>
		/// <param name="n1">Dim: 1, Number of elements</param>
		/// <param name="n2">Dim: 2, Number of elements</param>
		/// <param name="n3">Dim: 3, Number of elements</param>
		void Ones3d(int n1, int n2, int n3);

		/// <summary>
		/// Initializes a ND-Array with all values = 1
		/// </summary>
		/// <param name="size">Size</param>
		void OnesNd(int[] size);

		/// <summary>
		/// Reshapes the array
		/// </summary>
		/// <param name="size">Size</param>
		void Reshape(int[] size);

		/// <summary>
		/// Returns a copy of the array
		/// </summary>
		/// <returns></returns>
		T Copy();

		/// <summary>
		/// Initializes a Identity 2D-Array (Matrix)
		/// </summary>
		/// <param name="n">Number of Rows and Cols</param>
		void Identity(int n);

		/// <summary>
		/// Interchange Rows in 2D-Array (Matrix)
		/// </summary>
		/// <param name="index_1">Row Index 1</param>
		/// <param name="index_2">Row Index 2</param>
		void InterchangeRows(int index_1, int index_2);

		/// <summary>
		/// Transpose 2D-Array (Matrix)
		/// </summary>
		/// <returns></returns>
		T Transpose();

		/// <summary>
		/// Concatenate 2D-Arrays (Matrixes) horizontally
		/// </summary>
		/// <param name="b">The second matrix</param>
		/// <returns></returns>
		T HorzCat(T b);

		/// <summary>
		/// Concatenate 2D-Arrays (Matrixes) vertically
		/// </summary>
		/// <param name="b">The second matrix</param>
		/// <returns></returns>
		T VertCat(T b);
	}
}

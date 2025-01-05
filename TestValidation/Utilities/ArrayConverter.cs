using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Nuvo.TestValidation.Utilities
{
    public class ArrayConverter
    {
        public Array ConvertObjectToNDArray(object obj)
        {
            if (!(obj is List<object[]> data))
            {
                throw new ArgumentException("Object must be a List<object[]>");
            }

            // Determine the dimensions
            if (data.Count == 0)
            {
                throw new ArgumentException("Data cannot be empty to determine dimensions.");
            }

            int[] dimensions = DetermineDimensions(data);

            var result = Array.CreateInstance(typeof(double), dimensions);

            // Populate the array
            for (int i = 0; i < data.Count; i++)
            {
                int[] indices = ConvertIndexToND(i, dimensions);
                for (int j = 0; j < dimensions.Length; j++)
                {
                    if (data[i][j] is double d)
                    {
                        result.SetValue(d, indices);
                    }
                    else
                    {
                        throw new ArgumentException($"Expected double but got {data[i][j].GetType().Name} at index {j}.");
                    }
                }
            }

            return result;
        }

        private int[] DetermineDimensions(List<object[]> data)
        {
            // Assuming all rows have the same length for simplicity
            int depth = data[0].Length;
            int[] dims = new int[depth];

            for (int i = 0; i < depth; i++)
            {
                // Here we're making an assumption about how to determine the size of each dimension
                // This might need adjustment based on how your data represents dimensions
                dims[i] = (int)System.Math.Sqrt(data.Count);
            }
            return dims;
        }

        private int[] ConvertIndexToND(int flatIndex, int[] dimensions)
        {
            int[] coords = new int[dimensions.Length];
            for (int i = dimensions.Length - 1; i >= 0; i--)
            {
                coords[i] = flatIndex % dimensions[i];
                flatIndex /= dimensions[i];
            }
            return coords;
        }

        public List<object[]> ConvertNDArrayToObjectList(Array array)
        {
            var result = new List<object[]>();

            // Get the length of each dimension
            int[] lengths = new int[array.Rank];
            for (int i = 0; i < array.Rank; i++)
            {
                lengths[i] = array.GetLength(i);
            }

            // Iterate through all positions in the array
            foreach (var indices in GetIndices(lengths))
            {
                var values = new object[array.Rank];
                for (int i = 0; i < array.Rank; i++)
                {
                    values[i] = array.GetValue(indices);
                }
                result.Add(values);
            }

            return result;
        }

        private IEnumerable<int[]> GetIndices(int[] lengths)
        {
            int[] indices = new int[lengths.Length];
            while (true)
            {
                yield return indices.ToArray();

                int i = indices.Length - 1;
                while (i >= 0 && indices[i] + 1 >= lengths[i])
                    indices[i--] = 0;
                if (i < 0) yield break;
                indices[i]++;
            }
        }
    }
}

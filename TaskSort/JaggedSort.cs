using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSort
{
    public class JaggedSort
    {
        private int[][] _jaggedArray { get; set; }
        ///<summary>
        ///Constructor
        ///</summary>
        public JaggedSort(int [][] jaggedArray)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }
            this._jaggedArray = jaggedArray;
        }

        
        ///<summary>
        ///Method for summary of array
        ///</summary>
        private int Sum (int [] arr)
        {
            int responce = 0;
            for (int i = 0; i < arr.Length; i++)
                responce += arr[i];
            return responce;
        }
        ///<summary>
        ///Method for foind max element in array
        ///</summary>
        private int Max (int [] arr)
        {
            int responce = arr[0];
            for (int i = 0; i < arr.Length; i++)
                if (responce < arr[i])
                    responce = arr[i];
            return responce;
        }
        ///<summary>
        ///Method for faind min element in array
        ///</summary>
        private int Min(int[] arr)
        {
            int responce = arr[0];
            for (int i = 0; i < arr.Length; i++)
                if (responce > arr[i])
                    responce = arr[i];
            return responce;
        }


        ///<summary>
        /// Metjod for Bubble sort
        ///</summary>
        private void Swap(ref int[] arr1, ref int[] arr2)
        {
            var temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        ///<summary>
        ///Sorted array by sum of rows
        ///</summary>
        public int[][] BubbleSortWithSum(bool decr)
        {
            var len = _jaggedArray.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (!decr)
                    {
                        if (Sum(_jaggedArray[j]) > Sum(_jaggedArray[j + 1]))
                        {
                            Swap(ref _jaggedArray[j], ref _jaggedArray[j + 1]);
                        }
                    }
                    else
                    {
                        if (Sum(_jaggedArray[j]) < Sum(_jaggedArray[j + 1]))
                        {
                            Swap(ref _jaggedArray[j], ref _jaggedArray[j + 1]);
                        }
                    }

                }
            }

            return _jaggedArray;
        }
        ///<summary>
        ///sorted array by max element in rows
        ///</summary>
        public int[][] BubbleSortWithMax(bool decr)
        {
            var len = _jaggedArray.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (!decr)
                    {

                        if (Max(_jaggedArray[j]) > Max(_jaggedArray[j + 1]))
                            Swap(ref _jaggedArray[j], ref _jaggedArray[j + 1]);

                    }
                    else
                    {
                        if (Max(_jaggedArray[j]) < Max(_jaggedArray[j + 1]))
                            Swap(ref _jaggedArray[j], ref _jaggedArray[j + 1]);

                    }
                }
            }
            return _jaggedArray;
        }
        
        ///<summary>
        ///sorted array by min element in rows
        ///</summary>
        public int[][] BubbleSortWithMin(bool decr)
        {
            var len = _jaggedArray.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (!decr)
                    {
                        if (Min(_jaggedArray[j]) > Min(_jaggedArray[j + 1]))
                            Swap(ref _jaggedArray[j], ref _jaggedArray[j + 1]);

                    }
                    else
                    {
                        if (Min(_jaggedArray[j]) < Min(_jaggedArray[j + 1]))
                            Swap(ref _jaggedArray[j], ref _jaggedArray[j + 1]);

                    }
                }
            }
            return _jaggedArray;
        }
    }
}

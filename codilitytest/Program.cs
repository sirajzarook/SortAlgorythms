using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codilitytest
{
	class Program
	{
		static void Main(string[] args)
		{
			//Equilibirium
			int[] arr1 = new int[] { -1, 3, -4, 5, 1, -6, 2, 1 };
			Solution sol = new Solution();
			int result = sol.solution(arr1);
			Console.WriteLine($"----------------Equilibirium {result},");
			//-------------

			//Bubble Sort
			List<int> unsorted = new List<int> { 9, 8, 7, 6 };
			string inputInts = string.Join(",", unsorted.Select(x => x.ToString())); //Liqn online int list to string

			Console.WriteLine($"Bubble sort : {inputInts}");
			unsorted = sol.bubblesort(unsorted);

			foreach (int i in unsorted)
				Console.Write($"{i},");
			Console.WriteLine($"------------------");
			//-----------------


			//QuickSort
			List<int> unsortedQS = new List<int> { 9, 8, 7, 6, 5, 4, 2 };
			string inputIntsQS = string.Join(",", unsortedQS.Select(x => x.ToString())); //Liqn online int list to string
			Console.WriteLine($"Quick sort : {inputIntsQS}");
			QuickSort qs = new QuickSort();
			unsortedQS = qs.quicksort(unsortedQS);
			foreach (int i in unsortedQS)
				Console.Write($"{i},");
			Console.WriteLine($"------------------");


			//MergeSort
			List<int> unsortedMS = new List<int> { 9, 8, 7, 6, 5, 4, 2 };
			string inputIntsMS = string.Join(",", unsortedMS.Select(x => x.ToString())); //Liqn online int list to string
			Console.WriteLine($"Merge sort : {inputIntsMS}");
			QuickSort ms = new QuickSort();
			unsortedQS = ms.quicksort(unsortedMS);
			foreach (int i in unsortedMS)
				Console.Write($"{i},");
			Console.WriteLine($"------------------");


			//HeadSort
			int[] arrHP = new int[] { 9, 8, 7, 6, 5, 4, 2, 1 };
			HeadSort hs = new HeadSort();
			int[] resultHP = hs.heapSort(arrHP, arrHP.Length );
			Console.WriteLine($"HeadShort,");
			foreach (int i in resultHP)
				Console.Write($"{i},");
			Console.WriteLine($"------------------");
			//-------------

			//---------------------
			Console.ReadLine();

		}


	}




	class Solution
	{
		public int solution(int[] A)
		{
			// First calculate sum of complete array as `sum_right`
			long sum_right = 0;
			for (int i = 0; i < A.Length; i++)
			{
				sum_right += A[i];
			}

			// start calculating sum from left side (lower index) as `sum_left`
			// in each iteration subtract A[i] from complete array sum - `sum_right`
			long sum_left = 0;
			for (int p = 0; p < A.Length; p++)
			{
				sum_left += p - 1 < 0 ? 0 : A[p - 1];
				sum_right -= A[p];
				if (sum_left == sum_right)
				{
					return p;
				}
			}
			return -1;


		}

		public List<int> bubblesort(List<int> a)
		{
			int temp;
			// foreach(int i in a)
			for (int i = 1; i <= a.Count; i++)
				for (int j = 0; j < a.Count - i; j++)
					if (a[j] > a[j + 1])
					{
						temp = a[j];
						a[j] = a[j + 1];
						a[j + 1] = temp;
					}
			return a;
		}

	}

	public class QuickSort
	{
		public List<int> quicksort(List<int> a)
		{
			Random r = new Random();
			List<int> less = new List<int>();
			List<int> greater = new List<int>();
			if (a.Count <= 1)
				return a;
			int pos = r.Next(a.Count);

			int pivot = a[pos];
			a.RemoveAt(pos);
			foreach (int x in a)
			{
				if (x <= pivot)
				{
					less.Add(x);
				}
				else
				{
					greater.Add(x);
				}
			}
			return concat(quicksort(less), pivot, quicksort(greater));
		}

		public List<int> concat(List<int> less, int pivot, List<int> greater)
		{
			List<int> sorted = new List<int>(less);
			sorted.Add(pivot);
			foreach (int i in greater)
			{

				sorted.Add(i);
			}

			return sorted;
		}

	}


	public class HeadSort
	{
		public int[] heapSort(int[] numbers, int array_size)
		{
			int i, temp;
			for (i = (array_size / 2) - 1; i >= 0; i--)
				siftDown(numbers, i, array_size);
			for (i = array_size - 1; i >= 1; i--)
			{
				temp = numbers[0];
				numbers[0] = numbers[i];
				numbers[i] = temp;
				siftDown(numbers, 0, i - 1);
			}
			return numbers;
		}


		void siftDown(int[] numbers, int root, int bottom)
		{
			int done, maxChild, temp;
			done = 0;
			while ((root * 2 <= bottom) && (done == 0))
			{
				if (root * 2 == bottom)
					maxChild = root * 2;
				else if (numbers[root * 2] > numbers[root * 2 + 1])
					maxChild = root * 2;
				else
					maxChild = root * 2 + 1;
				if (numbers[root] < numbers[maxChild])
				{
					temp = numbers[root];
					numbers[root] = numbers[maxChild];
					numbers[maxChild] = temp;
					root = maxChild;
				}
				else
					done = 1;
			}
		}
	} 



	//class Solution
	//{
	//	public int solution(int[] A)
	//	{
	//		int ltot = 0;
	//		foreach (int i in A)
	//		{
	//			if (totalLeft(A, i) <= A[i] &&  A[i] < totalRight(A, i)) 
	//				return i;

	//		}
	//		return -1;
	//	}

	//	public int totalLeft(int[] Left, int P)
	//	{
	//		int leftT = 0;
	//		for(int i = 0; i < P -1; i++)
	//		{
	//			leftT += Left[i];
	//		}
	//		return leftT;
	//	}

	//	public int totalRight(int[] Left, int P)
	//	{
	//		int leftT = 0;
	//		for (int i = P+1; i < Left.Length ; i++)
	//		{
	//			leftT += Left[i];
	//		}
	//		return leftT;
	//	}

	//}

}



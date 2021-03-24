using System;
using System.Collections.Generic;

namespace BA1N
{
	class Program
	{
		public static int Hammingdistance(string p, string q)
		{
			if (p.Length != q.Length)
				return -1;
			int i = 0;
			int count = 0;
			while (i < p.Length)
			{
				if (p.Substring(i, 1) != q.Substring(i, 1))
					count++;


				i++;

			}
			return count;
		}
		public static List<string> Neighbors(string pattern, int d)
	  {
			List<string> nucleotide = new List<string>();
			nucleotide.Add("C");
			nucleotide.Add("G");
			nucleotide.Add("A");
			nucleotide.Add("T");
			List<string> neighborhood = new List<string>();
			if (d == 0)
			{
				neighborhood.Add(pattern);
				return neighborhood;
			}
			if (pattern.Length == 1)
			{
				neighborhood.Add("C");
				neighborhood.Add("G");
				neighborhood.Add("A");
				neighborhood.Add("T");
				return neighborhood;
			}
			List<string> suffiexneighbors = Neighbors(pattern.Substring(1), d);
			foreach (string text in suffiexneighbors)
			{
				if (Hammingdistance(pattern.Substring(1), text) < d)
				{
					foreach (string x in nucleotide)
					{
						string s = "";
						 s = x + text;
						neighborhood.Add(s);
					}
				}
				else
				{
					string o = "";
					o = pattern.Substring(0, 1) + text;
					neighborhood.Add(o);
				}
				
			}
			return neighborhood;
			
		

	  }




		static void Main(string[] args)
		{
			List<string> lista = Neighbors("ACG", 1);
			foreach (string s in lista)
				Console.WriteLine(s + " ");
			Console.WriteLine("kraj");

		}
	}
}



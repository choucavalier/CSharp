using System;
using System.IO;

namespace TPCSharp4
{
	public static class IO
	{
		public static string GetRFile ()
		{
			string filename = "";

			Console.WriteLine ("Please enter the name of the sudoku file : ");
			filename = Console.ReadLine ();
			Console.WriteLine ("Processing...\n");

			return (filename);
		}

		public static int FileToTab (string filename, ref int[,] tab)
		{
			int j = 0;
			StreamReader SR;
			string line = "";

			Sudoku.InitTab (ref tab);
			try {
				SR = new StreamReader (filename);
			} catch (Exception) {
				Console.WriteLine ("ERROR : File does not exist !");
				return 1;
			}
			while ((line = SR.ReadLine()) != null && j < tab.GetLength(1)) {
				if (line.Length < tab.GetLength (0)) {
					Console.WriteLine ("ERROR : Bad file format, not enough character for the Sudoku.");
					Console.WriteLine ("Need at least {0} !", tab.GetLength (0));
					SR.Close ();
					return 2;
				}
				for (int i = 0; i < tab.GetLength(0); ++i)
					tab [i, j] = Convert.ToInt32 (line [i].ToString ());
				++j;
			}
			SR.Close ();
			return 0;
		}

		public static string GetSFile ()
		{
			string filename = "";

			Console.WriteLine ("Please enter the name of the file where you want to save the result : ");
			filename = Console.ReadLine ();
			Console.WriteLine ("Processing...\n");

			return (filename);
		}

		public static int TabToFile (string filename, int[,] tab)
		{
			StreamWriter SW;
			string line = "";
			
			try {
				SW = new StreamWriter (new FileStream (filename, FileMode.CreateNew));
			} catch (Exception) {
				Console.WriteLine ("ERROR : File already exists !");
				do {
					Console.WriteLine ("Do you want to overrite it ? (y/n) : ");
					line = Console.ReadLine ();
				} while (line != "y" && line != "Y" && line != "n" && line != "N");
				if (line == "n" || line == "N")
					return 1;
				else
					SW = new StreamWriter (new FileStream (filename, FileMode.Create));
			}
			for (int i = 0; i < tab.GetLength(0); ++i) {
				for (int j = 0; j < tab.GetLength(1); ++j)
					SW.Write (tab [i, j]);
				SW.Write ("\n");
			}
			SW.Close ();
			return 0;
		}
	}
}


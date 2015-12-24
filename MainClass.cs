using System;
using System.Text;

namespace puzzle
{
	/// <summary>
	/// Summary description for MainClass.
	/// </summary>
	public class MainClass
	{
		public MainClass()
		{
		}

		static int Main(string[] args) 
		{
			string start="";
			if (args.Length==0)
			{
				for (int i=0;i<15;i++)
				{
					start=new String('X',i)+"O"+new String('X',14-i);
					GameBoard board=new GameBoard(new StringBuilder(start,16),"");
					board.Search();
				}
				return 0;
			}
			else
			{
				start=args[0].ToUpper();
				if (start.Length!=15)
				{
					Console.WriteLine("invalid starting state");
					return 1;
				}
				GameBoard board=new GameBoard(new StringBuilder(start,16),"");
				board.Search();
				return 0;
			}
		}
	}
}

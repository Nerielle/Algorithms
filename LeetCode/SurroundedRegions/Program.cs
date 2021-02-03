using System;
using System.Linq;
namespace SurroundedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            var twodim=new char[4][];
            twodim[0]=new char []{'X','X','X'};
            twodim[1]=new char []{'O','X','O'};
            twodim[2]=new char []{'X','O','X'};
            twodim[3]=new char []{'X','X','X'};

            Solve(twodim);

           foreach(var row in twodim){
               string line = String.Empty;
               for (int i = 0; i < row.Length; i++)
               {
                   line += $" {row[i]}";
               }
               Console.WriteLine(line);
           }
        }

        public static void Solve(char[][] board)
        {
            for(int i=0; i<board.Length;i++){
                
            }
        }
    }
}

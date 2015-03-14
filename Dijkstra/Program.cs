using System;
using System.IO;
using System.Linq;

namespace Dijkstra
{
    internal class Program
    {

        //Result: 2599,2610,2947,2052,2367,2399,2029,2442,2505,3068
        private static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Projects\Dijkstra\123\dijkstraData.txt")
            //var input = File.ReadAllLines(@"C:\Projects\Dijkstra\123\test.txt").ToList()
                .Select((x, i) => new VertexInfo(i, ParseLine(x, i)))
                .ToList();
            var dijkstra = new Dijkstra(input);
            var findPath = dijkstra.FindPaths().ToList();
            Console.WriteLine(string.Join(",", findPath.Select(p => p.Item2)));
            Console.ReadLine();
        }

        private static Edge[] ParseLine(string s, int rowIndex)
        {
            return s.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries).ToList()
                    .Skip(1)
                    .Select(x => ParseValue(x, rowIndex))
                    .ToArray();
        }

        private static Edge ParseValue(string input, int rowIndex)
        {
            var split = input.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            return new Edge(rowIndex, split[0] - 1, split[1]);
        }
    }
}
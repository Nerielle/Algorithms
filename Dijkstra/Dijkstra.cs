using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public class Dijkstra
    {
        private readonly List<VertexInfo> vertexInfoes;
        private Dictionary<int, int> paths = new Dictionary<int, int>();
        private int[] vertices;

        public Dijkstra(List<VertexInfo> vertexInfoes)
        {
            this.vertexInfoes = vertexInfoes;
        }

        private int[] Vertices
        {
            get
            {
                if (vertices != null)
                {
                    return vertices;
                }
                int[] array = {7, 37, 59, 82, 99, 115, 133, 165, 188, 197};
                //int[] array = { 1, 2, 3, 4, 5 };
                vertices = array.Select(x => x - 1).ToArray();
                return vertices;
            }
        }

        public VertexInfo FindVertexWithMinPath(List<VertexInfo> processingVertices)
        {
            return processingVertices.Where(x => x.EdgesWithoutLoops.Any())
                                     .Select(x => x)
                                     .OrderBy(x =>
                                         {
                                             Edge minEdge = x.GetMinEdge();
                                             return minEdge.Length + paths[x.Label];
                                         })
                                     .FirstOrDefault();
        }

        public IEnumerable<Tuple<int, int>> FindPaths()
        {
            paths = vertexInfoes.ToDictionary(x => x.Label, x => -1);
            paths[0] = 0;
            var processingVertices = new List<VertexInfo> {vertexInfoes[0]};
            Process(processingVertices);

            foreach (int vertice in Vertices)
            {
                if (paths[vertice] == -1)
                    yield return Tuple.Create(vertice + 1, 1000000);
                else
                {
                    yield return Tuple.Create(vertice + 1, paths[vertice]);
                }
            }
        }

        private void Process(List<VertexInfo> processingVertices)
        {
            VertexInfo vertexInfo = FindVertexWithMinPath(processingVertices);
            if (vertexInfo != null)
            {
                Edge minEdge = vertexInfo.GetMinEdge();
                paths[minEdge.LabelTo] = minEdge.Length + paths[vertexInfo.Label];
                processingVertices.ForEach(x =>
                    {
                        x.ExcludeFoundedPathsFromEdges(minEdge.LabelTo);
                        vertexInfoes[minEdge.LabelTo].ExcludeFoundedPathsFromEdges(x.Label);
                    });

                processingVertices.Add(vertexInfoes[minEdge.LabelTo]);
                Process(processingVertices);
            }
        }
    }

    public struct Edge : IComparable<Edge>
    {
        public Edge(int labelFrom, int labelTo, int length)
            : this()
        {
            LabelTo = labelTo;
            Length = length;
            LabelFrom = labelFrom;
        }

        public int LabelFrom { get; set; }
        public int LabelTo { get; set; }
        public int Length { get; set; }

        public int CompareTo(Edge other)
        {
            if (Length < other.Length)
                return -1;
            return Length == other.Length ? 0 : 1;
        }
    }

    public class VertexInfo
    {
        public VertexInfo(int label, Edge[] edges)
        {
            Label = label;
            Edges = edges ?? new Edge[0];
            EdgesWithoutLoops = ExcludeLoops();
        }

        private Edge[] Edges { get; set; }
        public List<Edge> EdgesWithoutLoops { get; set; }
        public int Label { get; set; }

        public void ExcludeFoundedPathsFromEdges(int labelTo)
        {
            EdgesWithoutLoops.RemoveAll(x => x.LabelTo == labelTo);
        }

        public Edge GetMinEdge()
        {
            return EdgesWithoutLoops.Min();
        }

        private List<Edge> ExcludeLoops()
        {
            return Edges.Where(x => x.LabelTo != Label).ToList();
        }
    }
}
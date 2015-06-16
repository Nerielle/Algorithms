using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
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
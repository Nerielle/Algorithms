using System;

namespace Dijkstra
{
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
}
using System.Collections.Generic;

namespace ColonySim
{
    public class Node
    {
        public List<Edge> Edges;
        public Tile Tile;

        public Node(Tile tile)
        {
            Tile = tile;
        }
    }
}
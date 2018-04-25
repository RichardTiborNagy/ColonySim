namespace ColonySim
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Node
    {
        public Tile Tile;

        public List<Edge> Edges;

        public Node(Tile tile)
        {
            Tile = tile;
        }
    }
}
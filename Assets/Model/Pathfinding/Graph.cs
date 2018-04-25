using System.Collections.Generic;

namespace ColonySim
{
    public class Graph
    {
        public Dictionary<Tile, Node> Nodes;

        public Graph(World world)
        {
            if (world == null) return;

            Nodes = new Dictionary<Tile, Node>();

            foreach (var tile in world.Tiles)
            {
                var node = new Node(tile);

                Nodes.Add(tile, node);
            }

            foreach (var tile in Nodes.Keys) CreateEdges(tile);
        }

        public void RecreateEdges(Tile tile)
        {
            CreateEdges(tile);
            foreach (var neighbor in tile.Neighbors) CreateEdges(neighbor);
        }

        private void CreateEdges(Tile tile)
        {
            var node = Nodes[tile];
            //var neighbors = tile.Neighbors as List<Tile>;
            node.Edges = new List<Edge>();

            foreach (var neighbor in tile.Neighbors)
                if (neighbor.MovementCost > 0)
                    node.Edges.Add(new Edge(Nodes[neighbor], neighbor.MovementCost));
        }
    }
}
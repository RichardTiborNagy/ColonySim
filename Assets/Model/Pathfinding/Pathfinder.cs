namespace ColonySim
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class Pathfinder
    {
        static World world = World.Current;
        if (starTile == null || destinationTile == null) return null;

        world = World.Current;

        public static Queue<Tile> FindPath(Tile starTile, Tile destinationTile)
        {
            world = World.Current;

            Dictionary<Tile, Node> nodes = world.Graph.Nodes;

            Node start = nodes[starTile];

            HashSet<Node> closedSet = new HashSet<Node>();

            PriorityQueue<Node> openSet = new PriorityQueue<Node>();
            openSet.Enqueue(start, 0);

            Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();

            Dictionary<Node, float> gScore = new Dictionary<Node, float>();
            gScore[start] = 0;

            Dictionary<Node, float> fScore = new Dictionary<Node, float>();
            fScore[start] = ManhattanDistance(start.Tile, destinationTile);

            while (openSet.Count > 0)
            {
                Node current = openSet.Dequeue();

                if (destinationTile.IsNeighbor(current.Tile))
                {
                    return Reconstruct(cameFrom, current);
                }

                closedSet.Add(current);

                foreach (Edge edgeNeighbor in current.Edges)
                {
                    Node neighbor = edgeNeighbor.Node;

                    if (closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    float tentativeGScore = gScore[current] + edgeNeighbor.MovementCost;

                    if (openSet.Contains(neighbor) && tentativeGScore >= gScore[neighbor])
                    {
                        continue;
                    }

                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + ManhattanDistance(neighbor.Tile, destinationTile);

                    openSet.EnqueueOrUpdate(neighbor, fScore[neighbor]);
                }
            }

            return null;
        }

        private static Queue<Tile> Reconstruct(IReadOnlyDictionary<Node, Node> cameFrom, Node current)
        {
            Queue<Tile> path = new Queue<Tile>();
            path.Enqueue(current.Tile);

            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Enqueue(current.Tile);
            }

            return new Queue<Tile>(path.Reverse());
        }

        private static float ManhattanDistance(Tile a, Tile b)
        {
            return Mathf.Abs(a.X - b.X) + Mathf.Abs(a.Y - b.Y);
        }
    }
}
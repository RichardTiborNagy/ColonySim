using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ColonySim
{
    public static class Pathfinder
    {
        private static World world = World.Current;

        public static Queue<Tile> FindPath(Tile starTile, Tile destinationTile)
        {
            if (starTile == null || destinationTile == null) return null;

            world = World.Current;

            var nodes = world.Graph.Nodes;

            var start = nodes[starTile];

            var closedSet = new HashSet<Node>();

            var openSet = new PriorityQueue<Node>();
            openSet.Enqueue(start, 0);

            var cameFrom = new Dictionary<Node, Node>();

            var gScore = new Dictionary<Node, float>();
            gScore[start] = 0;

            var fScore = new Dictionary<Node, float>();
            fScore[start] = ManhattanDistance(start.Tile, destinationTile);

            while (openSet.Count > 0)
            {
                var current = openSet.Dequeue();

                if (destinationTile.IsNeighbor(current.Tile)) return Reconstruct(cameFrom, current);

                closedSet.Add(current);

                foreach (var edgeNeighbor in current.Edges)
                {
                    var neighbor = edgeNeighbor.Node;

                    if (closedSet.Contains(neighbor)) continue;

                    var tentativeGScore = gScore[current] + edgeNeighbor.MovementCost;

                    if (openSet.Contains(neighbor) && tentativeGScore >= gScore[neighbor]) continue;

                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + ManhattanDistance(neighbor.Tile, destinationTile);

                    openSet.EnqueueOrUpdate(neighbor, fScore[neighbor]);
                }
            }

            return null;
        }

        private static float ManhattanDistance(Tile a, Tile b)
        {
            return Mathf.Abs(a.X - b.X) + Mathf.Abs(a.Y - b.Y);
        }

        private static Queue<Tile> Reconstruct(IReadOnlyDictionary<Node, Node> cameFrom, Node current)
        {
            var path = new Queue<Tile>();
            path.Enqueue(current.Tile);

            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                path.Enqueue(current.Tile);
            }

            return new Queue<Tile>(path.Reverse());
        }
    }
}
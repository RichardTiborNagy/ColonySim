namespace ColonySim
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Edge
    {
        //Points to this
        public Node Node;

        //Weight
        public float MovementCost;


        public Edge(Node node, float movementCost)
        {
            Node = node;
            MovementCost = movementCost;
        }
    }
}
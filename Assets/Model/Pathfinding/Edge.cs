namespace ColonySim
{
    public class Edge
    {
        //Weight
        public float MovementCost;

        //Points to this
        public Node Node;


        public Edge(Node node, float movementCost)
        {
            Node = node;
            MovementCost = movementCost;
        }
    }
}
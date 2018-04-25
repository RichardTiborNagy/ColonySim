namespace ColonySim
{
    using System.Collections.Generic;
    using Priority_Queue;

    public class PriorityQueue<T>
    {
        protected FastPriorityQueue<WrappedNode> wrappedQueue;

        protected Dictionary<T, WrappedNode> mapDataToWrappedNode;

        public PriorityQueue(int startingSize = 10)
        {
            wrappedQueue = new FastPriorityQueue<WrappedNode>(startingSize);
            mapDataToWrappedNode = new Dictionary<T, WrappedNode>();
        }

        public int Count
        {
            get { return wrappedQueue.Count; }
        }

        public bool Contains(T data)
        {
            return mapDataToWrappedNode.ContainsKey(data);
        }

        public void Enqueue(T data, float priority)
        {
            if (mapDataToWrappedNode.ContainsKey(data))
            {
                return;
            }

            if (wrappedQueue.Count == wrappedQueue.MaxSize)
            {
                wrappedQueue.Resize((2 * wrappedQueue.MaxSize) + 1);
            }

            WrappedNode newNode = new WrappedNode(data);
            wrappedQueue.Enqueue(newNode, priority);
            mapDataToWrappedNode[data] = newNode;
        }

        public void UpdatePriority(T data, float priority)
        {
            WrappedNode node = mapDataToWrappedNode[data];
            wrappedQueue.UpdatePriority(node, priority);
        }

        public void EnqueueOrUpdate(T data, float priority)
        {
            if (mapDataToWrappedNode.ContainsKey(data))
            {
                UpdatePriority(data, priority);
            }
            else
            {
                Enqueue(data, priority);
            }
        }

        public T Dequeue()
        {
            WrappedNode popped = wrappedQueue.Dequeue();
            mapDataToWrappedNode.Remove(popped.Data);
            return popped.Data;
        }

        protected class WrappedNode : FastPriorityQueueNode
        {
            public readonly T Data;

            public WrappedNode(T data)
            {
                this.Data = data;
            }
        }
    }
}
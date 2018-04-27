using System.Collections.Generic;
using ColonySim.Priority_Queue;

namespace ColonySim
{
    public class PriorityQueue<T>
    {
        protected Dictionary<T, WrappedNode> mapDataToWrappedNode;
        protected FastPriorityQueue<WrappedNode> wrappedQueue;

        public PriorityQueue(int startingSize = 10)
        {
            if (startingSize < 1 || startingSize > 4096) return;
            wrappedQueue = new FastPriorityQueue<WrappedNode>(startingSize);
            mapDataToWrappedNode = new Dictionary<T, WrappedNode>();
        }

        public int Count => wrappedQueue?.Count ?? 0;

        public bool Contains(T data)
        {
            return mapDataToWrappedNode?.ContainsKey(data) ?? false;
        }

        public T Dequeue()
        {
            if (Count == 0) return default(T);
            var popped = wrappedQueue.Dequeue();
            mapDataToWrappedNode.Remove(popped.Data);
            return popped.Data;
        }

        public void Enqueue(T data, float priority)
        {
            if (data == null || (mapDataToWrappedNode?.ContainsKey(data) ?? true)) return;

            if (wrappedQueue.Count == wrappedQueue.MaxSize) wrappedQueue.Resize(2 * wrappedQueue.MaxSize + 1);

            var newNode = new WrappedNode(data);
            wrappedQueue.Enqueue(newNode, priority);
            mapDataToWrappedNode[data] = newNode;
        }

        public void EnqueueOrUpdate(T data, float priority)
        {
            if (data == null || mapDataToWrappedNode == null) return;
            if (mapDataToWrappedNode.ContainsKey(data))
                UpdatePriority(data, priority);
            else
                Enqueue(data, priority);
        }

        public void UpdatePriority(T data, float priority)
        {
            if (data == null || (!mapDataToWrappedNode?.ContainsKey(data) ?? true)) return;
            var node = mapDataToWrappedNode[data];
            wrappedQueue.UpdatePriority(node, priority);
        }

        protected class WrappedNode : FastPriorityQueueNode
        {
            public readonly T Data;

            public WrappedNode(T data)
            {
                Data = data;
            }
        }
    }
}
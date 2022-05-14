public class Solution 
{
    private int Dijikstra(List<(int,int)>[] adjacencyList, int n, int startIdx)
    {
        (int distance, bool finalized)[] nodes = 
            Enumerable.Range(0,n)
            .Select(i => i == startIdx ? (0, false) : (Int32.MaxValue, false))
            .ToArray();
        
        PriorityQueue<int, int> GetUnfinalized()
        {
            var priorityQueue = new PriorityQueue<int, int>();
            for(var i = 0; i < n; i++)
            {
                if (!nodes[i].finalized)
                    priorityQueue.Enqueue(i, nodes[i].distance);
            }
            return priorityQueue;
        }
        
        while(GetUnfinalized().TryDequeue(out var toFinalize, out var toFinalizeDistance))
        {
            nodes[toFinalize] = (toFinalizeDistance, true);
            
            var neighborsWithDistance = adjacencyList[toFinalize];
            
            foreach(var neighbor in neighborsWithDistance)
            {
                var (neighborIdx, neighborDistance) = neighbor;
                if (!nodes[neighborIdx].finalized)
                {
                    var newDistance = Math.Min(
                        nodes[neighborIdx].distance, toFinalizeDistance + neighborDistance);
                    
                    nodes[neighborIdx] = (newDistance, false);
                }
            }
        }
        
        var maxDistance = 
            nodes
            .Select(n => n.distance)
            .Max();
        
        return (maxDistance == Int32.MaxValue) ? -1 : maxDistance;
        
    }
    
    public int NetworkDelayTime(int[][] times, int n, int k) 
    {
        var k0 = k - 1;
        
        var adjacencyList0 = 
            Enumerable.Range(0, n)
            .Select(i => new List<(int,int)>())
            .ToArray();
        
        foreach(var edge in times)
        {
            var start = edge[0];
            var end = edge[1];
            var distance = edge[2];
            adjacencyList0[start-1].Add((end-1, distance));
        }
        
        var result = Dijikstra(adjacencyList0, n, k0);
        
        return result;
        
    }
}
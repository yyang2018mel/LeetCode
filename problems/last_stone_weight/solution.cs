public class Solution 
{
    public int LastStoneWeight(int[] stones) 
    {
        var maxHeap = 
            new PriorityQueue<int,int>(Comparer<int>.Create((lhs,rhs) => rhs-lhs));
        foreach(var stone in stones)
            maxHeap.Enqueue(stone, stone);
        
        while(maxHeap.Count >= 2)
        {
            var heaviest = maxHeap.Dequeue();
            var secondHeaviest = maxHeap.Dequeue();
            
            var net = Math.Abs(heaviest-secondHeaviest);
            
            if (net > 0)
                maxHeap.Enqueue(net, net);
        }
        
        maxHeap.TryDequeue(out var result, out _);
        return result;
        
    }
}
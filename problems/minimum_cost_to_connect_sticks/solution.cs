public class Solution 
{
    public int ConnectSticks(int[] sticks) 
    {
        var sticksWithLength =
            sticks
            .Select(stick => (stick, stick));
        
        var stickHeap = 
            new PriorityQueue<int, int>(sticksWithLength);
        
        var cost = 0;
        
        while(stickHeap.Count >= 2)
        {
            var shortest = stickHeap.Dequeue();
            var secondShortest = stickHeap.Dequeue();
            
            var connected = shortest + secondShortest;
            stickHeap.Enqueue(connected,connected);
            
            cost += connected;
        }
        
        return cost;
    }
}
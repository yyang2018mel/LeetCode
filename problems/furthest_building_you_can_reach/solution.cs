public class Solution 
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders) 
    {
        var ladderUsage = new PriorityQueue<int, int>(); // position, value
        
        for(var p = 1; p < heights.Length; p++)
        {
            var up = Math.Max(0, heights[p] - heights[p-1]);
            
            if (up > 0)
            {
                if (ladderUsage.Count < ladders)
                {
                    // just use
                    ladderUsage.Enqueue(p, up);
                }
                else if (ladderUsage.TryPeek(out _, out var val) && up > val)
                {
                    // swap a ladder usage for a  better value
                    ladderUsage.TryDequeue(out _, out var bricksNeeded);
                    ladderUsage.Enqueue(p, up);
                    
                    // use brick for the one that's swapped out
                    if (bricks >= bricksNeeded)
                        bricks -= bricksNeeded;
                    else
                        return p-1;
                }
                else
                {
                    if (bricks >= up)
                        bricks -= up;
                    else
                        return p-1;
                }
            }
        }
        
        return heights.Length-1;
    }
}
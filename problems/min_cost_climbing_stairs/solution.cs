public class Solution 
{
    
    public int MinCostClimbingStairsStart0(int[] augmentedCost)
    {
        var minCostArray = new int[augmentedCost.Length];
        
        for(var s = 0; s < minCostArray.Length; s++)
        {
            if (s <= 2) 
            {
                minCostArray[s] = 0;
                continue;
            }
            
            minCostArray[s] = Math.Min(
                minCostArray[s-1] + augmentedCost[s-1], // take 1 step from 1 step before
                minCostArray[s-2] + augmentedCost[s-2]  // take 2 steps from 2 steps before 
            );  
        }
        
        return minCostArray[minCostArray.Length-1];
    }
    
    
    public int MinCostClimbingStairs(int[] cost) 
    {
        var n = cost.Length;
        var augmentedCost = 
            Enumerable.Range(0, n+2)
            .Select(i => 
            {
                if (i == 0 || i == n+1) return 0;
                return cost[i-1];
            })
            .ToArray();
        
        return MinCostClimbingStairsStart0(augmentedCost);
    }
}
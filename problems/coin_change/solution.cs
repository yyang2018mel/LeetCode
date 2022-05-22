public class Solution // test case: [3,5] 49
{
    public int CoinChange(int[] coins, int amount) 
    {
        var solutions = new int[coins.Length+1, amount+1];
        
        for (var c = 0; c < coins.Length+1; c++)
        {
            for (var a = 0; a < amount+1; a++)
            {
                if (c == 0)
                {
                    solutions[c,a] = -1; 
                    continue;
                }
                else if (a == 0)
                {
                    solutions[c,a] = 0; 
                    continue;
                }
                else
                {
                    var useC = 
                        coins[c-1] > a
                        ? -1
                        : coins[c-1] == a 
                            ? 1 
                            : (solutions[c, a-coins[c-1]] >= 0 ? 1 + solutions[c, a-coins[c-1]] : -1);
                    
                    var notUseC =
                        solutions[c-1, a];
                    
                    if (useC == -1 && notUseC == -1)
                    {
                        solutions[c,a] = -1;
                    }
                    else if (useC != -1 && notUseC == -1)
                    {
                        solutions[c,a] = useC;
                    }
                    else if (useC == -1 && notUseC != -1)
                    {
                        solutions[c,a] = notUseC;
                    }
                    else
                    {
                        solutions[c,a] = Math.Min(useC, notUseC);
                    }
                }
            }
        }
        
        return solutions[coins.Length, amount];
    }
}
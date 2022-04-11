public class Solution 
{
    public int NumTrees(int n) 
    {
        if(n == 1) return 1;
        if(n == 2) return 2;
        
        var resultCache = new int[n+1];
        resultCache[1] = 1;
        resultCache[2] = 2;
        
        for(var m = 3; m <= n; m++)
        {
            var countM = 0;
            for(var head = 1; head <= m; head++)
            {
                var countLeft = Math.Max(1, resultCache[head-1]); // 1 ... head - 1
                var countRight = Math.Max(1, resultCache[m-head]); // head+1 ... n, which is equivalent to 1 ... n-head
                countM += countLeft*countRight;
            }
            resultCache[m] = countM;
        }
        
        return resultCache[n];
    }
}
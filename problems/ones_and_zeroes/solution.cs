public class Solution 
{
    
    private (int zeros, int ones) GetZerosAndOnes(string str)
    {
        var zeros = 0;
        var ones = 0;
        foreach(var c in str)
        {
            if (c == '0')
                zeros++;
            else
                ones++;
        }
        return (zeros, ones);
    }
    
    public int FindMaxForm(string[] strs, int m, int n) 
    {
        var dpReusable = new int[m+1,n+1];
        
        foreach(var str in strs)
        {
            var dpCopy = dpReusable.Clone() as int[,];
            var (zeros, ones) = GetZerosAndOnes(str);
            for(var z = 0; z <= m; z++)
            {
                for(var o = 0; o <= n; o++)
                {
                    var canInclude = 
                        z >= zeros && o >= ones;
                    if (canInclude)
                        dpReusable[z,o] = 
                            Math.Max(1+dpCopy[z-zeros, o-ones], dpCopy[z,o]);
                }
            } 
        }
        
        return dpReusable[m,n];
    }
}
public class Solution 
{
    private string CommonPrefix(string shorter, string equalOrLonger)
    {
        var common = "";
        for(var i = 0; i < shorter.Length; i++)
        {
            if (shorter[i] == equalOrLonger[i])
                common += shorter[i];
            else
                break;
        }
        
        return common;
    }
    
    public string LongestCommonPrefix(string[] strs) 
    {
        if (strs.Length == 0) return "";
        
        var common = strs[0];
        
        for(var idx = 1; idx < strs.Length; idx++)
        {
            common = 
                strs[idx].Length < common.Length
                ? CommonPrefix(strs[idx], common)
                : CommonPrefix(common, strs[idx]);   
        }
        
        return common;
    }
}
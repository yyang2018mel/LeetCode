
public class Solution 
{
    public int MissingNumber(int[] nums) 
    {
        var expectations = 
            new HashSet<int>(Enumerable.Range(0, nums.Length+1));
        
        foreach(var n in nums)
            expectations.Remove(n);
        
        return expectations.Single();
    }
}
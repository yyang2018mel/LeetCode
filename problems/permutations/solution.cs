public class Solution 
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var cache = new Dictionary<int, List<IList<int>>>();
        
        for(var c = 1; c <= nums.Length; c++)
        {
            if (c == 1)
            {
                var per = new List<int> { nums[c-1] };
                var result = new List<IList<int>> { per as IList<int> };
                cache.Add(c, result);
            }
            else
            {
                var prevResult = cache[c-1];
                var result = new List<IList<int>>();
                foreach(List<int> prevPer in prevResult)
                {
                    for(var i = 0; i <= prevPer.Count; i++)
                    {
                        var copy = new List<int>(prevPer);
                        
                        if (i - 1 >= 0 && prevPer[i-1] == nums[c-1])
                            continue;
                        
                        copy.Insert(i, nums[c-1]);
                        result.Add(copy as IList<int>);       
                    }
                }
                cache.Add(c, result);
            }
        }
        
        var final = cache[nums.Length];
        return final as IList<IList<int>>;
    }
}
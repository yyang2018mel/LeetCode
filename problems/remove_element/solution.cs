public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        Array.Sort(nums, (lhs, rhs) =>
        {

            var lhsDistToVal = Math.Abs(lhs - val);
            var rhsDistToVal = Math.Abs(rhs - val);

            if (lhsDistToVal == 0 && rhsDistToVal == 0)
            {
                return 0;
            }
            else if (lhsDistToVal == 0 && rhsDistToVal != 0)
            {
                return 1;
            }
            else if (lhsDistToVal != 0 && rhsDistToVal == 0)
            {
                return -1;
            }
            else
            {
                return lhs.CompareTo(rhs);
            }
        });

        var k = 0;
        for(var i = nums.Length-1; i >= 0; i--)
        {
            if (nums[i] != val) break;
            k++;
        }

        return nums.Length-k;
    }
}
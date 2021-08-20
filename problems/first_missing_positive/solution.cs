public class Solution
{

    private HashSet<int> positivesSeen = new HashSet<int>();
    private int firstMissingPositive = 1;

    public int FirstMissingPositive(int[] nums)
    {
        foreach(var num in nums)
        {
            if (num <= 0) continue;

            positivesSeen.Add(num);

            if (num == firstMissingPositive)
            {
                do
                {
                    firstMissingPositive++;
                }
                while (positivesSeen.Contains(firstMissingPositive));   
            }
        }
        return firstMissingPositive;
    }
}
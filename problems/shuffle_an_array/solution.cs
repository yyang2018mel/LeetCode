public class Solution {

        int[] original;
        Random rnd = new Random(1);

        public Solution(int[] nums)
        {
            original = nums;
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return original;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            int[] mutable = new int[original.Length];
            original.CopyTo(mutable, 0);
            for (int i = 0; i < original.Length; i++)
            {
                var j = rnd.Next(i, original.Length);
                (mutable[i], mutable[j]) = (mutable[j], mutable[i]);
            }
            return mutable;
        }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */
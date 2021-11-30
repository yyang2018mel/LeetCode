public class Solution {
    public int Reverse(int x)
        {
            var exp_arr = new int[10];
            var base_arr = new int[10];
            var cut = 9;
            var stopCut = false;
            for (var i = cut; i >= 0; i--)
            {
                var base_ = (int)Math.Pow(10, i);
                base_arr[i] = base_;

                var div = x / base_;
                if (x != 0 && div == 0 && !stopCut)
                {
                    cut--;
                    continue;
                }
                stopCut = true;
                exp_arr[i] = div;
                x = x % base_;
            }

            var reversed = 0;
            for (var i = 0; i <= cut; i++)
            {
                var prod = exp_arr[i] * base_arr[cut - i];

                // handle overflow
                if (prod / base_arr[cut - i] != exp_arr[i]) return 0;

                var reversed_copy = reversed;
                reversed = reversed_copy + prod;
                // handle overflow

                if (reversed!= 0 && reversed_copy!=0 && Math.Sign(reversed) != Math.Sign(reversed_copy)) return 0;
            }

            return reversed;
        }
}
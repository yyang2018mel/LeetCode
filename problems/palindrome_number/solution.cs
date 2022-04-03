public class Solution
{
    public bool IsPalindrome(int x)
    {

        // handle negative numbers
        if (x < 0) return false;

        // handle multiples of 10, e.g. 0, 10, 100
        if (x % 10 == 0) return x == 0;

        // handle other positive numbers
        var remX = x;
        var inversedHalf = 0;
        while (remX > inversedHalf)
        {
            inversedHalf = inversedHalf * 10 + remX % 10;
            remX = remX / 10;
        }
        return remX == inversedHalf // even digits
                || remX == inversedHalf / 10; // odd digits
    }
}

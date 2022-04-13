/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl 
{

    private int FirstBadness(int start, int end)
    {
        var hunch = start+(end-start)/2;
        
        var isBadness = IsBadVersion(hunch);
        
        if(isBadness)
        {
            if(hunch == 0 || !IsBadVersion(hunch-1))
                return hunch;
            return FirstBadness(start, hunch); // keep searching leftward
        }
        else
        {
            return FirstBadness(hunch+1, end); // keep searching rightward
        }
    }

    public int FirstBadVersion(int n) 
    {
        return FirstBadness(1,n);
    }
}
public class Solution 
{
    private int NumberOfSteps(int num, int stepsSoFar)
    {
        if (num == 0) return stepsSoFar;
        
        if (num % 2 == 0)
            return NumberOfSteps(num/2, stepsSoFar+1);
        else
            return NumberOfSteps(num-1, stepsSoFar+1);
    }
    
    public int NumberOfSteps(int num) 
    {
        return NumberOfSteps(num, 0);    
    }
}
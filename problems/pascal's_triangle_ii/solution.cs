public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var arr = new int[rowIndex+1];
        
        if(rowIndex == 0)
        {
            arr[0] = 1;
            return arr.ToList();
        }
        
        if(rowIndex == 1)
        {
            arr[0] = 1;
            arr[1] = 1;
            return arr.ToList();
        }
        
        var upper = GetRow(rowIndex-1).ToArray();
        
        for(var i = 0; i <= rowIndex; i++ )
        {
            if (i == 0) 
                arr[i] = 1;
            else if (i == rowIndex) 
                arr[i] = 1;
            else
                arr[i] = upper[i-1] + upper[i];
            
        }
        return arr.ToList();
        
    }
}
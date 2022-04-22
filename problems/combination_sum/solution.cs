public class Solution 
{
    private List<List<int>>[,] _solutionMatrix;
    
    private void InitializeSolutionMatrix(int numRows, int numCols)
    {
        _solutionMatrix = new List<List<int>>[numRows, numCols];
        
        for (var i = 0; i < numCols; i++)
            _solutionMatrix[0,i] = new List<List<int>>();
        for (var j = 0; j < numRows; j++)
            _solutionMatrix[j,0] = new List<List<int>>();
    }
    
    private void PopulateByDynamicProgramming(int[] candidates)
    {
        var numRows = _solutionMatrix.GetLength(0);
        var numCols = _solutionMatrix.GetLength(1);
        
        for(var n = 1; n < numRows; n++)
        {
            var nthItem = candidates[n-1];
            for (var t = 1; t < numCols; t++)
            {
                var withNth = 
                    t == nthItem
                    ? new List<List<int>> { new List<int> { nthItem } }
                    : (t < nthItem 
                       ? new List<List<int>> ()
                       : _solutionMatrix[n, t-nthItem]
                         .Select(comb => 
                         { 
                             var combCp = new List<int>(comb);
                             combCp.Add(nthItem);
                             return combCp;
                         })
                         .ToList());
                var withoutNth = 
                    _solutionMatrix[n-1, t];
                
                _solutionMatrix[n,t] = withNth.Concat(withoutNth).ToList();
            }
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        InitializeSolutionMatrix(candidates.Length+1, target+1);
        PopulateByDynamicProgramming(candidates);

        var result = _solutionMatrix[candidates.Length, target];
        
        var iresult = 
            result
            .Select(comb => comb as IList<int>)
            .ToList();

        return iresult as IList<IList<int>>;
    }
}
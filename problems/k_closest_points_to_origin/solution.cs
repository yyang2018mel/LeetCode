public class Solution 
{
    private int _k;
    
    private PriorityQueue<int, double> _kClosestPoints;
    
    private void AddOrUpdateKClosestPoints(int p, double distance)
    {
        if (_kClosestPoints.Count < _k)
        {
            _kClosestPoints.Enqueue(p, distance);
        }
        else if (_kClosestPoints.TryPeek(out _, out var kthDistanceMaybe) && kthDistanceMaybe > distance)
        {
            _kClosestPoints.Dequeue();
            _kClosestPoints.Enqueue(p, distance);
        }
    }
    
    public int[][] KClosest(int[][] points, int k) 
    {
        _k = k;
        _kClosestPoints = 
            new PriorityQueue<int, double>(Comparer<double>.Create((lhs, rhs) => 
                   {
                       if (rhs == lhs) return 0;
                       return lhs < rhs ? 1 : -1;
                   })); // max-heap
        
        for(var i = 0; i < points.Length; i++)
        {
            var px= points[i][0];
            var py = points[i][1];
            var euclidean = Math.Sqrt(px*px+py*py);
            
            AddOrUpdateKClosestPoints(i, euclidean);
        }
        
        var result = 
            _kClosestPoints.UnorderedItems
            .Select(item => points[item.Item1])
            .ToArray();
        
        return result;
    }
}
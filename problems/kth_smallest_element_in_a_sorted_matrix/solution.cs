public class Solution 
{
    internal record Pointer(int r, int c);
    
    public int KthSmallest(int[][] matrix, int k) 
    {
        var numRow = matrix.Length;
        var numCol = matrix[0].Length;
        
        var minHeap = new PriorityQueue<Pointer, int>();
        for(var i = 0; i < numRow; i++)
        {
            minHeap.Enqueue(new Pointer(i,0), matrix[i][0]);
        }
    
        var kthMin = 0;
        for(var count =  1; count <= k; count++)
        {
            var minPointer = minHeap.Dequeue();
            
            if (count == k) 
            {
                kthMin = matrix[minPointer.r][minPointer.c];
                break;
            }
            
            if (minPointer.c < numCol-1)
            {
                var newPointer = minPointer with { c = minPointer.c + 1 };
                var newPriority = matrix[newPointer.r][newPointer.c];
                minHeap.Enqueue(newPointer, newPriority);    
            }   
        }
        
        return kthMin;
    }
}

internal static class MatrixExtensions
{
    internal static int[,] Clone(this int[][] matrix, int numRows, int numCols)
    {
        var copy = new int[numRows,numCols];
        for(var i = 0; i < numRows; i++)
        {
            for(var j = 0; j < numCols; j++)    
            {
                copy[i,j] = matrix[i][j];
            }
        }
        return copy;
    }
}

public class Solution 
{
    private int[,] immutableState;
    private int numRows;
    private int numCols;
    
    private IEnumerable<(int,int)> GetNeighbours(int i, int j)
    {
        bool ValidCoordinate(int i, int j)
        {
            return
                i >= 0 &&
                i < numRows &&
                j >= 0 &&
                j < numCols;
        }
        
        var candidateNeighbours = 
            new List<(int, int)>()
            {
                (i-1,j-1),
                (i-1,j),
                (i-1,j+1),
                (i,j-1),
                (i,j+1),
                (i+1,j+1),
                (i+1,j),
                (i+1,j-1)
            };
        
        var validNeighbours = 
            candidateNeighbours
            .Where(coord => ValidCoordinate(coord.Item1,coord.Item2));
        
        return validNeighbours;
    }
    
    public void GameOfLife(int[][] board) 
    {
        numRows = board.Length;
        numCols = board[0].Length;
        immutableState = board.Clone(numRows, numCols);
        
        for(var i = 0; i < numRows; i++)
        {
            for(var j = 0; j < numCols; j++)
            {
                var coord = (i,j);
                var neighbours = GetNeighbours(i,j);
                var liveNeighbours = 
                    neighbours
                    .Select(coord => immutableState[coord.Item1,coord.Item2])
                    .Sum();
                
                if(immutableState[i,j] == 0) // currently dead
                {
                    if (liveNeighbours == 3)
                        board[i][j] = 1;
                }
                else // currently alive
                {
                    if (liveNeighbours < 2)    
                        board[i][j] = 0;
                    else if (liveNeighbours == 2 || liveNeighbours == 3)
                        board[i][j] = 1;
                    else
                        board[i][j] = 0;
                }
            }
        }
    }
}


















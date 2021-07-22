public class Solution {
    enum Direction { Vertical, UpRight }

    private static int[,] StringToMatrix(string s, int numRows)
    {
        var matrix = new int[numRows, s.Length];

        var rowPointer = 0;
        var colPointer = 0;
        var state = Direction.Vertical;

        for(int i = 0; i < s.Length; i++)
        {
            matrix[rowPointer, colPointer] = i;

            // update matrix pointer
            rowPointer = state == Direction.Vertical
                                  ? rowPointer + 1
                                  : rowPointer - 1;

            colPointer = state == Direction.Vertical
                                  ? colPointer
                                  : colPointer + 1;

            // update state
            if (state == Direction.Vertical && rowPointer == (numRows - 1))
                state = Direction.UpRight;
            else if (state == Direction.UpRight && rowPointer == 0)
                state = Direction.Vertical;
        }

        return matrix;
    }

    private static string MatrixToZigZaged(int[,] idxMatrix, string original, int numRows) 
    {
        char[] zigzaged = new char[original.Length];
        var arrPointer = 0;

        for(int r = 0; r < numRows; r++)
        {
            for(int c = 0; c < original.Length; c++)
            {
                if(idxMatrix[r,c] == 0)
                {
                    if (r == 0 && c == 0)
                    {
                        zigzaged[arrPointer] = original[idxMatrix[r, c]];
                        arrPointer++;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    zigzaged[arrPointer] = original[idxMatrix[r, c]];
                    arrPointer++;
                }
            }
        }

        return new String(zigzaged);
    }

    public string Convert(string s, int numRows)
    {
        if(numRows == 1)
            return s;
        var matrix   = StringToMatrix(s, numRows);
        var zigZaged = MatrixToZigZaged(matrix, s, numRows);

        return zigZaged;
    }
}
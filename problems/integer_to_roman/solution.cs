public class Solution   
    {

        //readonly Dictionary<int, string> mapping = new Dictionary<int, string>()

        private int[] pivots = new int[] { 1000, 100, 10, 1 };
        private Dictionary<int, string> mapping =
            new Dictionary<int, string>() {
            { 1,    "I" },
            { 5,    "V" },
            { 10,   "X" },
            { 50,   "L" },
            { 100,  "C" },
            { 500,  "D" },
            { 1000, "M" }
        };


        public string IntToRoman(int residual, int iPivot, string roman)
        {
            var pivot = pivots[iPivot];

            if (residual == 0)
            {
                return roman;
            }

            var thisRoman = "";
            var remainder = 0;
            var multiple = residual / pivot;
            var nextPivotIdx = Math.Min(iPivot + 1, pivots.Length - 1);

            if (multiple == 0)
            {
                return IntToRoman(residual, nextPivotIdx, roman);
            }

            else if (multiple == 4)
            {
                thisRoman = mapping[pivot] + mapping[pivot * 5];
                remainder = residual - pivot * multiple;
            }
            
            else if (multiple == 9)
            {
                thisRoman = mapping[pivot] + mapping[pivot * 10];
                remainder = residual - pivot * multiple;
            }

            else if (multiple >= 5)
            {
                thisRoman = mapping[pivot * 5];
                remainder = residual - pivot * 5;

                if (multiple > 5)
                    nextPivotIdx = iPivot;
            }

            else if (multiple != 0)
            {
                for (var i = 0; i < multiple; i++)
                    thisRoman += mapping[pivot];
                remainder = residual - pivot * multiple;
                
            }

            return IntToRoman(remainder, nextPivotIdx, roman + thisRoman);
        }

        public string IntToRoman(int num)
        {
            return IntToRoman(num, 0, "");
        }
    }
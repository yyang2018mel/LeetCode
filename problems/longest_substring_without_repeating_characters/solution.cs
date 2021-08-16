public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == "") return 0;

            var rear = 0;
            var front = rear + 1;
            var tempSet = new HashSet<char> { s[rear] };
            var maxLen = 1;

            while (rear < s.Length & front < s.Length)
            {
                if (tempSet.Add(s[front]))
                {
                    front++;
                    maxLen = System.Math.Max(maxLen, tempSet.Count);
                }
                else if(s[rear] == s[front])
                {
                    rear += 1;
                    front += 1;
                }
                else
                {
                    while (s[rear] != s[front])
                    {
                        tempSet.Remove(s[rear]);
                        rear++;
                    }
                        
                    rear += 1;
                    front += 1;
                }
                
            }
            return maxLen;
        }
    }
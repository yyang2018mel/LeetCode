public class Solution {
    public int MyAtoi(string s)
        {
            var queue = new Queue<int>();
            int pointer = 0;
            int? sign_ = null;

            while(pointer < s.Length)
            {
                if (s[pointer] == ' ')
                {
                    if (sign_.HasValue) break;

                    pointer++;
                    continue;
                }

                if (Int32.TryParse(s.AsSpan(pointer,1), out var i))
                {
                    queue.Enqueue(i);
                    if (!sign_.HasValue)
                        sign_ = 1;
                }
                else
                {
                    if (sign_.HasValue) break;
                        
                    sign_ =
                        s[pointer] switch
                        {
                            '+' => 1,
                            '-' => -1,
                            _ => sign_
                        };

                    if (!sign_.HasValue) break;
                }
                pointer++;
            }

            var value = 0;
            while(queue.Count != 0)
            {
                var multiplier = (int)Math.Pow(10, queue.Count - 1);
                var coefficient = sign_.Value * queue.Dequeue();

                var prod = multiplier * coefficient;

                // overflow check
                if (prod / multiplier != coefficient)
                    return sign_ > 0 ? Int32.MaxValue : Int32.MinValue;

                value += prod;

                // overflow check
                if (value != 0 && Math.Sign(value) != sign_)
                    return sign_ > 0 ? Int32.MaxValue : Int32.MinValue;
            }

            return value;
        }
}
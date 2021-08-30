using System.Linq;

public class Solution
{
    public static bool IsSubsequence(string candidate, string template)
    {
        if (candidate.Length > template.Length) return false;

        if (candidate == "") return true;

        var idxCandidate = 0;
        var idxTemplate = 0;

        while(idxCandidate < candidate.Length)
        {
            var c = candidate[idxCandidate];
            var matched = false;
            while (idxTemplate < template.Length)
            {
                if (c == template[idxTemplate++])
                {
                    matched = true;
                    break;
                }
            } 

            if (matched)
                idxCandidate++;
            else
                break;
        }

        return idxCandidate == candidate.Length;

    }

    public int FindLUSlength(string[] strs)
    {
        var lusLen = -1;

        strs = strs.OrderBy(s => s.Length).ThenBy(s => s).ToArray();

        var subject = 0;
        while (subject < strs.Length)
        {
            var next = subject + 1;
            while(next < strs.Length && strs[subject] == strs[next])
            {
                next++;
            }

            if(next != subject + 1)
            {
                // duplicate
                subject = next;
                continue;
            }
            else
            {
                // no duplicate
                var findSub = false;
                var candidate = next;
                while (candidate < strs.Length)
                {
                    var isSub = IsSubsequence(strs[subject], strs[candidate]);

                    if (isSub)
                    {
                        findSub = true;
                        break;
                    }
                    else
                    {
                        candidate += 1;
                    }
                }

                if (findSub)
                {
                    subject += 1;
                }
                else
                {
                    lusLen = System.Math.Max(lusLen, strs[subject].Length);
                    subject += 1;
                }
            }
        }
        return lusLen;
    }
}
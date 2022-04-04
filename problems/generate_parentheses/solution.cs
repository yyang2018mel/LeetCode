public record ParenthesisGroup(
    ParenthesisGroup? Offspring = null,
    ParenthesisGroup? LeftSibling = null,
    ParenthesisGroup? RightSibling = null)
{
    private bool HasNoSiblings()
    {
        return LeftSibling == null && RightSibling == null;
    }

    public List<ParenthesisGroup> GetChoicesIfAddOneToOffspringGroup()
    {
        if(this.Offspring == null)
        {
            return new List<ParenthesisGroup>
            {
                this with { Offspring = new ParenthesisGroup() }
            };
        }
        else
        {
            // let my kid to have kid
            var grandkid = this.Offspring.GetChoicesIfAddOneToOffspringGroup();
            // let my kid to have silbing
            var otherkid = this.Offspring.GetChoicesIfAddOneToSiblingGroup();
            return
                grandkid.Concat(otherkid)
                .Select(c => this with { Offspring = c })
                .ToList();
        }
    }

    public List<ParenthesisGroup> GetChoicesIfAddOneToSiblingGroup()
    {
        if (HasNoSiblings())
        {
            if(Offspring == null)
            {
                return new List<ParenthesisGroup>
                {
                    this with {RightSibling = new ParenthesisGroup()}
                };
            }
            else
            {
                return new List<ParenthesisGroup>
                {
                    this with { LeftSibling = new ParenthesisGroup() },
                    this with { RightSibling = new ParenthesisGroup() }
                };
            }
        }
        else if(LeftSibling == null)
        {
            var l = this with { LeftSibling = new ParenthesisGroup() };
            var rr = RightSibling.GetChoicesIfAddOneToSiblingGroup()
                    .Select(e => this with { RightSibling = e });
            var ro = RightSibling.GetChoicesIfAddOneToOffspringGroup()
                    .Select(c => this with { RightSibling = c });
            var rs =
                ro
                .Append(l)
                .Concat(rr);

            return rs.ToList();
        }

        else if (RightSibling == null)
        {
            var r = this with { RightSibling = new ParenthesisGroup() };
            var ll = LeftSibling.GetChoicesIfAddOneToSiblingGroup()
                    .Select(c => this with { LeftSibling = c });
            var lo = LeftSibling.GetChoicesIfAddOneToOffspringGroup()
                    .Select(c => this with { LeftSibling = c });
            var ls =
                lo
                .Append(r)
                .Concat(ll);
            return ls.ToList();
        }
        else
        {
            var ls =
                LeftSibling.GetChoicesIfAddOneToOffspringGroup()
                .Select(c => this with { LeftSibling = c });
            var rs =
                RightSibling.GetChoicesIfAddOneToOffspringGroup()
                .Select(c => this with { RightSibling = c });

            return ls.Concat(rs).ToList();
        }
    }

    public override string ToString()
    {
        if (HasNoSiblings() && Offspring == null)
            return "()";

        return $"{LeftSibling}({Offspring}){RightSibling}";
    }
}

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var baselines = new List<ParenthesisGroup> { new ParenthesisGroup() };
        for(var i = 2; i <= n; i++)
        {
            var nextGen = new List<ParenthesisGroup>();
            foreach(var p in baselines)
            {
                nextGen.AddRange(p.GetChoicesIfAddOneToOffspringGroup());
                nextGen.AddRange(p.GetChoicesIfAddOneToSiblingGroup());
            }

            baselines = nextGen;
        }

        var result =
            baselines
            .Select(e => e.ToString())
            .ToHashSet()
            .ToList();

        return result;
    }
}
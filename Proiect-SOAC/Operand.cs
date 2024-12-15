namespace Proiect_SOAC;

public class Operand
{
    public string immediateValue { get; set; } = string.Empty;
    public string reg1 { get; set; } = string.Empty;
    public string reg2 { get; set; } = string.Empty;
    public int? preOffset { get; set; } = null;
    public int? postOffset { get; set; } = null;

    public override string ToString()
    {
        if (preOffset != null)
        {
            if (preOffset != 0 && !reg2.Equals(string.Empty))
            {
                return $"{preOffset.ToString()}({reg1}, {reg2})";
            }
            else if (!reg2!.Equals(string.Empty))
            {
                return $"({reg1}, {reg2})";
            }
            else if (preOffset != 0)
            {
                return $"{preOffset.ToString()}({reg1})";
            }
            else
            {
                return $"({reg1})";
            }
        }
        else if (!reg1.Equals(string.Empty))
        {
            if (postOffset != null)
            {
                return $"{reg1} ({postOffset})";
            }
            return reg1;
        }
        else
        {
            if (postOffset != null)
            {
                return $"{immediateValue}+{postOffset}";
            }
            return immediateValue;
        }
    }
}

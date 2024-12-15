namespace Proiect_SOAC;

public class Instruction : Line
{
    public string label { get; set; } = default!;
    public string instruction { get; set; } = default!;
    public IList<Operand> operands { get; set; } = new List<Operand>();

    public string getInstruction()
    {
        return instruction;
    }

    public IList<Operand> getOperands()
    {
        return operands;
    }
    public override string ToString()
    {
        string value = string.Empty;
        value += label == default! ? string.Empty : label + " ";
        value += instruction + " ";
        int index = 0;
        foreach (Operand operand in operands)
        {
            value += operand.ToString();
            if (++index < operands.Count) 
            { 
                value += ", ";
            }
        }
        return value + "\r\n";
    }
}

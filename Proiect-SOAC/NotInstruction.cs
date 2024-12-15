namespace Proiect_SOAC;

public class NotInstruction : Line
{
    public string value { get; set; } = default!;

    public override string ToString()
    {
        return value + "\r\n";
    }
}

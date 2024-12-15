namespace Proiect_SOAC
{
    public interface Line
    {
        public string getInstruction()
        {
            return "";
        }

        public IList<Operand> getOperands()
        {
            return new List<Operand>();
        }
    }
}

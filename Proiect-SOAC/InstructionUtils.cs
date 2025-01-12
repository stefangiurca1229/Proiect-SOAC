namespace Proiect_SOAC
{
    public class InstructionUtils
    {
        public static bool isInstruction(string element)
        {
            if (element.EndsWith('!'))
                element = element.Remove(element.Length - 1);
            return Enum.TryParse(typeof(InstructionSet), element.ToUpper(), out _);
        }

        public static bool isRegister(string element)
        {
            if (element.Equals(string.Empty)) return false;
            if (Enum.TryParse(typeof(RegisterSet), element.ToUpper()[0].ToString(), out _)) return true;
            if (element.ToUpper().StartsWith(RegisterSet.R.ToString()) || element.ToUpper().StartsWith(RegisterSet.B.ToString()))
            {
                var registerNumber = element.Remove(1);
                var isNumeric = int.TryParse(registerNumber, out _);
                if (isNumeric) return true;
            }
            return false;
        }
    }
}

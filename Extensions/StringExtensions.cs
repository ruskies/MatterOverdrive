using System.Collections.Generic;

namespace MatterOverdrive.Extensions
{
    public static class StringExtensions
    {
        public static List<string> FirstEverySeparator(this string inputLine, char separator = ';', params char[] trimStart)
        {
            string[] splitInput = inputLine.Split(separator);
            List<string> firsts = new List<string>(splitInput.Length);

            for (int i = 0; i < splitInput.Length; i++)
                firsts.Add(splitInput[i].TrimStart(trimStart));

            return firsts;
        }
    }
}
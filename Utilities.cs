using System.Collections.Generic;
using System.Text;

namespace MatterOverdrive
{
    public static class Utilities
    {
        public static List<string> ParseLine(this string line, char seperator = '"')
        {
            List<string> args = new List<string>();

            StringBuilder sb = new StringBuilder();
            bool dividedArg = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == seperator)
                {
                    dividedArg = !dividedArg;

                    if (!dividedArg)
                    {
                        args.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                else if (c == ' ' && !dividedArg)
                {
                    args.Add(sb.ToString());
                    sb.Clear();
                }
                else
                    sb.Append(c);
            }

            if (sb.Length > 0)
                args.Add(sb.ToString());

            return args;
        }
    }
}
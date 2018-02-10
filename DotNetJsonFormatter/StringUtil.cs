using System.Text;

namespace DotNetJsonFormatter
{
    public static class StringUtil
    {
        public static string ReplaceNewLines(string s, char newLineSubstitutionChar = '\0')
        {
            // TODO 
            // there may be a built-in function that will accomplish this 
            // once back online, do a search
            StringBuilder r = new StringBuilder();

            foreach (char c in s)
            {
                if ((c == '\n'))
                {
                    if (newLineSubstitutionChar != '\0')
                    {
                        r.Append(newLineSubstitutionChar);
                    }
                }
                else
                {
                    r.Append(c);
                }
            }

            return r.ToString();
        }

        public static string HandleSpecialCharsForCsv(string s)
        {
            // this tries to mimic what Excel does
            // if the string contains either a comma or a double quote
            // then duplicate each double quote and then
            // put everything inside of double quotes
            // otherwise do nothing
            if (s.Contains(",") || s.Contains("\""))
            {
                StringBuilder sb = HandleEmbeddedQuotes(s);
                sb.Insert(0, '"');
                sb.Append('"');
                s = sb.ToString();
            }

            return s;
        }

        public static StringBuilder HandleEmbeddedQuotes(string s)
        {
            StringBuilder r = new StringBuilder();

            foreach (char c in s)
            {
                if (c == '"')
                {
                    r.Append('"');
                }

                r.Append(c);
            }

            return r;
        }
    }
}
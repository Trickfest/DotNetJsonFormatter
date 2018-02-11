using System.Text;

namespace DotNetJsonFormatter
{
    public static class StringUtil
    {
        public static string ReplaceNewLines(string s, char newLineSubstitutionChar = '\0')
        {
            string replacement = (newLineSubstitutionChar == '\0') ?
                string.Empty :
                new string(newLineSubstitutionChar, 1);

            return s.Replace("\n", replacement);
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
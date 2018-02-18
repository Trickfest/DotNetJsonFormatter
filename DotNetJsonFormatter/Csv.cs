using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using static System.Console;
using System.Collections.Generic;
using System.Globalization;
using static DotNetJsonFormatter.StringUtil;

namespace DotNetJsonFormatter
{
    public static class Csv
    {
        public static string Json2Csv(string jsonArray, bool useTitleCase = true, char newLineSubstitutionChar = ' ')
        {
            bool writeHeader = true;
            StringBuilder result = new StringBuilder();

            var ci = new CultureInfo("en-US");

            JArray jArray = JArray.Parse(jsonArray);

            foreach (JObject jObject in jArray)
            {
                StringBuilder header = new StringBuilder();
                StringBuilder row = new StringBuilder();

                foreach (JProperty jProperty in jObject.Children())
                {
                    if (writeHeader)
                    {
                        var fixedHeader = ReplaceNewLines(jProperty.Name, newLineSubstitutionChar);

                        if(useTitleCase){
                            fixedHeader = ci.TextInfo.ToTitleCase(fixedHeader);
                        }

                        header.Append(HandleSpecialCharsForCsv(fixedHeader)).Append(',');
                    }

                    row.Append(HandleSpecialCharsForCsv(ReplaceNewLines(jProperty.First.ToString(), newLineSubstitutionChar))).Append(',');
                }

                if (writeHeader)
                {
                    writeHeader = false;
                    header[header.Length - 1] = '\n'; // overwrite trailing comma with newline
                    result.Append(header);
                }

                row[row.Length - 1] = '\n'; // overwrite trailing comma with newline
                result.Append(row);
            }

            return result.ToString();
        }
    }
}
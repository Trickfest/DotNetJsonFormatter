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
    public static class AsciiTable
    {
        public static string Json2Table(string jsonarray,
            bool useTitleCase = true,
            int headerPadding = 2,
            int columnPadding = 2,
            char newLineSubstitutionChar = ' ')
        {
            List<string> headerRow = new List<string>();
            List<int> columnWidths = new List<int>();
            List<List<string>> tableData = new List<List<string>>();

            ProcessData(jsonarray, headerRow, columnWidths, tableData, useTitleCase, headerPadding, newLineSubstitutionChar);

            return CreateTable(headerRow, columnWidths, tableData, columnPadding);
        }

        private static bool ProcessData(string jsonarray,
            List<string> headerRow,
            List<int> columnWidths,
            List<List<string>> tableData,
            bool useTitleCase,
            int headerPadding,
            char newLineSubstitutionChar)
        {
            bool handleHeader = true;

            var jsonLoadSettings = new JsonLoadSettings();
            jsonLoadSettings.CommentHandling = CommentHandling.Ignore;

            JArray jArray = JArray.Parse(jsonarray, jsonLoadSettings);

            var ci = new CultureInfo("en-US");

            for (int i = 0; i < jArray.Count; i++)
            {
                List<string> rowData = new List<string>();

                int j = 0;
                foreach (JProperty jProperty in jArray[i].Children())
                {
                    if (handleHeader)
                    {                        
                        string header = ReplaceNewLines(jProperty.Name, newLineSubstitutionChar);

                        if(useTitleCase){
                            header = ci.TextInfo.ToTitleCase(header);
                        }

                        headerRow.Add(header);
                        columnWidths.Add(header.Length + headerPadding);
                    }

                    var fixedRow = ReplaceNewLines(jProperty.First.ToString(), newLineSubstitutionChar);

                    rowData.Add(fixedRow);

                    if (fixedRow.Length + headerPadding > columnWidths[j])
                    {
                        columnWidths[j] = fixedRow.Length + headerPadding;
                    }

                    j++;
                }

                tableData.Add(rowData);
                handleHeader = false;
            }

            return handleHeader;
        }

        private static string CreateTable(List<string> headerRow,
            List<int> columnWidths,
            List<List<string>> tableData,
            int columnPadding)
        {
            var headerString = new StringBuilder();
            var dashString = new StringBuilder();
            var table = new StringBuilder();

            for (int i = 0; i < headerRow.Count; i++)
            {
                headerString.Append(headerRow[i].PadRight(columnWidths[i], ' ')).Append(' ', columnPadding);
                dashString.Append('-', columnWidths[i]).Append(' ', columnPadding);
            }

            table.Append(headerString).Append('\n');
            table.Append(dashString).Append('\n');

            var rowString = new StringBuilder();

            for (int i = 0; i < tableData.Count; i++)
            {
                for (int j = 0; j < tableData[i].Count; j++)
                {
                    rowString.Append(tableData[i][j].PadRight(columnWidths[j], ' ')).Append(' ', columnPadding);
                }

                table.Append(rowString).Append('\n');
                rowString.Clear();
            }

            return table.ToString();
        }

    }
}
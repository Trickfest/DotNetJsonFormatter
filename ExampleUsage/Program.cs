using System;
using System.Collections.Generic;
using static System.Console;
using static DotNetJsonFormatter.AsciiTable;
using static DotNetJsonFormatter.Csv;

namespace ExampleUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sampleData = new List<string>();

            sampleData.Add("[{\"person id\":1,\"name\":\"O\\\"Miley\",\"created date\":\"12/9/2017 8:01:52 PM\"},{\"person id\":2,\"name\":\"Sally\",\"createdDate\":\"12/9/2017 8:01:52 PM\"},{\"person id\":3,\"name\":\"Jackie\",\"createdDate\":\"12/9/2017 8:01:52 PM\"},{\"person id\":4,\"name\":\"Freddie\",\"createdDate\":\"12/9/2017 8:01:52 PM\"},{\"person id\":5,\"name\":\"McMaster\",\"createdDate\":\"12/9/2017 8:01:52 PM\"}]");

            sampleData.Add(@"[{CPU: 'Intel',Drives: ['DVD read/writer','500 gigabyte hard drive']}]");

            foreach (string jsonarray in sampleData)
            {
                WriteLine("*********** ASCII TABLE **********");

                var table = Json2Table(jsonarray, true, 2, 2, '\0');
                Write(table);

                WriteLine("*********** CSV **********");

                var csv = Json2Csv(jsonarray, true, '\0');
                Write(csv);
            }
        }
    }
}

using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Dynamic;
using CsvHelper;

namespace lab4
{
    class AppMain
    {
        static void Main()
        {
            using (WebScanner scanner = new())
            {
                string fileName = "result.csv";
                StreamWriter streamWriter = new(fileName);

                CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture);
                streamWriter.WriteLine("sep=,");

                scanner.EmailsFound += (page, emails) =>
                {
                    Console.WriteLine($"Page:");
                    Console.WriteLine($"        {page}");
                    Console.WriteLine($"Emails:");
                    foreach (string email in emails)
                    {
                        Console.WriteLine($"        {email}");
                    }
                    Console.Write('\n');
                };

                scanner.EmailsFound += (page, emails) =>
                {
                    dynamic record = new ExpandoObject();
                    record.Page = page.ToString();

                    string e = string.Empty;
                    foreach (string email in emails)
                    {
                        e += email + '\n';
                    }
                    record.Emails = e;

                    List<dynamic> records = new();
                    records.Add(record);
                    csvWriter.WriteRecords(records);
                };

                Console.WriteLine("Web Scanner started.");
                scanner.Scan(new Uri("https://www.susu.ru/"), 10);
                Console.WriteLine($"Done! Data write in {fileName} file.");

                csvWriter.Dispose();
                streamWriter.Dispose();
            }
        }
    }
}


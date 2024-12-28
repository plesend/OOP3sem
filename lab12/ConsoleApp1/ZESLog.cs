using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ZESLogRecord
    {
        public string FileName { get; set; }
        public string LogFilePath { get; set; }
        public string Action { get; set; }
        public DateTime Date{ get; set; }
    }
    public static class ZESLog
    {
        public const string _filePath = @"D:\лабораторные\ооп\lab12\ConsoleApp1\logFile.json";

        public static void WriteLog(string fileName, string logFilePath, string action)
        {
            var record = new { Action = action, FileName = fileName, LoFilePath = logFilePath, Date = DateTime.Now };
            

            List<object> records = new List<object>();
            string text = File.ReadAllText(_filePath);
            if (string.IsNullOrEmpty(text) == false)
            {
                if (JsonSerializer.Deserialize<List<object>>(text) == null)
                {
                    records = new List<object>();
                }
                else { records = JsonSerializer.Deserialize<List<object>>(text); }
            }
            records.Add(record);
            string result = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            File.WriteAllText(_filePath, result, System.Text.Encoding.UTF8);
        }
        public static void ReadLog()
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string tmp;
                while ((tmp = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{tmp}");
                }
            }
        }
        public static void SearchLogByAction(string action)
        {
            string jsonrecords = File.ReadAllText(_filePath);
            List<ZESLogRecord> recs = new List<ZESLogRecord>();
            recs = JsonSerializer.Deserialize<List<ZESLogRecord>>(jsonrecords);

            foreach (var record in recs)
            {
                if (record.Action == action)
                {
                    Console.WriteLine($"action: {record.Action}, filename: {record.FileName}, filepath: {record.LogFilePath}, date: {record.Date}");

                }
            }
        }
        public static void SearchByTimeRange(DateTime start, DateTime end)
        {
            int counter = 0;
            string jsonrecs = File.ReadAllText(_filePath);
            List<ZESLogRecord> recs = new List<ZESLogRecord>();
            recs = JsonSerializer.Deserialize<List<ZESLogRecord>>(jsonrecs);

            foreach (var rec in recs)
            {
                Console.WriteLine($"action: {rec.Action}, filename: {rec.FileName}, filepath: {rec.LogFilePath}, date: {rec.Date}");
                counter++;
            }
            Console.WriteLine("There are writings: ");
        }

        public static void RemoveOldLogs()
        {
            string jsonrecords = File.ReadAllText(_filePath);

            List<ZESLogRecord> records = new List<ZESLogRecord>();
            records = JsonSerializer.Deserialize<List<ZESLogRecord>>(jsonrecords);

            foreach (var record in records)
            {
                if (record.Date >= DateTime.Now.AddHours(-1))
                {
                    Console.WriteLine($"action: {record.Action}, filename: {record.FileName}, filepath: {record.LogFilePath}, date: {record.Date}");

                }
            }
        }
    }
}

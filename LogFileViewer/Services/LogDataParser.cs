using LogFileViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer.Services
{
    public class LogDataParser : ILogDataParser
    {
        public LogData ParseLine(string line)
        {
            var result = new LogData();
            var temp = line.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length == 3)
            {
                result.Date = temp[0].Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0];
                result.LogLevel = temp[1].Trim();
                result.Message = temp[2].Trim();

                return result;
            }
            else
            {
                Console.WriteLine("Error while parsing!");
                return null;
            }
        }
    }
}

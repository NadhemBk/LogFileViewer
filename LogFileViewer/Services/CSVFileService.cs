using LogFileViewer.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer.Services
{
    public class CSVFileService : ICSVFileService
    {
        public void SaveFile(ObservableCollection<LogData> logData)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Csv file (*.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = File.CreateText(saveFileDialog.FileName))
                {
                    foreach (var line in ToCsv(logData))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private IEnumerable<string> ToCsv(IEnumerable<LogData> list)
        {
            var properties = typeof(LogData).GetProperties();
                        
            foreach (var logData in list)
            {
                yield return string.Join(";",
                                         properties.Select(p => (p.GetValue(logData, null) ?? string.Empty).ToString())
                                               .ToArray());
            }
        }
    }
}

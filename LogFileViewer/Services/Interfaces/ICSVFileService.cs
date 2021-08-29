using LogFileViewer.Models;
using System.Collections.ObjectModel;

namespace LogFileViewer.Services
{
    public interface ICSVFileService
    {
        void SaveFile(ObservableCollection<LogData> logData);
    }
}
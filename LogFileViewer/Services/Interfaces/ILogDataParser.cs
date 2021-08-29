using LogFileViewer.Models;

namespace LogFileViewer.Services
{
    public interface ILogDataParser
    {
        LogData ParseLine(string line);
    }
}
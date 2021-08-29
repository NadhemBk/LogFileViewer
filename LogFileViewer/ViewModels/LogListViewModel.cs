using LogFileViewer.Infrastructure;
using LogFileViewer.Models;
using LogFileViewer.Services;
using Microsoft.Win32;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LogFileViewer.ViewModels
{
    public class LogListViewModel : BaseViewModel
    {
        private ObservableCollection<LogData> _logDataCollection;
        private ObservableCollection<LogData> _backupCollection;
        private string _fileName;
        private string _searchWords;

        public LogListViewModel()
        {
            WindowTitle = "Logfile Viewer";
        }

        [Inject]
        public ILogDataParser DataParser { get; set; }

        [Inject]
        public ICSVFileService CSVFileService { get; set; }

        public ICommand OpenFile => new ActionCommand(OnOpen, o => true);
        public ICommand SaveFile => new ActionCommand(OnSave, o => true);
        public ICommand FilterData => new ActionCommand(OnFilter, o => true);

        public string SearchWords 
        {
            get
            {
                return _searchWords;
            }
            set
            {
                _searchWords = value;
                OnPropertyChanged();
            }
        }

        public String FileName { 
            get 
            { 
                return _fileName; 
            }
            set 
            { 
                _fileName = value; 
                OnPropertyChanged(); 
            }
        }

        public ObservableCollection<LogData> LogDataCollection 
        {
            get { return _logDataCollection; }
            set 
            {
                _logDataCollection = value;
                OnPropertyChanged();
            }
        }

        private void OnSave(object obj)
        {
            CSVFileService.SaveFile(LogDataCollection);
        }

        private void OnFilter(object obj)
        {
            if(LogDataCollection == null)
            {
                return;
            }

            if(SearchWords == null || SearchWords == "")
            {
                LogDataCollection = _backupCollection;
            }
            else
            {
                var lowerCaseSearchWords = SearchWords.ToLower();
                var filteredList = _backupCollection
                    .Where(x => x.Date.Contains(lowerCaseSearchWords)
                             || x.LogLevel.ToLower().Contains(lowerCaseSearchWords)
                             || x.Message.ToLower().Contains(lowerCaseSearchWords))
                    .Select(x => x);
                LogDataCollection = new ObservableCollection<LogData>(filteredList);
            }
        }

        private void OnOpen(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Log files (*.log)|*.log"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                LoadData(openFileDialog.FileName);
                FileName = openFileDialog.FileName;
            }
        }

        private void LoadData (string fileName)
        {
            LogDataCollection = new ObservableCollection<LogData>();

            var fileLines = File.ReadAllLines(fileName);
            foreach (var line in fileLines)
            {
                LogData temp = DataParser.ParseLine(line);
                LogDataCollection.Add(temp);
            }

            _backupCollection = LogDataCollection;
        }
    }
}

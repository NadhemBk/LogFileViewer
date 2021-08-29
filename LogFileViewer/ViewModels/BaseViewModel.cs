using LogFileViewer.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LogFileViewer.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _windowTitle;

        public BaseViewModel()
        {
            IoC.Inject(this);
        }

        public string WindowTitle 
        { 
            get { return _windowTitle; }
            set 
            { 
                _windowTitle = value;
                OnPropertyChanged();
            } 
        }

        public virtual void Dispose() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

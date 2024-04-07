using Simple2FAFlow.Core;
using System.Windows.Input;

namespace Simple2FAFlow.ViewModel
{
    public class NavigationVM :ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand ValidationCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Validation(object obj) => CurrentView = new ValidationVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ValidationCommand = new RelayCommand(Validation);

            CurrentView = new HomeVM();
        }
    }
}

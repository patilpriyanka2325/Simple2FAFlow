using Simple2FAFlow.Core;
using System.Windows;
using System.Windows.Input;

namespace Simple2FAFlow.ViewModel
{
    public class NavigationVM : ViewModelBase
    {
        private Visibility _isButtonVisible;
        public Visibility IsButtonVisible
        {
            get => _isButtonVisible;
            set
            {
                _isButtonVisible = value;
                OnPropertyChanged(nameof(IsButtonVisible));
            }
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
                IsButtonVisible = (_currentView is HomeVM) ? Visibility.Visible : Visibility.Collapsed;
            }
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

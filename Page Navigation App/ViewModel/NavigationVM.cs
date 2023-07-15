using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Page_Navigation_App.Utilities;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Collections.ObjectModel;
using Page_Navigation_App.Model;

namespace Page_Navigation_App.ViewModel
{
    public partial class NavigationVM : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

     


        [RelayCommand]
        public void Home(object obj) => CurrentView = new HomeVM();
        [RelayCommand]
        public void Customer(object obj)
        {
            CurrentView = new EditVM();
        }
        [RelayCommand]

        public void DStudent(object obj) => CurrentView = new DeleteStudentVM();
        [RelayCommand]
        public void Student(object obj) => CurrentView = new AddStudentVM();
        
        public NavigationVM()
        {
            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}

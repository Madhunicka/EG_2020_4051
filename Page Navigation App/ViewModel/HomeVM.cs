using CommunityToolkit.Mvvm.ComponentModel;
using Page_Navigation_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Page_Navigation_App.Model;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using Page_Navigation_App.View;

namespace Page_Navigation_App.ViewModel
{
    public partial class HomeVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Person> persons;
        [ObservableProperty]
        public Person selectedPerson = null;
        

        public HomeVM()
        {
            if(CommonData.Instance.SharedVariable == null)
            {
                persons = new ObservableCollection<Person>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            persons.Add(new Person(12, "Arjun", "Shiyam", "12/1/2000", image1,1.5));
            BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            persons.Add(new Person(12, "Tom", "Harry", "12/1/2000", image2,2.3));
            BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            persons.Add(new Person(12, "Micheal", "Jackson", "12/1/2000", image3,4.0));
            BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            persons.Add(new Person(12, "Kumar", "Thiyagaraja", "12/1/2000", image4,1.8));

            CommonData.Instance.SharedVariable = persons;
            }
            else
            {
                persons = new ObservableCollection<Person>();
                persons = CommonData.Instance.SharedVariable;
            }
            
        }

        /* private object _currentView;
         public object CurrentView
         {
             get { return _currentView; }
             set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
         }

         [RelayCommand]
         public void ExecuteStudentCommand()
         {
             var vm = new AddStudentVM();
             CurrentView = new AddStudent { DataContext = vm };
         }*/
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedPerson != null)
            {
                var vm = new AddStudentVM(selectedPerson);
              
                var window = new EditStudent(vm);

                window.ShowDialog();


                int index = persons.IndexOf(selectedPerson);
                persons.RemoveAt(index);
                persons.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedPerson != null)
            {
                string name = selectedPerson.FirstName;
                persons.Remove(selectedPerson);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
       


    }
}

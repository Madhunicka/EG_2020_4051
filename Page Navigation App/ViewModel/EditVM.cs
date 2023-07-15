using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media.Imaging;
using Page_Navigation_App.Model;

namespace Page_Navigation_App.ViewModel
{
    public partial class EditVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Person> persons;
        [ObservableProperty]
        public Person? selectedPerson = null;


       


        public EditVM()
        {
            if (CommonData.Instance.SharedVariable == null)
            {
                persons = new ObservableCollection<Person>();
                BitmapImage image1 = new BitmapImage(new Uri("/Assets/Images/1.png", UriKind.Relative));
                persons.Add(new Person(12, "Arjun", "Shiyam", "12/1/2000", image1,1.5));
                BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
                persons.Add(new Person(12, "Tom", "Harry", "12/1/2000", image2,2.3));
                BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
                persons.Add(new Person(12, "Micheal", "Jackson", "12/1/2000", image3,4.0));
                BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
                persons.Add(new Person(12, "Kumar", "Thiyagaraja", "12/1/2000", image4,1.8));

                CommonData.Instance.SharedVariable = persons;
            }
            else
            {
                persons = new ObservableCollection<Person>();
                persons = CommonData.Instance.SharedVariable;
            }

        }
    }
}

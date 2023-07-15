using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Page_Navigation_App.Model;
using System.Collections.ObjectModel;

namespace Page_Navigation_App.ViewModel
{
    public partial class AddStudentVM : ObservableObject
    {

        public Person Student { get; private set; }
        public object SaveChangesCommand { get; internal set; }
        public Person SelectedPerson { get; internal set; }

        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;



        //To change the tile



        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;


        public ObservableCollection<Person> people;

       



        public AddStudentVM(Person u)
        {
            //MessageBox.Show(u.FirstName);
            Student = u;

            firstname = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            dateofbirth = Student.DateOfBirth;
            selectedImage = Student.Image;

        }
        public AddStudentVM()
        {

            people = new ObservableCollection<Person>();
            people = CommonData.Instance.SharedVariable;
            //string sharedVariable = CommonData.Instance.SharedVariable;
            //MessageBox.Show(sharedVariable);
        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }

        public void CloseCurrentWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }
        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (Student == null)
            {

                Student = new Person()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,

                    GPA = gpa

                };

                people.Add(Student);
                //MessageBox.Show(people.Count.ToString());
                CommonData.Instance.SharedVariable = people;
               MessageBox.Show("Successfully added");
                if (Student.FirstName != null)
                {
                    Firstname = "";
                    Lastname = "";
                    Age = 0;
                    Gpa = 0;
                    Dateofbirth = "";

                }
                Student = null;



            }
            else
            {

                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.GPA = gpa;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateofbirth;
                CloseCurrentWindow();




            }
            




        }


    }
}

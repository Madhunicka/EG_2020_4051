using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.Model
{
    public class CommonData
    {
        private static CommonData instance;
        public ObservableCollection<Person> SharedVariable { get; set; }

        public Person SelectedPersonObj { get; set; }    

        private CommonData()
        {
        }

        public static CommonData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonData();
                }
                return instance;
            }
        }
    }

}

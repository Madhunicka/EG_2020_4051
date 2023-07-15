using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.ViewModel
{
    public class ViewModelVM
    {
        public HomeVM MyViewModel1 { get; set; }
        public NavigationVM MyViewModel2 { get; set; }

        public ViewModelVM()
        {
            MyViewModel1 = new HomeVM();
            MyViewModel2 = new NavigationVM();
        }
    }
}

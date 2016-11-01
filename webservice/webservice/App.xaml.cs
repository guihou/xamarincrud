using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace webservice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*Student s = new Student
            {
                Id = 1,
                Fullname = "name",
                Department = "dep"
            };
            MainPage = new webservice.delete(s);*/
            MainPage = new webservice.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

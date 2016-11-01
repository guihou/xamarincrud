using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace webservice
{
    public partial class AddStudent : ContentPage
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        public async void senddata(object o, EventArgs e)
        {
            string url = "http://mystudents.azurewebsites.net/api/StudentsApi";

            var httpClient = new HttpClient();

            Student s = new Student
            {
                Department = department.Text,
                Fullname = name.Text
            };

            string content = JsonConvert.SerializeObject(s);



            HttpContent httpcontent = new StringContent(content);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var  response = await httpClient.PostAsync(url, httpcontent);

            await DisplayAlert("Edition", s.Fullname + " est ajouté", "ok");

            await Navigation.PushModalAsync(new MainPage());
        }
    }
}

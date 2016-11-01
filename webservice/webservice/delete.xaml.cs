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
    
    public partial class delete : ContentPage
    {
        private readonly Student _student;

        public delete(Student student)
        {
            InitializeComponent();
            _student = student;
            name.Text = student.Fullname;
            department.Text = student.Department;
            
            
        }

        public async void showlist(Object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        public async void delete_Action(Object o, EventArgs e)
        {
            string url = "http://mystudents.azurewebsites.net/api/StudentsApi/";

            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(url + _student.Id );

            await DisplayAlert("Edition", _student.Fullname+" est supprimé de la base", "ok");

            await Navigation.PushModalAsync(new MainPage());
        }

        public async void senddata(object o, EventArgs e)
        {
            string url = "http://mystudents.azurewebsites.net/api/StudentsApi/";

            var httpClient = new HttpClient();

            Student s = new Student
            {
                Id = _student.Id,
                Department = department.Text,
                Fullname = name.Text
            };

            string content = JsonConvert.SerializeObject(s);



            HttpContent httpcontent = new StringContent(content);
            httpcontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await httpClient.PutAsync(url + _student.Id, httpcontent);

            await DisplayAlert("Edition", _student.Fullname + " est modifié", "ok");

            await Navigation.PushModalAsync(new MainPage());
        }
    }
}

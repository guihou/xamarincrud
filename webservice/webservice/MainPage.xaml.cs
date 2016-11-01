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

    public class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Department { get; set; }

        public Student()
        {

        }
    }

    public partial class MainPage : ContentPage
    {
        private string url = "http://mystudents.azurewebsites.net/api/StudentsApi";

        public MainPage()
        {
            InitializeComponent();

            DownloadStudentsAsync();
        }

        private async Task DownloadStudentsAsync()
        {
            var httpClient = new HttpClient();
            string json    = await httpClient.GetStringAsync(url);

            var students = JsonConvert.DeserializeObject<List<Student>>(json);

            StudentListView.ItemsSource = students;
        }

        public async void showinformations(Object o, ItemTappedEventArgs e)
        {
            Student s = (Student)e.Item;
            await DisplayAlert("Edition", s.Fullname + " " + s.Fullname, "ok");
            if (s != null)
            {
                await Navigation.PushModalAsync(new delete(s));
            }
        }

        public async void navigateto(Object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddStudent());
        }

        public void refreshlist(Object o, EventArgs e)
        {
            DownloadStudentsAsync();
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace x_pract_8
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void birthDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime today = DateTime.Now;
            age.Text = "Возраст - " + Convert.ToString(today.Year - birthDate.Date.Year);
        }        

        private void btn_SetImage_Clicked(object sender, EventArgs e)
        {
            Image img = new Image();
            img.Source = "dog.jpg";
            
            Images.Children.Add(img);            
        }
    }
}

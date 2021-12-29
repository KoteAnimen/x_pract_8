using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;

namespace x_pract_8
{
    public partial class MainPage : ContentPage
    {
        string pathToImage = "";        

        public MainPage()
        {
            InitializeComponent();
        }

        private void birthDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime today = DateTime.Now;
            age.Text = "Возраст - " + Convert.ToString(today.Year - birthDate.Date.Year);
        }        

        async private void btn_SetImage_Clicked(object sender, EventArgs e)
        {
            if(Device.RuntimePlatform == Device.Android)
            {
                var result = await FilePicker.PickAsync();
                pathToImage = result.FullPath;
                Images.Source = pathToImage;                
            }        
        }

        void SetImage()
        {
            Images.Source = "dog.jpg";            
        }
    }
}

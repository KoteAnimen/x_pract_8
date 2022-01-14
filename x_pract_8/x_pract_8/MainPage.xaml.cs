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
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

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

        void SaveFirstMethod()
        {
            Application.Current.Properties["name"] = name.Text;
            Application.Current.Properties["familyName"] = familyName.Text;
            Application.Current.Properties["lastName"] = lastName.Text;
            Application.Current.Properties["age"] = age.Text;
            Application.Current.Properties["sex"] = sex.SelectedItem;
            Application.Current.Properties["needHause"] = needHause.On;
            Application.Current.Properties["head"] = head.IsEnabled;
            Application.Current.Properties["image"] = pathToImage;            

            Application.Current.SavePropertiesAsync();
        }

        void LoadFirstMethod()
        {
            object value;
            if (Application.Current.Properties.TryGetValue("name", out value) == true) name.Text = (string)value;
            if (Application.Current.Properties.TryGetValue("familyName", out value) == true) familyName.Text = (string)value;
            if (Application.Current.Properties.TryGetValue("lastName", out value) == true) lastName.Text = (string)value;
            if (Application.Current.Properties.TryGetValue("age", out value) == true) age.Text = (string)value;
            if (Application.Current.Properties.TryGetValue("sex", out value) == true) sex.SelectedItem = (string)value;
            if (Application.Current.Properties.TryGetValue("needHause", out value) == true) needHause.On = (bool)value;
            if (Application.Current.Properties.TryGetValue("head", out value) == true) head.IsEnabled = (bool)value;
            if (Application.Current.Properties.TryGetValue("image", out value) == true) Images.Source = (string)value;
        }

        void SaveSecondMethod()
        {
            Preferences.Set("name", name.Text);
            Preferences.Set("familyName", familyName.Text);
            Preferences.Set("lastName", lastName.Text);
            Preferences.Set("age", age.Text);
            Preferences.Set("sex", sex.SelectedItem.ToString());
            Preferences.Set("needHause", needHause.On.ToString());
            Preferences.Set("head", head.On.ToString());
            Preferences.Set("image", pathToImage);            
        }

        void LoadSecondMethod()
        {
            
            name.Text = Preferences.Get("name", "");
            familyName.Text = Preferences.Get("familyName", "");
            lastName.Text = Preferences.Get("lastName", "");
            age.Text = Preferences.Get("age", "");
            sex.SelectedItem = Preferences.Get("sex", "");
            needHause.On = Convert.ToBoolean(Preferences.Get("needHause", ""));            
            head.On = Convert.ToBoolean(Preferences.Get("head", "")); 
            Images.Source = Preferences.Get("image", "");
        }

        void SaveThridMethod()
        {
            StreamWriter write = new StreamWriter(Path.Combine(folderPath, "info.txt"));
            write.WriteLine(name.Text);
            write.WriteLine(familyName.Text);
            write.WriteLine(lastName.Text);
            write.WriteLine(age.Text);
            write.WriteLine(sex.SelectedItem);
            write.WriteLine(needHause.On);
            write.WriteLine(head.On);
            write.WriteLine(pathToImage);
            write.Close();
        }

        void LoadThridMethod()
        {
            if(File.Exists(Path.Combine(folderPath, "info.txt")))
            {
                StreamReader read = new StreamReader(Path.Combine(folderPath, "info.txt"));
                name.Text = Convert.ToString(read.ReadLine());
                familyName.Text = Convert.ToString(read.ReadLine());
                lastName.Text = Convert.ToString(read.ReadLine());
                age.Text = Convert.ToString(read.ReadLine());
                sex.SelectedItem = Convert.ToString(read.ReadLine());
                needHause.On = Convert.ToBoolean(read.ReadLine());
                head.On = Convert.ToBoolean(read.ReadLine());
                Images.Source = Convert.ToString(read.ReadLine());
                read.Close();
            }            
        }

        private void btn_Save_Clicked(object sender, EventArgs e)
        {
            //SaveFirstMethod();
            //SaveSecondMethod();
            SaveThridMethod();
        }

        private void btn_Load_Clicked(object sender, EventArgs e)
        {
            //LoadFirstMethod();
            //LoadSecondMethod();
            LoadThridMethod();
        }

        private void sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class PickerValidation : TriggerAction<Picker>
    {
        protected override void Invoke(Picker sender)
        {
            sender.TextColor = sender.SelectedIndex == 0 ? Color.Blue : Color.Pink;
        }
    }
}

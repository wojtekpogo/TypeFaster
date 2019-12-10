using System;
using Xamarin.Forms;

//each mode contains different words

namespace TypeFaster
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //navigate to the easy mode
        private void Easy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EasyMode());

        }
        //navigate to the medium mode
        private void Medium_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MediumMode());

        }
        //navigate to the hard mode
        private void Hard_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HardMode());

        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new About());


        }
    }
}

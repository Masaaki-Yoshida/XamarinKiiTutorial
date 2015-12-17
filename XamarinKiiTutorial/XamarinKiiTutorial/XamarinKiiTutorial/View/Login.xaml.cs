using System;
using Xamarin.Forms;

namespace XamarinKiiTutorial
{
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
            
            _Login.Clicked += _Login_Clicked;
            _Regist.Clicked += _Regist_Clicked;

            //初期化
            KiiService.kiiInitialize();
        }

        private async void _Regist_Clicked(object sender, EventArgs e)
        {
            var res = await KiiService.KiiUserRegisterAsync(_UserName.Text, _Password.Text);
            if (res.e != null)
            {
                await this.DisplayAlert("Registration failed", res.e.ToString(), "OK");
                return;
            }

            await this.DisplayAlert("KiiUser Registration Succeed!!!", "", "OK");

            App.LoginUser = res.user;
            Application.Current.MainPage = new NavigationPage(new CreateObject());
        }

        private async void _Login_Clicked(object sender, EventArgs e)
        {
            var res = await KiiService.KiiUserLoginAsync(_UserName.Text, _Password.Text);
            if (res.e != null)
            {
                await this.DisplayAlert( "SignIn failed", res.e.ToString(),"OK");
                return;
            }

            await this.DisplayAlert("KiiObject Log In Succeed!!!", "", "OK");

            App.LoginUser = res.user;
            Application.Current.MainPage = new NavigationPage(new CreateObject());
        }
    }
}

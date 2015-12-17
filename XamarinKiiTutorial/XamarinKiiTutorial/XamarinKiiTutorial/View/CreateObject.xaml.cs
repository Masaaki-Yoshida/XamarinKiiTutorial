using System;
using Xamarin.Forms;
using KiiCorp.Cloud.Storage;

namespace XamarinKiiTutorial
{
    public partial class CreateObject : ContentPage
    {
        public CreateObject()
        {
            InitializeComponent();
            _CreateObject.Clicked += _CreateObject_Clicked;
        }

        private async void _CreateObject_Clicked(object sender, EventArgs e)
        {
            KiiObject obj = Kii.Bucket("XamarinKiiTutorial").NewKiiObject();
            obj["username"] = App.LoginUser.Username;

            var res = await KiiService.KiiObjectCreateAsync(obj);
            if (res.e != null)
            {
                await this.DisplayAlert("KiiObject creation failed", res.e.ToString(), "OK");
                return;
            }

            await this.DisplayAlert("KiiObject creation Succeed!!!","" ,"OK");
        }
    }
}

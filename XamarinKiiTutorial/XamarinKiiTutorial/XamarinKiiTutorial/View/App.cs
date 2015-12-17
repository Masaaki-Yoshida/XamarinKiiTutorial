using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KiiCorp.Cloud.Storage;

namespace XamarinKiiTutorial
{
    public class App : Application
    {
        public static KiiUser LoginUser { get; set; }


        public App()
        {
            //ロード画面
            MainPage = new Login();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

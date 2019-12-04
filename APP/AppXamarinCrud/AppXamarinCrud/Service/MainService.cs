using AppXamarinCrud.View;
using MVVM.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppXamarinCrud.Service
{
    class MainService
    {
        public void OptionSelected(string goTo)
        {
            switch (goTo)
            {
                case "Videogames":
                    Application.Current.MainPage = new NavigationPage(new Videogames());
                    break;
                case "Platforms":
                    Application.Current.MainPage = new NavigationPage(new Platforms());
                    break;
                case "Distributors":
                    Application.Current.MainPage = new NavigationPage(new DistribuidoraPage());
                    break;
                case "Companies":
                    Application.Current.MainPage = new NavigationPage(new Companies());
                    break;
                case "Reviews":
                    Application.Current.MainPage = new NavigationPage(new Reviews());
                    break;
                case "Users":
                    Application.Current.MainPage = new NavigationPage(new Users());
                    break;
                case "Options":
                    Application.Current.MainPage = new NavigationPage(new Options());
                    break;
                case "Exit":
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                    break;
                
            }
        }
    }
}

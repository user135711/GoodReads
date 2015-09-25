﻿using Mendo.UAP.Common;
using Microsoft.AdMediator.Core.Models;
using MyShelf.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyShelf.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookPage : PageBase
    {
        public BookViewModel ViewModel { get; set; }
        public bool ShowAds => !API.Storage.MyShelfSettings.Instance.DontShowAds;

        public BookPage()
        {
            this.InitializeComponent();

            AdMediator_Home_1.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Width"] = 728;
            AdMediator_Home_1.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Height"] = 90;
        }

        protected override void LoadState(object parameter, Dictionary<string, object> pageState)
        {
            base.LoadState(parameter, pageState);

            if (parameter != null)
            {
                if (parameter is string)
                {
                    ViewModel = new BookViewModel(parameter as string);
                }
                else if (parameter is BookViewModel)
                    ViewModel = parameter as BookViewModel;
            }
        }

        protected override void SaveState(NavigationEventArgs e, Dictionary<string, object> pageState)
        {
            API.Web.ApiClient.Instance.ResetQueue();

            base.SaveState(e, pageState);
        }
    }
}
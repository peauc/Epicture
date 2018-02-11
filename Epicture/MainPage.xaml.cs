// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Epicture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Windows.ApplicationModel.Core;
    using Windows.UI;
    using Windows.UI.ViewManagement;

    using Epicture.Tools;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using Epicture.Pages;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Dictionary<Type, string> typeToPageName;

        public MainPage()
        {
            Imgur t = new Imgur();
            this.InitializeComponent();

            //draw into the title bar
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

            //remove the solid-colored backgrounds behind the caption controls and system back button
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonForegroundColor = (Color)this.Resources["SystemBaseHighColor"];

            this.typeToPageName = new Dictionary<Type, string>
            {
                [typeof(MainFeedPage)] = "Feed",
                [typeof(FavoritesPage)] = "Favorites",
                [typeof(MyImagesPage)] = "Submissions",
                [typeof(UploadPage)] = "Upload"
            };

            this.CurrentPageName = this.typeToPageName[typeof(MainFeedPage)];
            this.ContentFrame.Navigate(typeof(MainFeedPage));
        }

        public string CurrentPageName { get; set; }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // set the initial SelectedItem
            foreach (NavigationViewItemBase item in this.NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "apps")
                {
                    this.NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            this.NavView_Navigate((NavigationViewItem)item);
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            this.NavView_Navigate(item);
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "main_feed":
                    this.CurrentPageName = this.typeToPageName[typeof(MainFeedPage)];
                    this.ContentFrame.Navigate(typeof(MainFeedPage));
                    break;

                case "favs":
                    this.CurrentPageName = this.typeToPageName[typeof(FavoritesPage)];
                    this.ContentFrame.Navigate(typeof(FavoritesPage));
                    break;

                case "collection":
                    this.CurrentPageName = this.typeToPageName[typeof(MyImagesPage)];
                    this.ContentFrame.Navigate(typeof(MyImagesPage));
                    break;
                case "upload":
                    this.CurrentPageName = this.typeToPageName[typeof(UploadPage)];
                    this.ContentFrame.Navigate(typeof(UploadPage));
                    break;
            }
        }
    }
}

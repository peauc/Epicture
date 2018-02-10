

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Epicture
{
    using System.Linq;

    using Epicture.Tools;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            Imgur t = new Imgur();
            this.InitializeComponent();
        }

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

            if (args.IsSettingsInvoked)
            {
                this.ContentFrame.Navigate(typeof(MainFeedPage));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                this.NavView_Navigate((NavigationViewItem)item);

            }
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                this.ContentFrame.Navigate(typeof(MainFeedPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                this.NavView_Navigate(item);
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "main_feed":
                    this.ContentFrame.Navigate(typeof(MainFeedPage));
                    break;

                case "favs":
                    this.ContentFrame.Navigate(typeof(FavoritesPage));
                    break;

                case "collection":
                    this.ContentFrame.Navigate(typeof(MyImagesPage));
                    break;
            }
        }
    }
}

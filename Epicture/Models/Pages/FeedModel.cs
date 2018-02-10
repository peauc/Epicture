namespace Epicture.Models.Pages
{
    using System.Collections.ObjectModel;

    public class FeedModel : ObservableObject
    {
        public ObservableCollection<ImageModel> Images { get; set; } = new ObservableCollection<ImageModel>();
    }
}

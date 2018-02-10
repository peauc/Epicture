namespace Epicture.Models.Pages
{
    using System.Collections.ObjectModel;

    using Epicture.Commands;
    using Epicture.Tools;

    public abstract class FeedModel : ObservableObject
    {
        protected ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();

        protected FeedModel()
        {
            this.RefreshCommand = new RefreshCommand(this);
            if (Api == null)
            {
                Api = new Imgur();
            }
        }

        public static Imgur Api { get; set; } = null;

        public RefreshCommand RefreshCommand { get; }

        public ObservableCollection<ImageModel> Images
        {
            get => this.images;
            set => this.images = value;
        }

        public abstract void Refresh();
    }
}
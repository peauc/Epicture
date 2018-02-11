namespace Epicture.Models
{
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Contacts;
    using Windows.UI.Xaml;

    using Epicture.Commands;

    using Imgur.API.Models;

    public class ImageModel
    {
        public ImageModel()
        {
            this.FavoriteCommand = new FavoriteCommand(this);
        }

        public ImageModel(IImage image)
        {
            this.FavoriteCommand = new FavoriteCommand(this);

            this.Width = image.Width;
            this.Height = image.Height;
            this.Title = image.Title ?? "Unknown";
            this.Desc = image.Description ?? "Unknown";
            this.IsFavorite = image.Favorite.HasValue && image.Favorite == true;
            this.Url = image.Link;
            this.CanBeFavorite = false;
            this.Image = image;
        }

        public ImageModel(IGalleryImage image)
        {
            this.FavoriteCommand = new FavoriteCommand(this);

            this.Width = image.Width;
            this.Height = image.Height;
            this.Title = image.Title ?? "Unknown";
            this.Desc = image.Description ?? "Unknown";
            this.IsFavorite = image.Favorite.HasValue && image.Favorite == true;
            this.Url = image.Link;
            this.CanBeFavorite = true;
            this.Image = null;
        }

        public bool IsFavorite { get; set; }

        public string Desc { get; set; }

        public string Title { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Url { get; set; }

        public bool CanBeFavorite { get; set; }

        public Visibility FavoriteVisibility => (!this.IsFavorite) ? Visibility.Visible : Visibility.Collapsed;

        public Visibility UnFavoriteVisibility => (this.IsFavorite) ? Visibility.Visible : Visibility.Collapsed;

        public bool FavoriteEnabled => false;

        public bool UnFavoriteEnabled => false;

        public IImage Image { get; set; }

        public FavoriteCommand FavoriteCommand { get; set; }
    }
}

namespace Epicture.Models
{
    using Imgur.API.Models;

    public class ImageModel
    {
        public ImageModel()
        {
        }

        public ImageModel(IImage image)
        {
            this.Width = image.Width;
            this.Height = image.Height;
            this.Title = image.Title ?? "Unknown";
            this.Desc = image.Description ?? "Unknown";
            this.IsFavorite = image.Favorite.HasValue && image.Favorite == true;
            this.Url = image.Link;
        }

        public ImageModel(IGalleryImage image)
        {
            this.Width = image.Width;
            this.Height = image.Height;
            this.Title = image.Title ?? "Unknown";
            this.Desc = image.Description ?? "Unknown";
            this.IsFavorite = image.Favorite.HasValue && image.Favorite == true;
            this.Url = image.Link;
        }

        public bool IsFavorite { get; set; }

        public string Desc { get; set; }

        public string Title { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Url { get; set; }
    }
}

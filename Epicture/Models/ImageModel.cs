namespace Epicture.Models
{
    using Imgur.API.Models;

    public class ImageModel
    {

        private string url;
        private int width;
        private int height;
        private string title;
        private string desc;
        private bool isFavorited;
        private IImage image;

        public ImageModel()
        {
            
        }
        public ImageModel(IImage image)
        {
            this.image = image;
            this.Width = image.Width;
            this.Height = image.Height;
            this.Title = image.Title;
            this.Desc = image.Description;
            this.IsFavorited = (image.Favorite.HasValue && image.Favorite == true);
            this.Url = image.Link;
        }

        public bool IsFavorited
        {
            get => isFavorited;
            set => isFavorited = value;
        }

        public string Desc
        {
            get => desc;
            set => this.desc = value;
        }


        public string Title
        {
            get => title;
            set => this.title = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }


        public int Width
        {
            get => width;
            set => width = value;
        }

        public string Url
        {
            get => this.url;
            set => this.url = value;
        }
    }
}

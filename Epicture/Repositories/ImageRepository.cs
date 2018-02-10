namespace Epicture.Repositories
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using Epicture.Models;

    public static class ImageRepository
    {
        public static async Task<ObservableCollection<ImageModel>> GetAllImagesAsync(string filter)
        {
            ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // fill with default data
                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Url = "Url1", AuthorName = "Author1", IsFavorite = false },
                                 new ImageModel { Url = "Url2", AuthorName = "Author2", IsFavorite = true },
                                 new ImageModel { Url = "Url3", AuthorName = "Author3", IsFavorite = false },
                                 new ImageModel { Url = "Url4", AuthorName = "Author4", IsFavorite = true },
                                 new ImageModel { Url = "Url5", AuthorName = "Author5", IsFavorite = false },
                                 new ImageModel { Url = "Url6", AuthorName = "Author6", IsFavorite = false },
                                 new ImageModel { Url = "Url7", AuthorName = "Author7", IsFavorite = false },
                             };
            }
            else
            {
                // call imgur API
                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Url = "Url1", AuthorName = "Author1", IsFavorite = false },
                                 new ImageModel { Url = "Url2", AuthorName = "Author2", IsFavorite = true },
                                 new ImageModel { Url = "Url3", AuthorName = "Author3", IsFavorite = false },
                                 new ImageModel { Url = "Url4", AuthorName = "Author4", IsFavorite = true },
                                 new ImageModel { Url = "Url5", AuthorName = "Author5", IsFavorite = false },
                                 new ImageModel { Url = "Url6", AuthorName = "Author6", IsFavorite = false },
                                 new ImageModel { Url = "Url7", AuthorName = "Author7", IsFavorite = false },
                             };
            }

            return images;
        }

        public static async Task<ObservableCollection<ImageModel>> GetFavoriteImagesAsync(string filter)
        {
            ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // fill with default data
                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Url = "Url2", AuthorName = "Author2", IsFavorite = true },
                                 new ImageModel { Url = "Url4", AuthorName = "Author4", IsFavorite = true },
                             };
            }
            else
            {
                // call imgur API
            }

            return images;
        }

        public static async Task<ObservableCollection<ImageModel>> GetUserImagesAsync(string filter)
        {
            ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // fill with default data
                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Url = "Url4", AuthorName = "Author4", IsFavorite = true },
                             };
            }
            else
            {
                // call imgur API
            }

            return images;
        }
    }
}
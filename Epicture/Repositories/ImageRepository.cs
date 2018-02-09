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
                                 new ImageModel(),
                                 new ImageModel(),
                                 new ImageModel(),
                                 new ImageModel(),
                                 new ImageModel(),
                                 new ImageModel(),
                                 new ImageModel(),
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

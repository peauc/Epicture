namespace Epicture.Models.Pages
{
    using Epicture.Repositories;

    public class MyImagesPageData : FeedModel
    {
        public MyImagesPageData()
        {
            this.LoadDatasAsync();
        }

        private async void LoadDatasAsync()
        {
            this.Images = await ImageRepository.GetUserImagesAsync(string.Empty);
        }
    }
}

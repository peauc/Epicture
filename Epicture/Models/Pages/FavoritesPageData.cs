namespace Epicture.Models.Pages
{
    using Epicture.Repositories;

    public class FavoritesPageData : FeedModel
    {
        public FavoritesPageData()
        {
            this.LoadDatasAsync();
        }

        private async void LoadDatasAsync()
        {
            this.Images = await ImageRepository.GetFavoriteImagesAsync(string.Empty);
        }
    }
}

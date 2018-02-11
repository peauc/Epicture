namespace Epicture.Models.Pages
{
    using System;

    using Epicture.Repositories;

    public class FavoritesPageData : FeedModel
    {
        public FavoritesPageData()
        {
            this.LoadDatasAsync();
        }

        public override void Refresh()
        {
            this.LoadImagesAsync();
        }

        private void LoadDatasAsync()
        {
            this.LoadImagesAsync();
        }

        private async void LoadImagesAsync()
        {
            this.Images.Clear();
            var submissions = await ImageRepository.GetFavoriteImagesAsync(string.Empty, App.Api);

            foreach (ImageModel submission in submissions)
            {
                this.Images.Add(submission);
            }
        }
    }
}

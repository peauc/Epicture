namespace Epicture.Models.Pages
{
    using System;

    using Epicture.Repositories;

    public class MainFeedPageData : FeedModel
    {
        public MainFeedPageData()
        {
            this.LoadDatasAsync();
        }

        private async void LoadDatasAsync()
        {
            this.Images = await ImageRepository.GetAllImagesAsync(string.Empty);
        }
    }
}
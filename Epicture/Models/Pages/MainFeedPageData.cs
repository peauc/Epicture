namespace Epicture.Models.Pages
{
    using System;
    using System.Collections.ObjectModel;

    using Epicture.Repositories;

    public class MainFeedPageData : FeedModel
    {
        public MainFeedPageData()
        {
            this.SearchValue = App.SearchValue;
            App.SearchValue = string.Empty;
            this.LoadDatasAsync();
        }

        private string SearchValue { get; set; }

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

            try
            {
                ObservableCollection<ImageModel> submissions = await ImageRepository.GetAllImagesAsync(this.SearchValue, App.Api);
                foreach (ImageModel submission in submissions)
                {
                    this.Images.Add(submission);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
namespace Epicture.Models.Pages
{
    using Epicture.Repositories;

    public class MyImagesPageData : FeedModel
    {
        public MyImagesPageData()
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
            var submissions = await ImageRepository.GetUserImagesAsync(string.Empty, App.Api);

            foreach (ImageModel submission in submissions)
            {
                this.Images.Add(submission);
            }
        }
    }
}

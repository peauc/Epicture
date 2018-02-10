namespace Epicture.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using Epicture.Models;
    using Epicture.Tools;

    using Imgur.API.Models;

    public static class ImageRepository
    {
        public static async Task<ObservableCollection<ImageModel>> GetAllImagesAsync(string filter, Imgur api)
        {
            ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // fill with default data
                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Width = 300, Height = 200, Title = "Title1", Desc = "lorem ipsum", IsFavorite = false, Url = "url1" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title2", Desc = "lorem ipsum", IsFavorite = true, Url = "url2" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title3", Desc = "lorem ipsum", IsFavorite = true, Url = "url3" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title4", Desc = "lorem ipsum", IsFavorite = false, Url = "url4" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title5", Desc = "lorem ipsum", IsFavorite = false, Url = "url5" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title6", Desc = "lorem ipsum", IsFavorite = false, Url = "url6" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title7", Desc = "lorem ipsum", IsFavorite = true, Url = "url7" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title8", Desc = "lorem ipsum", IsFavorite = false, Url = "url8" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title9", Desc = "lorem ipsum", IsFavorite = false, Url = "url9" }
                             };
            }
            else
            {
                // call imgur API
                var ret = await api.SearchForImages(filter);
                foreach (IDataModel dataModel in ret)
                {
                    if (dataModel.GetType() == typeof(IImage))
                    {
                        images.Add(new ImageModel(dataModel as IImage));
                    }
                    else if (dataModel.GetType() == typeof(IGalleryImage))
                    {
                        images.Add(new ImageModel(dataModel as IGalleryImage));
                    }
                }
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
                    new ImageModel { Width = 300, Height = 200, Title = "Title2", Desc = "lorem ipsum", IsFavorite = true, Url = "url2" },
                    new ImageModel { Width = 300, Height = 200, Title = "Title3", Desc = "lorem ipsum", IsFavorite = true, Url = "url3" },
                    new ImageModel { Width = 300, Height = 200, Title = "Title7", Desc = "lorem ipsum", IsFavorite = true, Url = "url7" }
                };
            }
            else
            {
                // call imgur API
                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Width = 300, Height = 200, Title = "Title2", Desc = "lorem ipsum", IsFavorite = true, Url = "url2" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title3", Desc = "lorem ipsum", IsFavorite = true, Url = "url3" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title7", Desc = "lorem ipsum", IsFavorite = true, Url = "url7" }
                             };
            }

            return images;
        }

        public static async Task<ObservableCollection<ImageModel>> GetUserImagesAsync(string filter, Imgur api)
        {
            ObservableCollection<ImageModel> images = new ObservableCollection<ImageModel>();

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // fill with default data

                images = new ObservableCollection<ImageModel>
                             {
                                 new ImageModel { Width = 300, Height = 200, Title = "Title1", Desc = "lorem ipsum", IsFavorite = false, Url = "url1" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title2", Desc = "lorem ipsum", IsFavorite = true, Url = "url2" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title3", Desc = "lorem ipsum", IsFavorite = true, Url = "url3" },
                                 new ImageModel { Width = 300, Height = 200, Title = "Title4", Desc = "lorem ipsum", IsFavorite = false, Url = "url4" }
                             };
            }
            else
            {
                // call imgur API
                IEnumerable<IImage> submissions = await api.GetUserSubmissions();
                foreach (IImage submission in submissions)
                {
                    images.Add(new ImageModel(submission));
                }
            }

            return images;
        }
    }
}
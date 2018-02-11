using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.Tools
{
    using System.Collections;
    using System.Diagnostics;

    using Epicture.Models;

    using global::Imgur.API.Authentication.Impl;
    using global::Imgur.API.Endpoints.Impl;
    using global::Imgur.API.Models;
    using global::Imgur.API.Models.Impl;

    public class Imgur
    {
        private ImgurClient client;
        private AccountModel model = new AccountModel(
            account: "12691207",
            token: "56e74b092c14364fa6238eeaad56473b55f5ca85",
            expires: "315360000",
            refresh: "648180cd8967d65f5b8fb39e518299de88d780e5",
            name: "HitOrMissFr");

        public Imgur()
        {
            int t;
            int.TryParse(this.model.Expires, out t);
            this.client = new ImgurClient("b47e10e243f9c17", "cbeff1b551714a5b4e9d5888f2e895dadf841113", new OAuth2Token(this.model.Token, this.model.Refresh, "bearer", this.model.AccountId, this.model.Name, t));
            SearchForImages("Dota");
        }

        public async Task<IEnumerable<IDataModel>> GetFavorite()
        {
            var endpoint = new AccountEndpoint(client);
            var gallery = new GalleryEndpoint(client);
            var favourites = await endpoint.GetAccountFavoritesAsync();
            var imageSearch = new List<IDataModel>();
            var galleryItems = favourites as IList<IGalleryItem> ?? favourites.ToList();
            foreach (var galleryItem in galleryItems)
            {
                if (galleryItem is GalleryAlbum)
                {
                    var GI = (GalleryAlbum)galleryItem;
                    var album = await gallery.GetGalleryAlbumAsync(GI.Id);
                    foreach (var albumImage in album.Images)
                    {
                        imageSearch.Add(albumImage);
                    }
                }
                else
                {
                    var t = (GalleryImage)galleryItem;

                    imageSearch.Add(t);
                }
            }
            return imageSearch;
        }

        public async Task<List<IDataModel>> SearchForImages(string query, int page = 1)
        {
            var endpoint = new GalleryEndpoint(this.client);
            var submissions = await endpoint.SearchGalleryAsync(query, page: page);
            var searchForImages = new List<IDataModel>();
            foreach (var galleryItem in submissions)
            {
                if (galleryItem is GalleryAlbum)
                {
                    var GI = (GalleryAlbum)galleryItem;
                    var album = await endpoint.GetGalleryAlbumAsync(GI.Id);
                    foreach (var albumImage in album.Images)
                    {
                        searchForImages.Add(albumImage);
                    }
                }
                else
                {
                    var t = (GalleryImage)galleryItem;

                    searchForImages.Add(t);
                }
            }
            Debug.WriteLine("Returning Search for Images");
            Debug.WriteLine(searchForImages.Count);
            return searchForImages;
        }

        public async Task Favorite(IImage image)
        {
            var endpoint = new ImageEndpoint(this.client);
            await endpoint.FavoriteImageAsync(image.Id);
        }

        public async Task<IEnumerable<IImage>> GetUserSubmissions()
        {
            var endpoint = new AccountEndpoint(this.client);
            var submissions = await endpoint.GetImagesAsync();
            var userSubmissions = submissions as IImage[] ?? submissions.ToArray();
            Debug.WriteLine(userSubmissions.Count());
            foreach (var submission in userSubmissions)
            {
                Debug.WriteLine(submission.Link);
            }
            return userSubmissions;
        }
    }
}

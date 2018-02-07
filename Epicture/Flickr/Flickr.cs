namespace Epicture.Flickr
{
    using System;
    using System.Diagnostics;

    using FlickrNet;

    using global::Imgur.API.Models.Impl;

    public class Flickr
    {
        private const string client = "ca7a4ec8f19c1648a353009971c37ed0";
        private const string clientSecret = "e0f981822b1ed09e";
        private string token = "72157692311419624-6abbf834dbe394b6";
        private string tokenSecret = "0b6387ae1db56515";

        private OAuthRequestToken request = null;

        private FlickrNet.Flickr FlickrApi;
        public Flickr()
        {
            this.FlickrApi = new FlickrNet.Flickr(client, clientSecret);
            this.FlickrApi.OAuthAccessToken = token;
            this.FlickrApi.OAuthAccessTokenSecret = tokenSecret;
        }

        public string GetAuthUrl()
        {
            var flickr = new FlickrNet.Flickr("ca7a4ec8f19c1648a353009971c37ed0", "e0f981822b1ed09e");
            request = flickr.OAuthGetRequestToken("http://Local");
            var url = flickr.OAuthCalculateAuthorizationUrl(
                   request.Token,
                FlickrNet.AuthLevel.Read | FlickrNet.AuthLevel.Write | FlickrNet.AuthLevel.Delete,
                true);
            Console.WriteLine(url);
            return (url);
        }

        public void GetAccessToken(string token)
        {
            var access = this.FlickrApi.OAuthGetAccessToken(this.request, token);
            this.token = access.Token;
            this.tokenSecret = access.TokenSecret;
        }

        public PhotoCollection getImages(string tags, Int32 numberOfResultsPerPage)
        {
            var options = new PhotoSearchOptions
            {
                Tags = tags,
                PerPage = numberOfResultsPerPage,
                SortOrder = PhotoSearchSortOrder.InterestingnessDescending
            };
            var photos = this.FlickrApi.PhotosSearch(options);
            foreach (var t in photos)
            {
                Debug.WriteLine(t.LargeUrl);
            }
            return (photos);
        }

        public void UploadPhoto()
        {
            this.FlickrApi.UploadPicture("Poc.jpg");
        }
    }
}
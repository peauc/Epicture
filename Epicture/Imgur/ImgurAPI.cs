namespace Epicture.Imgur
{
    using System;
    using System.Windows;

    using global::Imgur.API.Authentication.Impl;
    using global::Imgur.API.Endpoints.Impl;
    using global::Imgur.API.Enums;

    public class ImgurAPI
    {
        private const string ClientID = "";
        private const string SecretID = "";

        private ImgurClient client;
   
        ImgurAPI()
        {
            var client = new ImgurClient("CLIENT_ID");
            var endpoint = new OAuth2Endpoint(client);
            var authorizationUrl = endpoint.GetAuthorizationUrl(OAuth2ResponseType.Token);
        }

        public void Connect()
        {
            
        }
    }
}
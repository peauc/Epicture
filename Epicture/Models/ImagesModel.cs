using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.Models
{
    using FlickrNet;

    class ImagesModel
    {

        private Photo photo;

        ImagesModel(Photo photo)
        {
            this.photo = photo;
        }

        private string url;

        public string URL
        {
            get
            {
                return (this.url);
            }
            set
            {
                this.url = value;
            }
        }

        public bool IsFavorited {
            get
            {
                return (this.photo.DateFavorited is null);
            }
        }
    }
}

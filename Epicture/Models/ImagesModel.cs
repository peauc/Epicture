using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.Models
{
    class ImagesModel
    {
        ImagesModel() {}

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


        private bool isFavorited;

        public bool IsFavorited {
            get
            {
                return (this.isFavorited);
            }
            set
            {
                this.isFavorited = value;
            } 
        }
    }
}

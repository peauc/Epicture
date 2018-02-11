using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.Models.Pages
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using Windows.Storage.Pickers;

    using Epicture.Annotations;
    using Epicture.Commands;
    using Epicture.Tools;

    public class UploadModel : INotifyPropertyChanged
    {
        public UploadModel()
        {
            this.StartExplorerCommand = new AddCommand(this.StartExplorer);
            this.StartUploadCommand = new AddCommand(this.StartUpload);
        }

        private string search;

        private string title;

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Search
        {
            get => search;
            set => search = value;
        }

        public ICommand StartExplorerCommand { get; private set; }
        public ICommand StartUploadCommand { get; private set; }

        private async Task<Windows.Storage.StorageFile> StartExplorerAndGetFileName()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Search = file.Name;
            }
            return (file);
        }

        public void StartUpload(object o)
        {
            if (!string.IsNullOrEmpty(Search))
            {
                Imgur imgur = new Imgur();
                imgur.UploadImage(Search, Title, Description);
            }
        }

        public void StartExplorer(object o)
        { 
            var t = this.StartExplorerAndGetFileName();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

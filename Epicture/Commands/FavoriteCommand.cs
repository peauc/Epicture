namespace Epicture.Commands
{
    using System;

    using Epicture.Models;

    public class FavoriteCommand : System.Windows.Input.ICommand
    {
        private readonly ImageModel im;

        public FavoriteCommand(ImageModel im)
        {
            this.im = im;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => this.im.Image != null;

        public async void Execute(object parameter)
        {
            var image = this.im.Image;
            if (image != null)
            {
                await App.Api.Favorite(image);
                this.im.IsFavorite = !this.im.IsFavorite;
            }
        }

        public void FireCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

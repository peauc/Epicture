namespace Epicture.Commands
{
    using System;

    using Epicture.Models.Pages;

    public class RefreshCommand : System.Windows.Input.ICommand
    {
        private readonly FeedModel mpd;

        public RefreshCommand(FeedModel mpd)
        {
            this.mpd = mpd;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => this.mpd.Refresh();

        public void FireCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

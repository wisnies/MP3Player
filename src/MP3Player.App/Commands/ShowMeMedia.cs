using MP3Player.App.ViewModels;
using System;

namespace MP3Player.App.Commands
{
  public class ShowMeMedia : CommandBase
  {
    private TrackViewModel trackViewModel;

    public ShowMeMedia(TrackViewModel trackViewModel)
    {
      this.trackViewModel = trackViewModel;
    }

    public override void Execute(object? parameter)
    {

      var newPosition = TimeSpan.FromMilliseconds(trackViewModel.Value);
      trackViewModel.MediaPlayer.Position = newPosition;

      var x1 = 1;
      var x2 = 1;
      var x3 = 1;
      var x4 = 1;
      var x5 = 1;
      var x6 = 1;
    }
  }
}

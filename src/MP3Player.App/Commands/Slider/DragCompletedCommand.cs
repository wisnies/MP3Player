using MP3Player.App.ViewModels;
using System;

namespace MP3Player.App.Commands.Slider
{
  public class DragCompletedCommand : CommandBase
  {
    private readonly TrackViewModel _viewModel;

    public DragCompletedCommand(TrackViewModel viewModel)
    {
      _viewModel = viewModel;

    }
    public override void Execute(object? parameter)
    {
      if (parameter is TimeSpan newPosition)
      {
        _viewModel.MediaPlayer.Position = newPosition;
      }
      _viewModel.IsDraggingSlider = false;
    }
  }
}

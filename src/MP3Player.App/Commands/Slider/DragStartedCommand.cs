using MP3Player.App.ViewModels;

namespace MP3Player.App.Commands.Slider
{
  public class DragStartedCommand : CommandBase
  {
    private readonly TrackViewModel _viewModel;

    public DragStartedCommand(TrackViewModel viewModel)
    {
      _viewModel = viewModel;

    }
    public override void Execute(object? parameter)
    {
      _viewModel.IsDraggingSlider = true;
    }
  }
}

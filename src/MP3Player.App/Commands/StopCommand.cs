using MP3Player.App.ViewModels;
using System.ComponentModel;

namespace MP3Player.App.Commands
{
  public class StopCommand : CommandBase
  {
    private readonly TrackViewModel _viewModel;

    public StopCommand(TrackViewModel viewModel)
    {
      _viewModel = viewModel;
      _viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    public override bool CanExecute(object? parameter)
    {
      return _viewModel.IsPlaying && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
      _viewModel.IsPlaying = false;
      _viewModel.MediaPlayer.Stop();
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(TrackViewModel.IsPlaying))
      {
        OnCanExecuteChanged();
      }
    }
  }
}

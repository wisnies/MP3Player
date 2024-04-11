using MP3Player.App.ViewModels;
using System.ComponentModel;

namespace MP3Player.App.Commands
{
  public class PauseCommand : CommandBase
  {
    private readonly TrackViewModel _viewModel;

    public PauseCommand(TrackViewModel viewModel)
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
      _viewModel.MediaPlayer.Pause();
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

using MP3Player.App.ViewModels;
using System.ComponentModel;

namespace MP3Player.App.Commands
{
  public class PlayCommand : CommandBase
  {
    private readonly TrackViewModel _viewModel;

    public PlayCommand(TrackViewModel viewModel)
    {
      _viewModel = viewModel;
      _viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    public override bool CanExecute(object? parameter)
    {
      return _viewModel.CanPlay && base.CanExecute(parameter);
    }

    public override void Execute(object? parameter)
    {
      _viewModel.IsPlaying = true;
      _viewModel.MediaPlayer.Play();
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(TrackViewModel.CanPlay))
      {
        OnCanExecuteChanged();
      }
    }
  }
}

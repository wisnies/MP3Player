using Microsoft.Win32;
using MP3Player.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace MP3Player.App.Commands.MediaPlayer
{
  public class OpenTrackAsyncCommand : CommandBaseAsync
  {
    private readonly TrackViewModel _viewModel;

    public OpenTrackAsyncCommand(TrackViewModel viewModel)
    {
      _viewModel = viewModel;
    }

    private string _fileName = string.Empty;
    public override async Task ExecuteAsync(object? parameter)
    {
      OpenFileDialog fileDialog = new()
      {
        Multiselect = false,
        DefaultExt = ".mp3"
      };

      bool? dialogOk = fileDialog.ShowDialog();

      if (dialogOk == true)
      {
        _fileName = fileDialog.FileName;
        _viewModel.MediaPlayer.Open(new Uri(_fileName));
        do
        {
          await Task.Delay(10);
        } while (!_viewModel.MediaPlayer.NaturalDuration.HasTimeSpan);

        _viewModel.TrackName = fileDialog.SafeFileName;
        _viewModel.TrackProgress = 0;
        _viewModel.TrackDuration = _viewModel.MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        _viewModel.DisplayTrackDuration = TimeSpan.FromSeconds(_viewModel.MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds).ToString(@"hh\:mm\:ss");
      }
    }
  }
}

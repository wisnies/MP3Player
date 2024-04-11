using Microsoft.Win32;
using MP3Player.App.ViewModels;
using System.Threading.Tasks;

namespace MP3Player.App.Commands
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
        _viewModel.MediaPlayer.Open(new System.Uri(_fileName));
        do
        {
          await Task.Delay(10);
        } while (!_viewModel.MediaPlayer.NaturalDuration.HasTimeSpan);
        _viewModel.TrackName = fileDialog.SafeFileName;
        var minutes = _viewModel.MediaPlayer.NaturalDuration.TimeSpan.Minutes.ToString();
        var seconds = _viewModel.MediaPlayer.NaturalDuration.TimeSpan.Seconds.ToString();

        _viewModel.TrackLength = $"{minutes}:{seconds}";
        _viewModel.Duration = _viewModel.MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;

        //TBLength.Text = _mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds.ToString();
      }
    }
  }
}

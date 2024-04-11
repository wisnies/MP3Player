using Microsoft.Win32;
using MP3Player.App.ViewModels;

namespace MP3Player.App.Commands
{
  public class OpenTrackCommand : CommandBase
  {
    private readonly TrackViewModel _viewModel;
    private string _fileName = string.Empty;

    public OpenTrackCommand(TrackViewModel viewModel)
    {
      _viewModel = viewModel;
    }
    public override void Execute(object? parameter)
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
        _viewModel.TrackName = fileDialog.SafeFileName;
        _viewModel.MediaPlayer.Open(new System.Uri(_fileName));

        var minutes = _viewModel.MediaPlayer.NaturalDuration.TimeSpan.Minutes.ToString();
        var seconds = _viewModel.MediaPlayer.NaturalDuration.TimeSpan.Seconds.ToString();

        _viewModel.TrackLength = $"{minutes}:{seconds}";

        //TBLength.Text = _mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds.ToString();
      }
    }
  }
}

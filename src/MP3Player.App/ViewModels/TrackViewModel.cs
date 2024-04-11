using MP3Player.App.Commands;
using System.Windows.Input;
using System.Windows.Media;

namespace MP3Player.App.ViewModels
{
  public class TrackViewModel : ViewModelBase
  {
    private MediaPlayer _mediaPlayer = new();
    public MediaPlayer MediaPlayer { get { return _mediaPlayer; } }

    private bool _isPlaying = false;
    public bool IsPlaying
    {
      get { return _isPlaying; }
      set
      {
        _isPlaying = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(CanPlay));
      }
    }

    private string _trackName = string.Empty;
    public string TrackName
    {
      get { return _trackName; }
      set
      {
        _trackName = value;
        OnPropertyChanged();
        OnPropertyChanged(nameof(CanPlay));
      }
    }

    private string _trackLength = "0:00";
    public string TrackLength
    {
      get { return _trackLength; }
      set
      {
        _trackLength = value;
        OnPropertyChanged();
      }
    }

    private bool _hasTrackSelected => !string.IsNullOrEmpty(_trackName);
    public bool CanPlay =>
      _hasTrackSelected &&
      !_isPlaying;

    public ICommand OpenTrackCommand { get; }
    public ICommand PlayCommand { get; }
    public ICommand PauseCommand { get; }
    public ICommand StopCommand { get; }
    public ICommand ShowMeMedia { get; }


    private double _duration;
    public double Duration
    {
      get { return _duration; }
      set
      {
        _duration = value;
        OnPropertyChanged();
      }
    }
    private double _value;
    public double Value
    {
      get
      {
        return _value;
      }
      set
      {
        _mediaPlayer.Pause();
        _value = value;
        OnPropertyChanged();
        ShowMeMedia.Execute(this);
        _mediaPlayer.Play();
      }
    }

    public TrackViewModel()
    {
      OpenTrackCommand = new OpenTrackAsyncCommand(this);
      PlayCommand = new PlayCommand(this);
      PauseCommand = new PauseCommand(this);
      StopCommand = new StopCommand(this);
      ShowMeMedia = new ShowMeMedia(this);
    }
  }
}

using MP3Player.App.Commands.MediaPlayer;
using MP3Player.App.Commands.Slider;
using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MP3Player.App.ViewModels
{
  public class TrackViewModel : ViewModelBase
  {
    private readonly MediaPlayer _mediaPlayer;
    public MediaPlayer MediaPlayer { get { return _mediaPlayer; } }

    private readonly DispatcherTimer _timer;

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

    private bool _isDraggingSlider = false;
    public bool IsDraggingSlider
    {
      get { return _isDraggingSlider; }
      set
      {
        _isDraggingSlider = value;
        OnPropertyChanged();
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

    private double _trackProgress;
    public double TrackProgress
    {
      get { return _trackProgress; }
      set
      {
        _trackProgress = value;
        OnPropertyChanged();
      }
    }
    private string _displayTrackProgress = "00:00:00";
    public string DisplayTrackProgress
    {
      get { return _displayTrackProgress; }
      set
      {
        _displayTrackProgress = value;
        OnPropertyChanged();
      }
    }
    private double _trackDuration = 1;
    public double TrackDuration
    {
      get { return _trackDuration; }
      set
      {
        _trackDuration = value;
        OnPropertyChanged();
      }
    }

    private string _displayTrackDuration = "00:00:00";
    public string DisplayTrackDuration
    {
      get
      {
        return _displayTrackDuration;
      }
      set
      {
        _displayTrackDuration = value;
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
    public ICommand DragStartedCommand { get; }
    public ICommand DragCompletedCommand { get; }


    public TrackViewModel()
    {
      OpenTrackCommand = new OpenTrackAsyncCommand(this);
      PlayCommand = new PlayCommand(this);
      PauseCommand = new PauseCommand(this);
      StopCommand = new StopCommand(this);

      DragStartedCommand = new DragStartedCommand(this);
      DragCompletedCommand = new DragCompletedCommand(this);

      _mediaPlayer = new();
      _timer = new()
      {
        Interval = TimeSpan.FromSeconds(1)
      };
      _timer.Tick += TimerTick;
      _timer.Start();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
      if (IsPlaying && !IsDraggingSlider)
      {
        _trackProgress = _mediaPlayer.Position.TotalSeconds;
        _displayTrackProgress = TimeSpan.FromSeconds(_trackProgress).ToString(@"hh\:mm\:ss");

        if (_trackProgress >= _trackDuration)
        {
          StopCommand.Execute(this);
        }

        OnPropertyChanged(nameof(DisplayTrackProgress));
        OnPropertyChanged(nameof(TrackProgress));
      }
    }
  }
}

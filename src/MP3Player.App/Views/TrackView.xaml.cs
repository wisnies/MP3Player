using MP3Player.App.ViewModels;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MP3Player.App.Views
{
  public partial class TrackView : UserControl
  {
    private int _offset = 0;
    private bool _isScrollingToRight = true;
    private DispatcherTimer _timer;

    public TrackView()
    {
      InitializeComponent();
      string imgPath = $"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString()}\\Assets\\MusicIcon.png";

      imgIcon.Source = new BitmapImage(new Uri(imgPath));

      _timer = new()
      {
        Interval = TimeSpan.FromMilliseconds(100)
      };
      _timer.Tick += TimerTick;
      _timer.Start();
    }

    private void sliProgress_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
    {
      TrackViewModel? viewModel = DataContext as TrackViewModel;
      if (viewModel != null && viewModel.DragCompletedCommand.CanExecute(null))
      {
        if (sender is Slider slider)
        {
          var newPosition = TimeSpan.FromSeconds(slider.Value);
          viewModel.DragCompletedCommand.Execute(newPosition);

        }
      }
    }

    private void sliProgress_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
    {
      TrackViewModel? viewModel = DataContext as TrackViewModel;
      if (viewModel != null && viewModel.DragStartedCommand.CanExecute(null))
      {
        viewModel.DragStartedCommand.Execute(null);
      }
    }

    private void TimerTick(object? sender, EventArgs e)
    {
      var z = svTrackName;

      if (_offset < z.ScrollableWidth && _isScrollingToRight)
      {
        _offset += 1;
      }
      if (_offset > 0 && !_isScrollingToRight)
      {
        _offset -= 1;
      }
      if (_offset >= z.ScrollableWidth && _isScrollingToRight)
      {
        _isScrollingToRight = false;
      }
      if (_offset <= 0 && !_isScrollingToRight)
      {
        _isScrollingToRight = true;
      }

      z.ScrollToHorizontalOffset(_offset);
    }
  }
}

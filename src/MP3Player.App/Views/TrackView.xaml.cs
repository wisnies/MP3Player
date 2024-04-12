using MP3Player.App.ViewModels;
using System;
using System.Windows.Controls;

namespace MP3Player.App.Views
{
  public partial class TrackView : UserControl
  {
    public TrackView()
    {
      InitializeComponent();
    }

    private void sliProgress_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
    {
      //tbProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
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
  }
}

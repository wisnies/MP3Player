namespace MP3Player.App.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    public ViewModelBase CurrentViewModel { get; }

    public MainViewModel()
    {
      CurrentViewModel = new TrackViewModel();
    }
  }
}

using MP3Player.App.ViewModels;
using System.Windows;

namespace MP3Player.App
{
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      MainWindow = new MainWindow()
      {
        DataContext = new MainViewModel()
      };

      MainWindow.Show();

      base.OnStartup(e);
    }
  }
}

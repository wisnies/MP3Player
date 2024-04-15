using System.Windows;

namespace MP3Player.App.Commands.Window
{
  public class CloseWindowCommand : CommandBase
  {
    public override void Execute(object? parameter)
    {
      Application.Current.Shutdown();
    }
  }
}

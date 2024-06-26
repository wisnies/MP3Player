﻿using System.Threading.Tasks;

namespace MP3Player.App.Commands
{
  public abstract class CommandBaseAsync : CommandBase
  {
    private bool _isExecuting;
    public bool IsExecuting
    {
      get { return _isExecuting; }
      set
      {
        _isExecuting = value;
        OnCanExecuteChanged();
      }
    }
    public override bool CanExecute(object? parameter)
    {
      return !IsExecuting && base.CanExecute(parameter);
    }
    public override async void Execute(object? parameter)
    {
      IsExecuting = true;
      try
      {
        await ExecuteAsync(parameter);
      }
      finally
      {
        IsExecuting = false;
      }
    }
    public abstract Task ExecuteAsync(object? parameter);
  }
}

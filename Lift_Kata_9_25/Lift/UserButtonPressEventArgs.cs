using System;

namespace LiftKata
{
  public class UserButtonPressEventArgs : EventArgs
  {
    public int DestinationFloor;

    public UserButtonPressEventArgs(int floor)
    {
      this.DestinationFloor = floor;
    }
  }
}
using System;

namespace LiftKata
{
  public class Lift
  {
    public int CurrentFloor { get; set; }
    public LiftCall CurrentRequest { get; set; }

    public LiftStatus CurrentStatus { get; set; }

    public LiftDirection CurrentDirection { get; set; }
    public int Floors { get; internal set; }

    public int ID { get; internal set; }

    public event EventHandler<UserButtonPressEventArgs> UserButtonPressed;

    protected virtual void OnUserButtonPressed(UserButtonPressEventArgs e)
    {
      UserButtonPressed?.Invoke(this, e);
    }

    public Lift(int id)
    {
      ID = id;
    }

    public Lift()
    {
      ID = 0;
    }


    public void UserSelectsDestination(int floor)
    {
      this.UserDestination = floor;
      OnUserButtonPressed(new UserButtonPressEventArgs(floor));
    }


    public int TopFloor
    {
      get { return Floors; }
    }

    public int UserDestination { get; private set; }

    public bool Request(LiftCall lr)
    {
      if (this.CurrentStatus == LiftStatus.Awaiting)
      {
        this.CurrentRequest = lr;
        this.CurrentStatus = LiftStatus.Responding;
        this.ResolveDirection();
        return true;
      }
      return false;
    }

    private void ResolveDirection()
    {
      int reqFloor = this.CurrentRequest.Floor;
      int curFloor = this.CurrentFloor;

      int floorDelta = reqFloor - curFloor;
      if ( floorDelta > 0)
      {
        this.CurrentDirection = LiftDirection.Up;
      }
      else
      {
        this.CurrentDirection = LiftDirection.Down;
      }
    }
  }

  public enum LiftDirection
  {
    Down,
    Up
  }

  public enum LiftStatus
  {
    Awaiting,
    Responding,
    Delivering
  }
}
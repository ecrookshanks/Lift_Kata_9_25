using System;
using System.Collections.Generic;

namespace LiftKata.Tests
{
  public class DispatchSystem
  {
    public DispatchSystem()
    {
      this.Lifts = new List<Lift>();
      this.Lifts.Add(new Lift(1));
    }

    public List<Lift> Lifts { get; internal set; }

    internal Lift FindAvailableLiftForCall(LiftCall lr)
    {
      foreach (var lift in Lifts)
      {
        if (lift.Request(lr))
        {
          return lift;
        }
      }
      return null;
    }
  }
}
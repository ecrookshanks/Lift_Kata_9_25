using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiftKata.Tests
{
  public class DispatchSystemTests
  {
    [Fact]
    public void DispatchSystemCreatedWithDefaultSingleLift()
    {
      DispatchSystem disp = new DispatchSystem();

      Assert.Single(disp.Lifts);
    }

    [Fact]
    public void DispatchCreatesAndSendsRequestToDefaultLift()
    {
      DispatchSystem disp = new DispatchSystem();

      LiftCall lr = new LiftCall(LiftDirection.Down, 12);

      Lift lift = disp.FindAvailableLiftForCall(lr);

      Assert.Equal(1, lift.ID);

    }

  }
}

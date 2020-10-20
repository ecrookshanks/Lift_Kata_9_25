using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiftKata.Tests
{
  public class DispatchSystemTests
  {
    private DispatchSystem sut;

    public DispatchSystemTests()
    {
      sut = new DispatchSystem();
    }

    [Fact]
    public void DispatchSystemCreatedWithDefaultSingleLift() =>  Assert.Single(sut.Lifts);
    

    [Fact]
    public void DispatchCreatesAndSendsRequestToDefaultLift()
    {

      LiftCall lr = new LiftCall(LiftDirection.Down, 12);

      Lift lift = sut.FindAvailableLiftForCall(lr);

      Assert.Equal(1, lift.ID);

    }

  }
}

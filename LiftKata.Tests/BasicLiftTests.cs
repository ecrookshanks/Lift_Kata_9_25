using System;
using System.ComponentModel;
using System.Net;
using Xunit;
using LiftKata;

namespace LiftKata.Tests
{
  public class BasicLiftTests
  {
    [Fact]
    public void LiftHasCurrentLocationOfGroundWhenInitialized()
    {
      Lift lift = LiftFactory.CreateLift();

      Assert.Equal(0, lift.CurrentFloor);
      Assert.Equal(LiftStatus.Awaiting, lift.CurrentStatus);
      
    }

    [Fact]
    public void LiftCanReceiveRequest()
    {
      Lift lift = null;
      
      LiftCall lr = new LiftCall(LiftDirection.Down, 12);

      lift = LiftFactory.CreateLift();
      lift.Request(lr);

      LiftCall r = lift.CurrentRequest;

      Assert.NotNull(r);
      Assert.Equal(LiftDirection.Down, r.Direction);
      Assert.Equal(12, r.Floor);
    }

    [Fact]
    public void LiftCanAcceptRequestIfWaitingForOrderAndChangesStatusToResponding()
    {
      Lift lift = LiftFactory.CreateLift();

      LiftCall lr = new LiftCall(LiftDirection.Down, 12);

      bool accepted = lift.Request(lr);

      Assert.True(accepted);
      Assert.Equal(LiftStatus.Responding, lift.CurrentStatus);

    }

    [Fact]
    public void LiftRejectsRequestIfRespondingOrDelivering()
    {
      Lift lift = LiftFactory.CreateLift();
      lift.CurrentStatus = LiftStatus.Responding;

      LiftCall lr = new LiftCall(LiftDirection.Down, 12);

      bool accepted = lift.Request(lr);

      Assert.False(accepted);
      Assert.NotEqual(LiftStatus.Awaiting, lift.CurrentStatus);
    }

    [Fact]
    public void LiftIndicatesMovingUpTowardsFloorCall()
    {
      Lift lift = LiftFactory.CreateLift();

      LiftCall lr = new LiftCall(LiftDirection.Down, 12);

      bool accepted = lift.Request(lr);

      Assert.True(accepted);
      Assert.Equal(LiftStatus.Responding, lift.CurrentStatus);
      Assert.Equal(LiftDirection.Up, lift.CurrentDirection);
    }

    [Fact]
    public void LiftIndicatesMovingDownTowardFloorCall()
    {
      Lift lift = LiftFactory.CreateLift();
      lift.CurrentFloor = 12;

      LiftCall lr = new LiftCall(LiftDirection.Down, 2);

      bool accepted = lift.Request(lr);

      Assert.True(accepted);
      Assert.Equal(LiftStatus.Responding, lift.CurrentStatus);
      Assert.Equal(LiftDirection.Down, lift.CurrentDirection);
    }

    [Fact]
    public void LiftCreatedWithNumberOfFloors()
    {
      Lift lift = LiftFactory.CreateLift(15);

      Assert.Equal(15, lift.TopFloor);
    }
  
    [Fact]
    public void LiftGeneratesEventWithArgumentsWhenUserPressesFloor()
    {
      Lift lift = LiftFactory.CreateLift();

      var arg = Assert.Raises<UserButtonPressEventArgs>(handler => lift.UserButtonPressed += handler, 
                                              handler => lift.UserButtonPressed -= handler, 
                                              () => lift.UserSelectsDestination(10));

      Assert.Equal(10, arg.Arguments.DestinationFloor);
    }
  
  }
}

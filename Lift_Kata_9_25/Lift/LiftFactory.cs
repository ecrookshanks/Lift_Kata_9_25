namespace LiftKata
{
  public class LiftFactory
  {
    // Ensure no instances created
    private LiftFactory()
    {  }

    public static Lift CreateLift() => new Lift();

    public static Lift CreateLift(int numFloors) => new Lift() { Floors = 15 };
 
  }
}
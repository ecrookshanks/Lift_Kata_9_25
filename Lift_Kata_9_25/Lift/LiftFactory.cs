namespace LiftKata
{
  public class LiftFactory
  {
    // Ensure no instances created
    private LiftFactory()
    {

    }
    public static Lift CreateLift()
    {
      return new Lift();
    }

    public static Lift CreateLift(int numFloors)
    {
      return new Lift() { Floors = 15 };
    }
  }
}
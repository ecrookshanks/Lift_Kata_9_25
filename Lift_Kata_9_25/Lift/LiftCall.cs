namespace LiftKata
{
  public class LiftCall
  {
    public LiftDirection Direction { get; set; }
    public int Floor { get; set; }


    public LiftCall(LiftDirection direction, int floor)
    {
      this.Direction = direction;
      this.Floor = floor;
    }
  }
}
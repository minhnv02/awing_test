namespace Domain.Entities;

public class TreasureMap
{
    public int Id { get; set; }   // Primary Key
    public int Rows { get; set; }
    public int Cols { get; set; }
    public int P { get; set; }

    // Mỗi TreasureMap có nhiều Cell
    public ICollection<MapCell> Cells { get; set; } = new List<MapCell>();
}

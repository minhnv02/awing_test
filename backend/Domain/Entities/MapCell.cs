namespace Domain.Entities;

public class MapCell
{
    public int Id { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }
    public int ChestNumber { get; set; }

    public int TreasureMapId { get; set; }
    public TreasureMap TreasureMap { get; set; } = null!;
}

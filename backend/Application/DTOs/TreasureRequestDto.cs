namespace Application.DTOs;

public class TreasureRequestDto
{
    public int N { get; set; }
    public int M { get; set; }
    public int P { get; set; }
    public int[][] Matrix { get; set; } = Array.Empty<int[]>();
}

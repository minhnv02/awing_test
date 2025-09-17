using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class TreasureService : ITreasureService
{
    public double FindMinFuel(TreasureMap map)
    {
        int n = map.Rows, m = map.Cols, p = map.P;
        var positions = new List<(int x, int y)>[p + 1];
        for (int i = 0; i <= p; i++) positions[i] = new List<(int, int)>();

        foreach (var cell in map.Cells)
        {
            positions[cell.ChestNumber].Add((cell.Row, cell.Col));
        }

        // Xuất phát
        positions[0].Add((1, 1));

        double[] dp = new double[p + 1];
        for (int i = 0; i <= p; i++) dp[i] = double.MaxValue;
        dp[0] = 0;

        for (int k = 0; k < p; k++)
        {
            foreach (var (x1, y1) in positions[k])
            {
                foreach (var (x2, y2) in positions[k + 1])
                {
                    double dist = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                    dp[k + 1] = Math.Min(dp[k + 1], dp[k] + dist);
                }
            }
        }

        return dp[p];
    }
}

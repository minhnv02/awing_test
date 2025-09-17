using Domain.Entities;

namespace Application.Interfaces;

public interface ITreasureService
{
    double FindMinFuel(TreasureMap map);
}

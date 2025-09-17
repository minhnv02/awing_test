using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreasureController : ControllerBase
{
    private readonly ITreasureService _treasureService;
    private readonly TreasureDbContext _db;

    public TreasureController(ITreasureService treasureService, TreasureDbContext db)
    {
        _treasureService = treasureService;
        _db = db;
    }

    [HttpPost("find")]
    public IActionResult FindTreasure([FromBody] TreasureRequestDto req)
    {
        // Build entity
        var map = new TreasureMap
        {
            Rows = req.N,
            Cols = req.M,
            P = req.P
        };

        for (int i = 0; i < req.N; i++)
        {
            for (int j = 0; j < req.M; j++)
            {
                map.Cells.Add(new MapCell
                {
                    Row = i + 1,
                    Col = j + 1,
                    ChestNumber = req.Matrix[i][j]
                });
            }
        }

        _db.TreasureMaps.Add(map);
        _db.SaveChanges();

        double result = _treasureService.FindMinFuel(map);
        return Ok(result);
    }
}

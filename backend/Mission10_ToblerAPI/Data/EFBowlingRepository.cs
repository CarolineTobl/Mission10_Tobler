using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission10_ToblerAPI.Models;

public class EFBowlingRepository : IBowlingRepository
{
    private readonly BowlingDbContext _context;

    public EFBowlingRepository(BowlingDbContext context)
    {
        _context = context;
    }
    public IEnumerable<BowlerDto> GetAllBowlersWithTeams()
    {
        // Use the .Select() method to project the Bowler entities into BowlerDto objects
        var bowlersWithTeams = _context.Bowlers
            .Include(b => b.Team)
            .Select(b => new BowlerDto
            {
                BowlerId = b.BowlerId,
                BowlerFirstName = b.BowlerFirstName,
                BowlerMiddleInit = b.BowlerMiddleInit,
                BowlerLastName = b.BowlerLastName,
                BowlerAddress = b.BowlerAddress,
                BowlerCity = b.BowlerCity,
                BowlerState = b.BowlerState,
                BowlerZip = b.BowlerZip,
                BowlerPhoneNumber = b.BowlerPhoneNumber,
                TeamName = b.Team.TeamName // This is where we flatten the Team into just the name
            })
            .ToList();

        return bowlersWithTeams;
    }


    // Implement other methods from the interface
}

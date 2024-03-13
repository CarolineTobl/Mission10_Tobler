using System.Collections.Generic;
using System.Threading.Tasks;
using Mission10_ToblerAPI.Models;

public interface IBowlingRepository
{
    IEnumerable<BowlerDto> GetAllBowlersWithTeams();
    // Other repository methods...
}

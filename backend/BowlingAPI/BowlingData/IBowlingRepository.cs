namespace BowlingAPI.BowlingData
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams {  get; }
        IEnumerable<BowlerTeam> getBowlersWithTeamName();
    }
}


namespace BowlingAPI.BowlingData
{
    public class EFBowlerRepository : IBowlingRepository
    {
        private BowlingLeagueContext _context;
        public EFBowlerRepository(BowlingLeagueContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public IEnumerable<BowlerTeam> getBowlersWithTeamName()
        {
            var joineddata = from bowler in _context.Bowlers
                             join team in _context.Teams
                             on bowler.TeamId equals team.TeamId
                             select new
                             {
                                 BowlerId = bowler.BowlerId,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                 TeamName = team.TeamName
                             };
            var BowlerswithTeamNames = joineddata
                .Select(x => new BowlerTeam
                {
                    BowlerId = x.BowlerId,
                    BowlerLastName = x.BowlerLastName,
                    BowlerFirstName = x.BowlerFirstName,
                    BowlerMiddleInit = x.BowlerMiddleInit,
                    BowlerAddress = x.BowlerAddress,
                    BowlerCity = x.BowlerCity,
                    BowlerState = x.BowlerState,
                    BowlerZip = x.BowlerZip,
                    BowlerPhoneNumber = x.BowlerPhoneNumber,
                    TeamName = x.TeamName
                }).Where(x => x.TeamName == "Marlins" || x.TeamName == "Sharks"
                ).ToList();

            return BowlerswithTeamNames;
        }
    }
}

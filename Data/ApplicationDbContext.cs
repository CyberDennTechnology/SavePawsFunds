using Microsoft.EntityFrameworkCore;
using SavePawsFund.Models;

namespace SavePawsFund.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShelterVote> ShelterVotes { get; set; }
        public DbSet<Voter> Voters { get; set; }
    }
}

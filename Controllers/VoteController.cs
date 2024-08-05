using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavePawsFund.Data;
using SavePawsFund.Models;
using System.Threading.Tasks;

namespace SavePawsFund.Controllers
{
    public class VoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Vote(string shelterName, string voterName)
        {
            if (string.IsNullOrWhiteSpace(shelterName) || string.IsNullOrWhiteSpace(voterName))
            {
                // Ideally, add an error message here to notify the user about the missing inputs.
                return RedirectToAction("Index", "Home");
            }

            // Find the shelter vote record
            var shelter = await _context.ShelterVotes.FirstOrDefaultAsync(s => s.ShelterName == shelterName);

            if (shelter == null)
            {
                shelter = new ShelterVote
                {
                    ShelterName = shelterName,
                    VoteCount = 1
                };
                _context.ShelterVotes.Add(shelter);
            }
            else
            {
                shelter.VoteCount++;
                _context.ShelterVotes.Update(shelter);
            }

            // Find the voter record
            var voter = await _context.Voters.FirstOrDefaultAsync(v => v.Email == voterName);

            if (voter == null)
            {
                voter = new Voter
                {
                    Email = voterName,
                    VoteCount = 1
                };
                _context.Voters.Add(voter);
            }
            else
            {
                voter.VoteCount++;
                _context.Voters.Update(voter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}



using System.ComponentModel.DataAnnotations;

namespace SavePawsFund.Models
{
    public class Voter
    {
        [Key]
        public int VoterId { get; set; }
        public string Email { get; set; }
        public int VoteCount { get; set; }

        public Voter()
        {
            Email = string.Empty; // Ensuring non-null value
            VoteCount = 0; // Initialize VoteCount to 0
        }
    }
}

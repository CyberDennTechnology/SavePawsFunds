using System.ComponentModel.DataAnnotations;

namespace SavePawsFund.Models
{
    public class ShelterVote
    {
        [Key]
        public int ShelterId { get; set; }
        public string ShelterName { get; set; }
        public int VoteCount { get; set; }

        public ShelterVote()
        {
            ShelterName = string.Empty; // Ensuring non-null value
            VoteCount = 0; // Initialize VoteCount to 0
        }
    }
}

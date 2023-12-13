using System.ComponentModel.DataAnnotations;

namespace GameRepo.Model
{
    public class Game
    {
        public int Id {get;set;}

        //A game name cannot be null
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        //A genre description cannot be null
        [Required]
        [StringLength(100)]
        public required string Genre { get; set; }

        //A price doesn't require a high precision value
        //Float used to save on space
        [Range(0,1000)]
        public float Price { get; set; }

        //We only need the date, not the time
        public DateTime ReleaseDate { get; set; }
        
        //Game image can be null
        [Url]
        [StringLength(100)]
        public Uri? ImageUri { get; set; }
    }
}
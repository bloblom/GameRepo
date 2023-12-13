using System.ComponentModel.DataAnnotations;

namespace GameRepo.Dto 
{

    public record GameDto(
        int Id,
        [Required] [StringLength(100)] string Name,
        [Required] [StringLength(100)] string Genre,
        [Range(0,1000)] float Price,
        DateTime Release_date,
        [Url] [StringLength(100)] Uri? Image_uri
    );

    public record CreateGameDto(
        [Required] [StringLength(100)] string Name,
        [Required] [StringLength(100)] string Genre,
        [Range(0,1000)] float Price,
        DateTime Release_date,
        [Url] [StringLength(100)] Uri? Image_uri
    );

    public record UpdateGameDto(
        [Required] [StringLength(100)] string Name,
        [Required] [StringLength(100)] string Genre,
        [Range(0,1000)] float Price,
        DateTime Release_date,
        [Url] [StringLength(100)] Uri? Image_uri
    );
}
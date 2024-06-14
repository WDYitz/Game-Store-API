using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos
{
  public record class UpdateGameDto(
    [Required][StringLength(50)] string Title,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate);
}
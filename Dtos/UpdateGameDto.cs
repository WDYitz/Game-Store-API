namespace GameStore.Dtos
{
  public record class UpdateGameDto(int Id, string Title, string Genre, decimal Price, DateOnly ReleaseDate) { }
}
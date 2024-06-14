namespace GameStore.Entities
{
  public class Genre
  {
    public int Id { get; set; }
    public required string Name { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
  }
}
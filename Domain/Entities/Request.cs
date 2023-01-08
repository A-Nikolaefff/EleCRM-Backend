namespace Domain.Entities;

public class Request
{
    public int Id { get; set; } 
    public int Number { get; set; }
    public DateTime Receipt { get; set; }
    public string Note { get; set; } = null!;
}
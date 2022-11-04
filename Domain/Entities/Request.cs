namespace Domain.Entities;

public class Request
{
    public int Id { get; set; } 
    public DateOnly Date { get; set; }
    public string Note { get; set; } = null!;
}
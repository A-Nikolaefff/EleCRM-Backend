namespace Domain.Entities;

public class Request
{
    public int Id { get; set; } 
    public DateTime DateTime { get; set; }
    public string Note { get; set; } = null!;
}
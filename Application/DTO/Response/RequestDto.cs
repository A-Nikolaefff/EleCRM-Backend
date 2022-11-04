namespace Application.DTO.Response;

public class RequestDto
{
    public int Id { get; set; } 
    public DateOnly Date { get; set; }
    public string Note { get; set; } = null!;
}
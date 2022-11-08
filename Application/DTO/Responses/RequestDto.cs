namespace Application.DTO.Response;

public class RequestDto
{
    public int Id { get; set; } 
    public int Number { get; set; }
    public DateOnly ReceiptDate { get; set; }
    public string Note { get; set; } = null!;
}
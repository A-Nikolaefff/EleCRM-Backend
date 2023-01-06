namespace Application.DTO.Requests;

public class UpdateRequestDto
{
    public int Id { get; set; } 
    public DateOnly ReceiptDate { get; set; }
    public string Note { get; set; } = null!;
}
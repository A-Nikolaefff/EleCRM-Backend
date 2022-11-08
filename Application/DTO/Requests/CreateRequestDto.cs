namespace Application.DTO.Requests;

public class CreateRequestDto
{
    public DateOnly ReceiptDate { get; set; }
    public string Note { get; set; } = null!;
}
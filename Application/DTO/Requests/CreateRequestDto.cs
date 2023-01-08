namespace Application.DTO.Requests;

public class CreateRequestDto
{
    public DateTime Receipt { get; set; }
    public string Note { get; set; } = null!;
}
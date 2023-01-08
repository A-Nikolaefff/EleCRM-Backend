namespace Application.DTO.Requests;

public class UpdateRequestDto
{
    public int Id { get; set; } 
    public DateTime Receipt { get; set; }
    public string Note { get; set; } = null!;
}
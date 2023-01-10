namespace Application.DTO;

public class Page<T>
{
    public Page(int totalCount, int entriesPerPage, int currentPageNumber, List<T> entries)
    {
        TotalCount = totalCount;
        EntriesPerPage = entriesPerPage;
        CurrentPageNumber = currentPageNumber;
        Entries = entries;
    }

    public int TotalCount { get; set; }
    public int EntriesPerPage { get; set; }
    public int CurrentPageNumber { get; set; }
    public List<T> Entries { get; set; }
    
    
}
namespace Core
{
    public interface IPageResponse
    {
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        bool All { get; set; }
    }
}

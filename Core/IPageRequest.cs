namespace Core
{
    public interface IPageRequest : IRequest
    {
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        bool All { get; set; }
    }
}

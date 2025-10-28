namespace LibreriaDigital.Api.Dtos
{
    public record CreateBookDto(string Title, string? Author, int? PublishedYear, string? CoverImageUrl);
    public record UpdateBookDto(string? Title, string? Author, int? PublishedYear, string? CoverImageUrl);
    public record BookDto(Guid Id, string Title, string? Author, int? PublishedYear, string? CoverImageUrl, Guid OwnerId);
}

namespace LibreriaDigital.Api.Dtos
{
    public record CreateReviewDto(int Rating, string? Text);
    public record ReviewDto(Guid Id, int Rating, string? Text, Guid UserId, Guid BookId, DateTime CreatedAt);
}

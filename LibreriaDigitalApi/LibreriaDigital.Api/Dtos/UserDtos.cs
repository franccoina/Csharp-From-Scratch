namespace LibreriaDigital.Api.Dtos
{
    public record UserDto(Guid Id, string FirstName, string LastName, string Email);
    public record UpdateUserDto(string? FirstName, string? LastName, string? Email, string? Password);
}

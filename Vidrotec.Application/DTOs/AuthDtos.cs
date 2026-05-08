namespace Vidrotec.Application.DTOs
{
    public sealed class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public sealed class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Expires { get; set; } = string.Empty;
    }
}

namespace StudentManagement.Api.DTOs;

public sealed class StudentResponse
{
    public Guid Id { get; init; }

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public DateOnly DateOfBirth { get; init; }
}

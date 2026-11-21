using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.DTOs;

public sealed class CreateStudentRequest
{
    [Required, StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(255)]
    public string Email { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }
}

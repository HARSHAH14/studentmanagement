using StudentManagement.Api.DTOs;
using StudentManagement.Api.Models;
using StudentManagement.Api.Repositories;

namespace StudentManagement.Api.Services;

public sealed class StudentService(IStudentRepository repository) : IStudentService
{
    public IReadOnlyCollection<StudentResponse> GetAll() =>
        repository.GetAll().Select(Map).ToArray();

    public StudentResponse? GetById(Guid id)
    {
        var student = repository.GetById(id);
        return student is null ? null : Map(student);
    }

    public StudentResponse Create(CreateStudentRequest request)
    {
        var student = repository.Add(new Student
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.Trim(),
            DateOfBirth = request.DateOfBirth
        });

        return Map(student);
    }

    public bool Update(Guid id, UpdateStudentRequest request) => repository.Update(new Student
    {
        Id = id,
        FirstName = request.FirstName.Trim(),
        LastName = request.LastName.Trim(),
        Email = request.Email.Trim(),
        DateOfBirth = request.DateOfBirth
    });

    public bool Delete(Guid id) => repository.Delete(id);

    private static StudentResponse Map(Student student) => new()
    {
        Id = student.Id,
        FirstName = student.FirstName,
        LastName = student.LastName,
        Email = student.Email,
        DateOfBirth = student.DateOfBirth
    };
}

using StudentManagement.Api.DTOs;

namespace StudentManagement.Api.Services;

public interface IStudentService
{
    IReadOnlyCollection<StudentResponse> GetAll();

    StudentResponse? GetById(Guid id);

    StudentResponse Create(CreateStudentRequest request);

    bool Update(Guid id, UpdateStudentRequest request);

    bool Delete(Guid id);
}

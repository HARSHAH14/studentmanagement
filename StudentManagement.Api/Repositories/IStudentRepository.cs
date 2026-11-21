using StudentManagement.Api.Models;

namespace StudentManagement.Api.Repositories;

public interface IStudentRepository
{
    IReadOnlyCollection<Student> GetAll();

    Student? GetById(Guid id);

    Student Add(Student student);

    bool Update(Student student);

    bool Delete(Guid id);
}

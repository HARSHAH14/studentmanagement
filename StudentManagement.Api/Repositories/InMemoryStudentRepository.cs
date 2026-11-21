using StudentManagement.Api.Models;

namespace StudentManagement.Api.Repositories;

public sealed class InMemoryStudentRepository : IStudentRepository
{
    private readonly Dictionary<Guid, Student> students = new();
    private readonly object syncRoot = new();

    public IReadOnlyCollection<Student> GetAll()
    {
        lock (syncRoot)
        {
            return students.Values.Select(Clone).ToArray();
        }
    }

    public Student? GetById(Guid id)
    {
        lock (syncRoot)
        {
            return students.TryGetValue(id, out var student) ? Clone(student) : null;
        }
    }

    public Student Add(Student student)
    {
        lock (syncRoot)
        {
            students.Add(student.Id, Clone(student));
            return Clone(student);
        }
    }

    public bool Update(Student student)
    {
        lock (syncRoot)
        {
            if (!students.ContainsKey(student.Id))
            {
                return false;
            }

            students[student.Id] = Clone(student);
            return true;
        }
    }

    public bool Delete(Guid id)
    {
        lock (syncRoot)
        {
            return students.Remove(id);
        }
    }

    private static Student Clone(Student student) => new()
    {
        Id = student.Id,
        FirstName = student.FirstName,
        LastName = student.LastName,
        Email = student.Email,
        DateOfBirth = student.DateOfBirth
    };
}

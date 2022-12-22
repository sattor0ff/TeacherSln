using Domain.Models;
namespace Infrastructure.Services;
public class TeacherService
{
    private List<Teacher> teachers;

    public TeacherService()
    {
        teachers = new List<Teacher>();
    }
    
    public List<Teacher> GetTeachers()
    {
        return teachers;
    }
    public void AddTeacher(Teacher teacher)
    {
        teachers.Add(teacher);
    }
    public void UpdateTeacher(Teacher teacher)
    {
        var existing = teachers.Find(x=>x.Id == teacher.Id);
        if(existing == null) return;

        existing.FirstName = teacher.FirstName;
        existing.LastName = teacher.LastName;
        existing.Position = teacher.Position;
        existing.ExperienceAmount = teacher.ExperienceAmount;
    }
    public void Delete(int id)
    {
        var existing = teachers.Find(x=>x.Id == id);
        if(existing == null) return;
        teachers.Remove(existing);
    }
}
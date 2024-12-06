using System.Text.Json;
using filelar.Model;

namespace filelar.Service;

public class TeacherService
{
    private string teacherFilePath;
    public TeacherService()
    {
        
        teacherFilePath = "../../../Data/Teacher.json";
        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }

    }

    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        var teachers = GetTeacher();
        teachers.Add(teacher);
        SaveData(teachers);
        Console.WriteLine("Success, Added");
        return teacher;
    }

    public Teacher GetById(Guid teacherId)
    {
        var teachers = GetTeacher();
        foreach(var teacher in teachers)
        {
            if (teacher.Id == teacherId)
            {
                return teacher;
            }
            
        }
        return null;
    }
    public bool DeleteTeacher(Guid teacherId)
    {
        var teacherDeleteId = GetById(teacherId);
        var teachers = GetTeacher();
        if (teachers is null)
        {
            return false;
        }
        teachers.Remove(teacherDeleteId);
        Console.WriteLine("Success, Deleted");

        return true;
    }

    public bool UpdateTeacher(Teacher teacher)
    {
        var teachers = GetTeacher();
        var teachersId = GetById(teacher.Id);
        if (teachersId is null)
        {
            return false;
        }
        var index = teachers.IndexOf(teachersId);
        teachers[index] = teachersId;
        Console.WriteLine("Success, Updated");

        return true;

    }
    public List<Teacher> GetAllTeachers()
    {
        return GetTeacher();
    }

    public List<Teacher> GetTeacher()
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
        return teachers;
    }

    public void SaveData(List<Teacher> teachers)
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        File.WriteAllText(teachersJson, teachersJson);
    }
}

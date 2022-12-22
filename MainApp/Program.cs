using Domain.Models;
using Infrastructure.Services;

System.Console.WriteLine("Insert: show, insert, update, delete.");

var teacherService = new TeacherService();
int counter = 1;
while(true)
{
    string option = Console.ReadLine();
    if(option == "stop") break;

    _ = option switch
    {
        "show" => Show(),
        "update" => Update(),
        "delete" => Delete(),
        "insert" => Insert(),
        _ => false,
    };
    System.Console.WriteLine("\nInsert: show, insert, update, delete.\n");
}


bool Show()
{
    var teachers = teacherService.GetTeachers();
    System.Console.WriteLine($"Id     FirstName     LastName     Position     ExperienceAmount");
    foreach(var te in teachers)
    {
        System.Console.WriteLine($"{te.Id}       {te.FirstName}     {te.LastName}     {te.Position}     {te.ExperienceAmount}");
    }
    return true;
}

bool Insert()
{
    var teacher = new Teacher(counter);
    System.Console.Write("Your FirstName: ");
    teacher.FirstName = Console.ReadLine();

    System.Console.Write("Your LastName: ");
    teacher.LastName = Console.ReadLine();

    System.Console.Write("Your Position: ");
    teacher.Position = Console.ReadLine();

    System.Console.Write("Your ExperienceAmount: ");
    teacher.ExperienceAmount = Convert.ToInt32(Console.ReadLine());

    teacherService.AddTeacher(teacher);
    counter++;

    return true;
}

bool Update()
{
    System.Console.Write("Teacher ID for Update: ");
    int id = Convert.ToInt32(Console.ReadLine());
    var teacher = new Teacher(id);
    System.Console.Write("Your Updated FirstName: ");
    teacher.FirstName = Console.ReadLine();

    System.Console.Write("Your Updated LastName: ");
    teacher.LastName = Console.ReadLine();

    System.Console.Write("Your Position: ");
    teacher.Position = Console.ReadLine();

    System.Console.Write("Your ExperienceAmount: ");
    teacher.ExperienceAmount = Convert.ToInt32(Console.ReadLine());

    teacherService.UpdateTeacher(teacher);
    return true;
}

bool Delete()
{
    System.Console.Write("Teacher ID to Delete: ");
    int id = Convert.ToInt32(Console.ReadLine());
    teacherService.Delete(id);
    return true;
}
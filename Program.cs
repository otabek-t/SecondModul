using filelar.Model;
using filelar.Service;

namespace filelar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunFrontEnd();
        }
        public static void RunFrontEnd()
        {
            var teacherService = new TeacherService();

            while (true)
            {
                
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Upddate");
                Console.WriteLine("4. GetAll");
                Console.WriteLine("5. GetById");
                Console.Write("Enter : ");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    var teacher = new Teacher();
                    Console.WriteLine("Teacher's Window");
                    Console.WriteLine();
                    Console.WriteLine("First Name: ");
                    teacher.FirstName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    teacher.LastName = Console.ReadLine();
                    Console.WriteLine("Subject: ");
                    teacher.Subject = Console.ReadLine();
                    Console.WriteLine("Age: ");
                    teacher.Age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Gender: ");
                    teacher.Gender = Console.ReadLine();

                    teacherService.AddTeacher(teacher);
                }
                else if (option == 2)
                {
                    Console.Write("Enter id to delete : ");
                    var id = Guid.Parse(Console.ReadLine());
                    var teachFromFunc = teacherService.DeleteTeacher(id);
                    Console.WriteLine(teachFromFunc);
                }

               
            }

        }
    }
}

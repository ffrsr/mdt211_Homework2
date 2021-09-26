using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_2
{
    enum Menu
    {
        RegisterNewActivityStudent = 1, RegisterNewActivityTeacher, GetListPersons
    }

    class Program
    {

        static PersonList ActivityList;

        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.ActivityList = new PersonList();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }

        static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration activity application");
            Console.WriteLine("-----------------------------------------");
        }

        static void PrintListMenu()
        {
            Console.WriteLine("1.Register new activity for Student.");
            Console.WriteLine("2.Register new activity for Teacher.");
            Console.WriteLine("3.Get List Person.");

        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu :");

            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewActivityStudent)
            {
                ShowInputRegisterNewActivityForStudentScreen();
            }
            else if (menu == Menu.RegisterNewActivityTeacher)
            {
                ShowInputRegisterNewActivityForTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }

        static void ShowInputRegisterNewActivityForStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterActivityForStudent();

            int totalActivityForStudent = TotalNewActivityForStudents();
            InputNewActivityForStudentFromKeyboard(totalActivityForStudent);
        }

        static void ShowInputRegisterNewActivityForTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterActivityForTeacher();

            int totalActivityForTeacher = TotalNewTeacher();
            InputNewActivityForTeacherFromKeyboard(totalActivityForTeacher);
        }

        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.ActivityList.FetchPersonsList();
            InputExitFromKeyboard();
        }

        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.Write("Input :");
                text = Console.ReadLine();
            }
            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewActivityForTeacherFromKeyboard(int totalActivityForTeacher)
        {
            for (int i = 0; i < totalActivityForTeacher; i++)
            {
                Console.Clear();
                PrintHeaderRegisterActivityForTeacher();

                Teacher teacher = CreateNewActivityForTeacher();

                Program.ActivityList.AddNewActivity(teacher);
            }
            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewActivityForStudentFromKeyboard(int totalActivityForStudent)
        {
            for (int i = 0; i < totalActivityForStudent; i++)
            {
                Console.Clear();
                PrintHeaderRegisterActivityForStudent();

                Student student = CreateNewActivityForStudent();
                Program.ActivityList.AddNewActivity(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static Student CreateNewActivityForStudent()
        {
            return new Student(InputName(), InputStudentID(), InputActivity());
        }

        static Teacher CreateNewActivityForTeacher()
        {
            return new Teacher(InputName(), InputTeacherID(), InputActivity());
        }

        static string InputName()
        {

            Console.Write("Name :");

            return Console.ReadLine();
        }

        static string InputStudentID()
        {
            Console.Write("Student ID :");

            return Console.ReadLine();
        }

        static string InputTeacherID()
        {
            Console.Write("Teacher ID :");

            return Console.ReadLine();
        }

        static string InputActivity()
        {
            Console.Write("Activity :");

            return Console.ReadLine();
        }
       

        static int TotalNewActivityForStudents()
        {
            Console.Write("Input Total new activity for student :");

            return int.Parse(Console.ReadLine());
        }

        static int TotalNewTeacher()
        {
            Console.Write("Input Total new activity for Teacher :");

            return int.Parse(Console.ReadLine());
        }

        static void PrintHeaderRegisterActivityForStudent()
        {
            Console.WriteLine("Register new activity for student.");
            Console.WriteLine("-----------------------");
        }

        static void PrintHeaderRegisterActivityForTeacher()
        {
            Console.WriteLine("Register new activity for teacher.");
            Console.WriteLine("-----------------------");
        }

        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }

    }


    class Person
    {
        protected string name;
        protected string activity;
        

        public Person(string name, string activity)
        {
            this.name = name;
            this.activity = activity;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetActivity()
        {
            return this.activity;
        }

    }


    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewActivity(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Person");
            Console.WriteLine("-------------------");

            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name : {0} \n Type : Student \n Activity : {1}", person.GetName(), person.GetActivity());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name : {0} \n Type : Teacher \n Activity : {1}", person.GetName(), person.GetActivity());
                }
            }
        }
    }

    class Student : Person
    {
        private string studentID;

        public Student(string name, string studentID, string activity) : base(name, activity)
        {
            this.studentID = studentID;
        }
    }

    class Teacher : Person
    {
        private string teacherID;

        public Teacher(string name, string teacherID, string activity) : base(name, activity)
        {
            this.teacherID = teacherID;
        }
    }
}

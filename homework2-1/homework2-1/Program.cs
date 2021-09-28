using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2_1
{
    enum Menu
    {
        RegisterNewStudent = 1, RegisterNewTeacher, GetListPersons  
    }

    class Program
    {

        static PersonList personList;

        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();

            Header header = new Header();
            header.PrintHeader();

            ListMenu listMenu = new ListMenu();
            listMenu.PrintListMenu();
           
            InputMenuFromKeyboard();
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu :");

            Menu menu = (Menu)(int.Parse(Console.ReadLine())); 

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                ShowInputRegisterNewTeacherScreen();
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

        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();

            HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
            headerRegisterStudent.PrintHeaderRegisterStudent();

            int totalStudent = TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }

        static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();

            HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
            headerRegisterTeacher.PrintHeaderRegisterTeacher();

            int totalTeacher = TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }

        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonsList();
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

        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();

                HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
                headerRegisterTeacher.PrintHeaderRegisterTeacher();

                Teacher teacher = CreateNewTeacher();

                Program.personList.AddNewPerson(teacher);
            }
            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();

                HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
                headerRegisterStudent.PrintHeaderRegisterStudent();

                Student student = CreateNewStudent();
                Program.personList.AddNewPerson(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static Student CreateNewStudent()
        {
            return new Student(InputName(), InputAddress(), InputCitizenID(), InputStudentID());
        }

        static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(), InputAddress(), InputCitizenID(), InputEmployeeID());
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

        static string InputAddress()
        {
            Console.Write("Address :");

            return Console.ReadLine();
        }

        static string InputCitizenID()
        {
            Console.Write("CitizenID :");

            return Console.ReadLine();
        }

        static string InputEmployeeID()
        {
            Console.Write("Employee ID :");

            return Console.ReadLine();
        }

        static int TotalNewStudents()
        {
            Console.Write("Input Total new student :");

            return int.Parse(Console.ReadLine());
        }

        static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher :");

            return int.Parse(Console.ReadLine());
        }

        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }

    }

    class Header
    {
        public void PrintHeader()
        {
            string PrintHeader = "Welcome to registration new user school application \n -----------------------------------------";
            Console.WriteLine(PrintHeader);            
        }
    }

    class ListMenu
    {
        public void PrintListMenu()
        {
            string PrintListMenu = "1.Register new Student.\n2.Register new Teacher.\n3.Get List Person. ";
            Console.WriteLine(PrintListMenu);            
        }
    }

    class HeaderRegisterStudent
    {
        public void PrintHeaderRegisterStudent()
        {
            string PrintHeaderRegisterStudent = "Register new student.\n-----------------------";
            Console.WriteLine(PrintHeaderRegisterStudent);
        }
    }

    class HeaderRegisterTeacher
    {
        public void PrintHeaderRegisterTeacher()
        {
            string PrintHeaderRegisterTeacher = "Register new teacher.\n-----------------------";
            Console.WriteLine(PrintHeaderRegisterTeacher);
        }
    }

    class Person
    {
        protected string name;
        protected string address;
        protected string citizenID;

        public Person(string name, string address, string citizenID)
        {
            this.name = name;
            this.address = address;
            this.citizenID = citizenID;
        }

        public string GetName()
        {
            return this.name;
        }
      
    }


    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
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
                    Console.WriteLine("Name : {0} \n Type : Student", person.GetName());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name : {0} \n Type : Teacher", person.GetName());
                }
            }
        }
    }

    class Student : Person
    {
        private string studentID;

        public Student(string name, string address, string citizenID, string studentID) : base(name, address, citizenID)
        {
            this.studentID = studentID;
        }
    }

    class Teacher : Person
    {
        private string employeeID;

        public Teacher(string name, string address, string citizenID, string employeeID) : base(name, address, citizenID)
        {
            this.employeeID = employeeID;
        }
    }
}

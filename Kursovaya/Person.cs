using Kursovaya;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PraktZavd1
{

    abstract class Person<T> : DbEntity<T>
    {
        private string firstName;
        private string lastName;
        private int personID;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                SetFirstName();
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                SetLastName();
            }
        }
        public int ID
        {
            get
            {
                return personID;
            }
            set
            {
                SetID();
            }
        }

        public Person(string fstName, string lstName, int ID)
        {
            firstName = fstName;
            lastName = lstName;
            personID = ID;
        }

        public virtual void SetFirstName()
        {
            void EmptyFieldError()
            {
                Console.WriteLine("Введённое поле не может быть пустым. Повторите попытку");
                SetFirstName();
            }

            var isNullOrEmpty = false;
            firstName = Console.ReadLine();
            isNullOrEmpty = string.IsNullOrWhiteSpace(FirstName);
            if (isNullOrEmpty) EmptyFieldError();
            Console.WriteLine();
            Console.WriteLine($"Новое имя для {FirstName} {LastName}: {FirstName}");
            Program.MainMenu();
        }

        public virtual void SetLastName()
        {
            void EmptyFieldError()
            {
                Console.WriteLine("Введённое поле не может быть пустым. Повторите попытку");
                SetLastName();
            }

            var isNullOrEmpty = false;
            lastName = Console.ReadLine();
            isNullOrEmpty = string.IsNullOrWhiteSpace(LastName);
            if (isNullOrEmpty) EmptyFieldError();
            Console.WriteLine();
            Console.WriteLine($"Новая фамилия для {FirstName} {LastName}: {LastName}");
            Program.MainMenu();
        }

        public virtual void SetID()
        {
            try
            {
                personID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"Новый ID для {FirstName} {LastName}: {personID}");
                Program.MainMenu(); // возвращение в предыдущее меню после редактирования
            }
            catch (FormatException)
            {
                Console.WriteLine($"Неправильный формат введённых данных. Используйте числа, а не буквы или пробелы.");
                SetID();
            }
        }
    }

    class Client : Person<Client>
    {
        public string ClientType { get; set; } // Тип клиента - предприятие или частное лицо
        public string Country { get; set; } // Страна клиента

        public Client(string firstName, string lastName, int iD, string clType, string clCountry) : base(firstName, lastName, iD)
        {
            ClientType = clType;
            Country = clCountry;
        }
    }

    class Employee : Person<Employee>
    {
        private string employeeAccessLevel; // Уровень доступа сотрудника
        private string employeePosition; // Должность сотрудника

        public string EmployeeAccessLevel
        {
            get
            {
                return employeeAccessLevel;
            }
            set
            {
                SetEmployeeAccessLevel();
            }
        }
        public string EmployeePosition
        {
            get
            {
                return employeePosition;
            }

            set
            {
                SetEmployePosition();
            }
        }


        public override void SetFirstName()
        {
            Console.WriteLine();
            Console.Write($"Введите новое имя для сотрудника {FirstName} {LastName}: ");
            base.SetFirstName();
        }

        public override void SetLastName()
        {
            Console.WriteLine();
            Console.Write($"Введите новую фамилию для сотрудника {FirstName} {LastName}: ");
            base.SetLastName();
        }

        public override void SetID()
        {
            Console.WriteLine();
            Console.Write($"Введите новый ID для сотрудника {FirstName} {LastName}: ");
            base.SetID();
        }

        public void SetEmployeeAccessLevel()
        {
            void EmptyFieldError()
            {
                Console.WriteLine("Введённое поле не может быть пустым. Повторите попытку");
                SetEmployeeAccessLevel();
            }

            var isNullOrEmpty = false;
            Console.WriteLine();
            Console.Write($"Введите новый уровень доступа сотрудника {FirstName} {LastName}: ");
            employeeAccessLevel = Console.ReadLine();
            isNullOrEmpty = string.IsNullOrWhiteSpace(employeeAccessLevel);
            if (isNullOrEmpty) EmptyFieldError();
            Console.WriteLine();
            Console.WriteLine($"Новый уровень доступа сотрудника {FirstName} {LastName}: {employeeAccessLevel}");
            Program.EditServiceOptionsMenu();
        }

        public void SetEmployePosition()
        {
            void EmptyFieldError()
            {
                Console.WriteLine("Введённое поле не может быть пустым. Повторите попытку");
                SetEmployePosition();
            }

            var isNullOrEmpty = false;
            Console.WriteLine();
            Console.Write($"Введите новую должность сотрудника {FirstName} {LastName}: ");
            employeePosition = Console.ReadLine();
            isNullOrEmpty = string.IsNullOrWhiteSpace(employeePosition);
            if (isNullOrEmpty) EmptyFieldError();
            Console.WriteLine();
            Console.WriteLine($"Новая должность а сотрудника {FirstName} {LastName}: {employeePosition}");
            Program.EditServiceOptionsMenu();
        }

        public static void AddToDatabase(DBItem<Employee> employeeDataBase, MenuDelegate goToPreviousMenu)
        {
            try
            {
                void EmptyFieldError()
                {
                    Console.WriteLine("Введённое поле не может быть пустым");
                    AddToDatabase(employeeDataBase, goToPreviousMenu);
                }
                var isNullOrEmpty = false;

                Console.WriteLine("Введите ID нового сотрудника:");
                int newEmployeeID = int.Parse(Console.ReadLine());
                isNullOrEmpty = string.IsNullOrWhiteSpace(newEmployeeID.ToString());
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите имя нового сотрудника:");
                string newEmployeeFirstName = Console.ReadLine();
                isNullOrEmpty = string.IsNullOrWhiteSpace(newEmployeeFirstName);
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите фамилию нового сотрудника:");
                string newEmployeeLastName = Console.ReadLine();
                isNullOrEmpty = string.IsNullOrWhiteSpace(newEmployeeLastName);
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите уровень доступа нового сотрудника:");
                string newEmployeeAccessLevel = Console.ReadLine();
                isNullOrEmpty = string.IsNullOrWhiteSpace(newEmployeeLastName);
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите должность нового сотрудника:");
                string newEmployeePosition = Console.ReadLine();
                isNullOrEmpty = string.IsNullOrWhiteSpace(newEmployeePosition);
                if (isNullOrEmpty) EmptyFieldError();

                employeeDataBase.AddItemToList(new Employee(newEmployeeFirstName, newEmployeeLastName, newEmployeeID, newEmployeeAccessLevel, newEmployeePosition));
                goToPreviousMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine($"Неправильный формат введённых данных. Повторите попытку.");
                AddToDatabase(employeeDataBase, goToPreviousMenu);
            }
        }


        public Employee(string fstName, string lstName, int iD, string emplAcsLvl, string emplPos) : base(fstName, lstName, iD)
        {
            employeeAccessLevel = emplAcsLvl;
            employeePosition = emplPos;
        }

    }



}
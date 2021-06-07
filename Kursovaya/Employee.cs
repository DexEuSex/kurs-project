using MainProgram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kursovaya
{
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

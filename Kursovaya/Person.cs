using System;

namespace MainProgram
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
}
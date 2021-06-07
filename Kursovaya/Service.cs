using Kursovaya;
using System;
using System.Text;

namespace MainProgram
{

    class Service : DbEntity<Service>
    {

        private int serviceID;
        private string serviceName;
        private decimal serviceCost;
        private string serviceDescription;

        public int ServiceID
        {
            get
            {
                return serviceID;
            }
            set
            {
                SetServiceID();
            }
        }
        public string ServiceName
        {
            get
            {
                return serviceName;
            }

            set
            {
                SetServiceName();
            }
        }
        public decimal ServiceCost // Стоимость предоставляемой услуги
        {
            get
            {
                return serviceCost;
            }
            set
            {
                SetServiceCost();
            }
        }
        public string ServiceDescription
        {
            get
            {
                return serviceDescription;
            }
            set
            {
                SetServiceDescription();
            }
        }

        public Service(int servID, string servName, decimal servCost, string servDescr)
        {
            serviceID = servID;
            serviceName = servName;
            serviceCost = servCost;
            serviceDescription = servDescr;
        }

        public void SetServiceID()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Введите новый ID услуги: ");
                serviceID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"Новый ID услуги: {ServiceID}");
                Program.EditServiceOptionsMenu(); // возвращение в предыдущее меню после редактирования
            }
            catch (FormatException)
            {
                Console.WriteLine($"Неправильный формат введённых данных. Используйте числа, а не буквы или пробелы.");
                SetServiceID();
            }
        }

        public void SetServiceName()
        {
            void EmptyFieldError()
            {
                Console.WriteLine("Введённое поле не может быть пустым. Повторите попытку");
                SetServiceName();
            }
            var isNullOrEmpty = false;

            Console.WriteLine();
            Console.Write("Введите новое имя услуги: ");
            serviceName = Console.ReadLine();
            isNullOrEmpty = string.IsNullOrWhiteSpace(ServiceName);
            if (isNullOrEmpty) EmptyFieldError();

            Console.WriteLine();
            Console.WriteLine($"Новое имя услуги: {ServiceName}");
            Program.EditServiceOptionsMenu();
        }

        public void SetServiceCost()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Введите новую стоимость услуги: ");
                serviceCost = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"Новая стоимость услуги: {ServiceCost}");
                Program.EditServiceOptionsMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine($"Неправильный формат введённых данных. Используйте числа, а не буквы или пробелы.");
                SetServiceCost();
            }
        }

        public void SetServiceDescription()
        {
            void EmptyFieldError()
            {
                Console.WriteLine("Введённое поле не может быть пустым. Повторите попытку");
                SetServiceDescription();
            }

            var isNullOrEmpty = false;
            Console.WriteLine();
            Console.Write("Введите новое описание услуги: ");
            serviceDescription = Console.ReadLine();
            isNullOrEmpty = string.IsNullOrWhiteSpace(ServiceDescription);
            if (isNullOrEmpty) EmptyFieldError();
            Console.WriteLine();
            Console.WriteLine($"Новое описание услуги: {ServiceDescription}");
            Program.EditServiceOptionsMenu();
        }

        public static void AddToDatabase(DBItem<Service> serviceDataBase, MenuDelegate goToPreviousMenu)
        {
            try
            {
                void EmptyFieldError()
                {
                    Console.WriteLine("Введённое поле не может быть пустым");
                    AddToDatabase(serviceDataBase, goToPreviousMenu);
                }
                var isNullOrEmpty = false;

                Console.WriteLine("Введите ID нового сервиса:");
                int newServiceID = int.Parse(Console.ReadLine());
                isNullOrEmpty = string.IsNullOrWhiteSpace(newServiceID.ToString());
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите имя нового сервиса:");
                string newServiceName = Console.ReadLine();
                isNullOrEmpty = string.IsNullOrWhiteSpace(newServiceName);
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите стоимость нового сервиса: ");
                decimal newServiceCost = decimal.Parse(Console.ReadLine());
                isNullOrEmpty = string.IsNullOrWhiteSpace(newServiceCost.ToString());
                if (isNullOrEmpty) EmptyFieldError();

                Console.WriteLine("Введите описание нового сервиса:");
                string newServiceDescritpion = Console.ReadLine();
                isNullOrEmpty = string.IsNullOrWhiteSpace(newServiceDescritpion);
                if (isNullOrEmpty) EmptyFieldError();
                serviceDataBase.AddItemToList(new Service(newServiceID, newServiceName, newServiceCost, newServiceDescritpion));
                goToPreviousMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine($"Неправильный формат введённых данных. Повторите попытку.");
                AddToDatabase(serviceDataBase, goToPreviousMenu);
            }
        }

    }
}
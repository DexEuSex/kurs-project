using Kursovaya;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MainProgram 
{
    public delegate void MenuDelegate();
    class Program : IDisposable
    {

        static DataBase<Service> dBService = new DataBase<Service>();
        static DataBase<Employee> dBEmployee = new DataBase<Employee>();

        public static void MainMenu()
        {
            List<string> mainMenuOptions = new List<string>()
            {
                "Необходимо выбрать операцию. Используйте стрелки вниз-вверх для навигации. Для подтверждения нажмите - Ентер\n",
                "[1] Редактировать информацию (в разработке)",
                "[2] Добавить информацию (в разработке)",
                "[3] Удалить информацию (в разработке)",
                "[4] Выход из приложения"
            };
        
            int num = MenuActions<object>.CreateMenuWindow(mainMenuOptions, 5);
            switch (num)
            {
                case 1: { ChooseObjToEditMenu(); } break;
                case 2: { ChooseObjToAddMenu(); } break;
                case 3: { Console.WriteLine("выбор №3"); Console.ReadKey(); } break;
                case 4: { } break;
            }
            if (num == mainMenuOptions.Count) Environment.Exit(0);
        }


        public static void ChooseObjToEditMenu()
        {
            List<string> editMenuOptions = new List<string>()
            {
                  "Необходимо выбрать операцию. Используйте стрелки вниз-вверх для навигации. Для подтверждения нажмите - Ентер\n",
                  "[1] Редактировать информацию о сервисах (класс Service)",
                  "[2] Редактировать информацию о клиентах (класс Client)",
                  "[3] Редактировать информацию о заказах (класс Order)",
                  "[4] Редактировать информацию о сотрудниках (класс Employee)",
                  "[5] Назад в главное меню"
            };
            int num = MenuActions<object>.CreateMenuWindow(editMenuOptions, editMenuOptions.Count);
            switch (num)
            {
                case 1: { EditServiceOptionsMenu(); } break;
                case 2: { Console.WriteLine("выбор №2"); Console.ReadKey(); } break;
                case 3: { Console.WriteLine("выбор №3"); Console.ReadKey(); } break;
                case 4: { EditEmployeeOptionsMenu(); } break;
            }
            if (num == editMenuOptions.Count - 1) MainMenu();
        }

        public static void EditServiceOptionsMenu()
        {
            List<string> serviceMenuOptions = new List<string>();
            serviceMenuOptions.Insert(0, "Необходимо выбрать операцию. Используйте стрелки вниз-вверх для навигации. Для подтверждения нажмите - Ентер\n");

            foreach (Service serv in dBService.Items)
            {
                serviceMenuOptions.Insert(dBService.Items.IndexOf(serv) + 1, $"[{dBService.Items.IndexOf(serv) + 1}] {serv.ServiceName}");
            }

            using (MenuActions<Service> menu = new MenuActions<Service>())
            {
                MenuDelegate goToPreviousMenu = ChooseObjToEditMenu;
                MenuActions<Service>.EditParamsMenu editParamsMenu = EditServiceParamsMenu;
                menu.EditOptions(dBService.Items, serviceMenuOptions, goToPreviousMenu, editParamsMenu);
            }
        }

        public static void EditEmployeeOptionsMenu()
        {
            List<string> employeeMenuOptions = new List<string>();
            employeeMenuOptions.Insert(0, "Необходимо выбрать операцию. Используйте стрелки вниз-вверх для навигации. Для подтверждения нажмите - Ентер\n");

            foreach (Employee empl in dBEmployee.Items)
            {
                employeeMenuOptions.Insert(dBEmployee.Items.IndexOf(empl) + 1, $"[{dBEmployee.Items.IndexOf(empl) + 1}] {empl.FirstName} {empl.LastName}, {empl.EmployeePosition}");
            }

            using (MenuActions<Employee> menu = new MenuActions<Employee>())
            {
                MenuDelegate goToPreviousMenu = ChooseObjToEditMenu;
                MenuActions<Employee>.EditParamsMenu editParamsMenu = EditEmployeeParamsMenu;
                menu.EditOptions(dBEmployee.Items, employeeMenuOptions, goToPreviousMenu, editParamsMenu);
            }
        }

        public static void EditEmployeeParamsMenu(Employee employee)
        {
            MenuDelegate menuDelegate = EditEmployeeOptionsMenu;
            PropertyInfo[] employeePropertyInfo = employee.GetObjProperties();
            using (MenuActions<Employee> menu = new MenuActions<Employee>())
            {
                menu.EditParams(employee, employeePropertyInfo, menuDelegate);
            }
        }

        public static void EditServiceParamsMenu(Service service)
        {
            MenuDelegate menuDelegate = EditServiceOptionsMenu;
            PropertyInfo[] servicePropertyInfo = service.GetObjProperties();
            using (MenuActions<Service> menu = new MenuActions<Service>())
            {
                menu.EditParams(service, servicePropertyInfo, menuDelegate);
            }
        }

        static void Main(string[] args)
        {
            Employee empl1 = new Employee("Henry", "Ashford", 1, "A", "Manager");
            dBEmployee.AddItemToList(empl1);

            Employee empl2 = new Employee("Alexander", "Isaacs", 2, "B", "Security Engineer");
            dBEmployee.AddItemToList(empl2);

            Service webSiteSecurity = new Service(1, "Web Site Security", 300, "Checking the security of any web resource");
            dBService.AddItemToList(webSiteSecurity);

            Service serverSecurity = new Service(2, "Server Security", 600, "Checking the security of any server");
            dBService.AddItemToList(serverSecurity);

            Service otherSystemSecurity = new Service(3, "Other System Security", 1000, "Checking the security of other system");
            dBService.AddItemToList(otherSystemSecurity);

            MainMenu();
        }

        static void ChooseObjToAddMenu()
        {
            List<string> addMenuOptions = new List<string>()
            {
                "Необходимо выбрать операцию. Используйте стрелки вниз-вверх для навигации. Для подтверждения нажмите - Ентер\n",
                "[1] Добавить информацию о сервисах (класс Service)",
                "[2] Добавить информацию о клиентах (класс Client)",
                "[3] Добавить информацию о заказах (класс Order)",
                "[4] Добавить информацию о сотрудниках (класс Employee)",
                "[5] Назад в главное меню"
            };
            MenuDelegate menuDelegate = MainMenu;
            int num = MenuActions<object>.CreateMenuWindow(addMenuOptions, 6);
            switch (num)
            {
                case 1: { MenuActions<Service>.AddItemToDataBase(dBService, menuDelegate); } break;
                case 2: { Console.WriteLine("В разработке"); Console.ReadKey(); } break;
                case 3: { Console.WriteLine("В разработке"); Console.ReadKey(); } break;
                case 4: { MenuActions<Employee>.AddItemToDataBase(dBEmployee, menuDelegate); } break;
                case 5: { menuDelegate(); } break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
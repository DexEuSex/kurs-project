using MainProgram;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kursovaya
{
    class MenuActions<T> : IDisposable
    {
        public delegate void EditParamsMenu(T objectToEdit);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void EditParams(T objectToEdit, PropertyInfo[] objectPropertyInfo, MenuDelegate goToPreviousMenu)
        {
            List<string> serviceFieldOptions = new List<string>();

            serviceFieldOptions.Insert(0, "Необходимо выбрать операцию. Используйте стрелки вниз-вверх для навигации. Для подтверждения нажмите - Ентер\n");
            for (int i = 0; i < objectPropertyInfo.Length; i++)
            {
                serviceFieldOptions.Insert(i + 1, $"[{i + 1}] {objectPropertyInfo[i].Name} = {objectPropertyInfo[i].GetValue(objectToEdit)}");
            }

            serviceFieldOptions.Insert(serviceFieldOptions.Count, $"[{serviceFieldOptions.Count}] Вернуться назад");

            int num = CreateMenuWindow(serviceFieldOptions, serviceFieldOptions.Count);
            int userChoise = num - 1;
            int lastElementOfMenu = serviceFieldOptions.Count - 1;

            if (num == lastElementOfMenu)
                goToPreviousMenu();
            else if (num < lastElementOfMenu)
                objectPropertyInfo[userChoise].SetValue(objectToEdit, objectPropertyInfo[userChoise].GetValue(objectToEdit));

            Dispose();
        }

        public void EditOptions(List<T> dataBase, List<string> menuOpts, MenuDelegate goToPreviousMenu, EditParamsMenu goToEditParmsMenu)
        {
            menuOpts.Insert(menuOpts.Count, $"[{menuOpts.Count}] Вернуться назад");

            int num = CreateMenuWindow(menuOpts, menuOpts.Count + 1);
            int userChoise = num - 1;
            int lastElementOfMenu = menuOpts.Count - 1;

            if (num == lastElementOfMenu)
                goToPreviousMenu();
            else if (num < lastElementOfMenu)
                goToEditParmsMenu(dataBase[userChoise]);

            Dispose();
        }

        public static void AddItemToDataBase(DataBase<T> dataBase, MenuDelegate mainMenuMethod)
        {
            void AddServiceToDataBase()
            {
                Service.AddToDatabase(dataBase as DataBase<Service>, mainMenuMethod);
            }

            void AddEmployeeToDataBase()
            {
                Employee.AddToDatabase(dataBase as DataBase<Employee>, mainMenuMethod);
            }

            if (dataBase is DataBase<Service>)
            {
                AddServiceToDataBase();
            }

            else if (dataBase is DataBase<Employee>)
            {
                AddEmployeeToDataBase();
            }

        }

        public static int CreateMenuWindow(List<string> menuOptionsArray, int optionsLimit)
        {
            Console.Clear();
            Console.SetWindowSize(110, 50);
            foreach (string text in menuOptionsArray)
            Console.WriteLine(text);
            int num = MenuKeys(optionsLimit, menuOptionsArray); // Создание окна меню
            return num;
        }

        public static int MenuKeys(int optionsLimit, List<string> menuOptionArray) // Работа менюшки
        {
            void PrintOption(List<string> menuOptionArray, int optionIndex)
            {
                Console.Clear();
                for (int i = 0; i < menuOptionArray.Count; i++)
                {
                    if (i == optionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menuOptionArray[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else Console.WriteLine(menuOptionArray[i]);
                }
            }

            int num = 0;
            bool flag = false;
            do
            {
                ConsoleKeyInfo keyPushed = Console.ReadKey();
                if (keyPushed.Key == ConsoleKey.DownArrow)
                {
                    num++;
                    PrintOption(menuOptionArray, num);
                }
                if (keyPushed.Key == ConsoleKey.UpArrow)
                {
                    num--;
                    PrintOption(menuOptionArray, num);
                }
                if (keyPushed.Key == ConsoleKey.Enter)
                {
                    flag = true;
                }
                if (num == 0)
                {
                    num = menuOptionArray.Count;
                    PrintOption(menuOptionArray, menuOptionArray.Count);
                }
                if (num == optionsLimit)
                {
                    num = 1;
                    PrintOption(menuOptionArray, 1);
                }
            } while (!flag);
            return num;
        }

        
    }
}

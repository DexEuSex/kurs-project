using System.Collections.Generic;

namespace Kursovaya
{
    class DataBase<T>
    {
        public List<T> Items { get; set; }

        public DataBase()
        {
            this.Items = new List<T>();
        }

        public void AddItemToList(T item)
        {
            Items.Add(item);
        }

        public void DeleteItemFromList(T item)
        {
            Items.Remove(item);
        }
    }
}

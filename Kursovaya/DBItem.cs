using System;
using System.Collections.Generic;
using System.Text;

namespace Kursovaya
{
    class DBItem<T>
    {
        public List<T> Items { get; set; }

        public DBItem()
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

using MainProgram;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kursovaya
{
    class Client : Person<Client>
    {
        public bool ClientType { get; set; } // Тип клиента - предприятие или частное лицо
        public string Country { get; set; } // Страна клиента

        public Client(string firstName, string lastName, int iD, bool clType, string clCountry) : base(firstName, lastName, iD)
        {
            ClientType = clType;
            Country = clCountry;
        }
    }
}

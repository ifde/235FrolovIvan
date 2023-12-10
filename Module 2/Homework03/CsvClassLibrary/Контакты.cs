using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvClassLibrary
{
    /// <summary>
    /// Represents Contanct informaton of a theatre. 
    /// In composition to Театры.
    /// </summary>
    public class Контакты
    {

        internal string iNN = "", // ИНН
            city = "", // Город
            street = "", // Улица
            number = "", // Номер дома
            publicPhone = ""; // телефон

        // // Below are the properties for private fileds listed above.
        public string INN => iNN;
        public string City => city;
        public string Street => street;
        public string Number => number;
        public string PublicPhone => publicPhone;

        public Контакты() { } // basic constructor
    }
}

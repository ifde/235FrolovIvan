using System.Text.RegularExpressions;

namespace CsvClassLibrary
{
    public class Театр
    {
        private int rowNum;
        private string commonName, fullName, shortName, admArea,
            district,
            chiefName, chiefPosition, fax,
            email, workingHours,
            clarificationOfWorkingHours, webSite, oKPO,
            mainHallCapacity,
            additionalHallCapacity ,
            x_WGS, y_WGS, gLOBALID;

        public int RowNum => rowNum;
        public string MainHallCapacity => mainHallCapacity;
        public string AdditionalHallCapacity => additionalHallCapacity;

        public string CommonName => commonName;

        public string Email => email;

        public string Website => webSite;

        public string ChiefName => chiefName;
        public string AdmArea => admArea;

        private Контакты contacts;

        public Театр(Match[] values, int rowNum)
        {
            contacts = new Контакты();

            // initializing fields of Театр
            this.rowNum = rowNum;
            commonName = values[0].Value;
            fullName = values[1].Value;
            shortName = values[2].Value;
            admArea = values[3].Value;
            district = values[4].Value;
            chiefName = values[6].Value;
            chiefPosition = values[7].Value;
            fax = values[9].Value;
            email = values[10].Value;
            workingHours = values[11].Value;
            clarificationOfWorkingHours = values[12].Value;
            webSite = values[13].Value;
            oKPO = values[14].Value;
            mainHallCapacity = values[16].Value;
            additionalHallCapacity = values[17].Value;
            x_WGS = values[18].Value;
            y_WGS = values[19].Value;
            gLOBALID = values[20].Value;

            // initializing fields of Контакты
            contacts.iNN = values[15].Value;
            contacts.city = "Москва";
            contacts.publicPhone = values[8].Value;

            string[] temp = values[5].Value.Split(", "); // street + apt. number (if exists)
            contacts.street = temp[0];
            contacts.number = temp.Length == 1 ? " " : temp[1];

        }

        /// <summary>
        /// Converts a theatre to a string in a .csv format
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return $"{rowNum};\"{commonName}\";\"{fullName}\";\"{shortName}\";\"{admArea}\";\"{district}\";\"{contacts.street}, {contacts.number}\";\"{chiefName}\";\"{chiefPosition}\";" +
                $"\"{contacts.publicPhone}\";" +
                $"\"{fax}\";\"{email}\";\"{workingHours}\";\"{clarificationOfWorkingHours}\";\"{webSite}\";\"{oKPO}\";\"{contacts.iNN}\";\"{mainHallCapacity}\";" +
                $"\"{additionalHallCapacity}\";\"{x_WGS}\";\"{y_WGS}\";\"{gLOBALID}\";";
        }

    }
}
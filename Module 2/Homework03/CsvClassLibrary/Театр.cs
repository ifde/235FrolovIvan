using System.Text.RegularExpressions;

namespace CsvClassLibrary
{
    /// <summary>
    /// Represents a theatre
    /// </summary>
    public class Театр
    {
        // Below are the fileds corresposding to headers of the Театры.csv file.
        private int rowNum;
        private string commonName, fullName, shortName, admArea,
            district,
            chiefName, chiefPosition, fax,
            email, workingHours,
            clarificationOfWorkingHours, webSite, oKPO,
            mainHallCapacity,
            additionalHallCapacity ,
            x_WGS, y_WGS, gLOBALID;

        // Below are the properties for private fileds listed above.
        public int RowNum => rowNum;
        public string CommonName => commonName;
        public string FullName => fullName;
        public string ShortName => shortName;
        public string AdmArea => admArea;
        public string District => district;
        public string ChiefName => chiefName;
        public string ChiefPosition => chiefPosition;
        public string Fax => fax;
        public string Email => email;
        public string WorkHours => workingHours;
        public string ClarificationOfWorkingHours => clarificationOfWorkingHours;
        public string Website => webSite;
        public string OKPO => oKPO;
        public string MainHallCapacity => mainHallCapacity;
        public string AdditionalHallCapacity => additionalHallCapacity;
        public string X_WGS => x_WGS;
        public string Y_WGS => y_WGS;
        public string GLOBALID => gLOBALID;

        private Контакты contacts;

        /// <summary>
        /// A basic Constructor
        /// </summary>
        public Театр() : this(Regex.Matches("000000000000", @"0").ToArray(), 0) { }

        /// <summary>
        /// A constructor.
        /// </summary>
        /// <param name="values">values of the theatre in the Театры.csv file </param>
        /// <param name="rowNum">the number of theatre in the Театры.csv file</param>
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
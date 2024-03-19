using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TgBotLib
{
    /// <summary>
    /// Represents TPU
    /// </summary>
    public class TPU
    {
        [JsonInclude]
        public string Id { get; private set; }
        [JsonInclude]
        public string TPUName { get; private set; }
        [JsonInclude]
        public string Global_id { get; private set; }
        [JsonInclude]
        public string AdmArea { get; private set; }
        [JsonInclude]
        public string District { get; private set; }
        [JsonInclude]
        public string NearStation { get; private set; }
        [JsonInclude]
        public string YearOfComissioning { get; private set; }
        [JsonInclude]
        public string Status { get; private set; }
        [JsonInclude]
        public string AvailableTransfer { get; private set; }
        [JsonInclude]
        public string CarCapacity { get; private set; }
        [JsonInclude]
        public string Geodata_center { get; private set; }
        [JsonInclude]
        public string Geoarea { get; private set; }

        /// <summary>
        /// A consturctor to initialize all the properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="global_id"></param>
        /// <param name="area"></param>
        /// <param name="district"></param>
        /// <param name="nearStation"></param>
        /// <param name="yearOfCommisioning"></param>
        /// <param name="status"></param>
        /// <param name="availableTransfer"></param>
        /// <param name="carCapacity"></param>
        /// <param name="geodata_center"></param>
        /// <param name="geoarea"></param>
        public TPU(string id, string name, string global_id, string area, string district, string nearStation,
            string yearOfCommisioning, string status, string availableTransfer, string carCapacity, string geodata_center, string geoarea)
        {
            Id = id;
            TPUName = name;
            Global_id = global_id;
            AdmArea = area;
            District = district;
            NearStation = nearStation;
            YearOfComissioning = yearOfCommisioning;
            Status = status;
            AvailableTransfer = availableTransfer;
            CarCapacity = carCapacity;
            Geodata_center = geodata_center;
            Geoarea = geoarea;
        }

        /// <summary>
        /// A basic constructor
        /// </summary>
        public TPU() { }

        /// <summary>
        /// A constuctor that takes an array of matches as an argument
        /// </summary>
        /// <param name="values"></param>
        public TPU(Match[] values)
        {
            Id = values[0].Value;
            TPUName = values[1].Value;
            Global_id = values[2].Value;
            AdmArea = values[3].Value;
            District = values[4].Value;
            NearStation = values[5].Value;
            YearOfComissioning = values[6].Value;
            Status = values[7].Value;
            AvailableTransfer = values[8].Value;
            CarCapacity = values[9].Value;
            Geodata_center = values[10].Value;
            Geoarea = values[11].Value;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TgBotLib
{
    /// <summary>
    /// Provides options for sorting / selecting
    /// </summary>
    public enum Options
    {
        Default,
        SortAvailableTransportAscending,
        SortYearOfCommisioningDescending,
        SelectByDisctrict,
        SelectByCarCapacity,
        SelectByStatusAndNearStation
    }

    /// <summary>
    /// Provides statis methods to sort of select from a list of TPUs
    /// </summary>
    public static class DataProcessing
    {
        /// <summary>
        /// Sorts a list of TPUs
        /// </summary>
        /// <param name="list"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<TPU> Sort(List<TPU> list, string field)
        {

            switch (field)
            {
                case "AvailableTransfer":
                    list = (from obj in list
                           orderby obj.AvailableTransfer
                           select obj).ToList();
                    return list;

                case "YearOfComissioning":
                    list = (from obj in list
                           orderby int.Parse(obj.YearOfComissioning) descending
                           select obj).ToList();
                    return list;
                default:
                    throw new ArgumentException("Такого поля не существует. Сортировка невозможна");
            }
        }

        /// <summary>
        /// Selects objects from the list of TPUs
        /// </summary>
        /// <param name="list"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<TPU> Select(List<TPU> list, string[] field, string[] value)
        {

            switch (field[0])
            {
                case "District":
                    list = (from obj in list
                           where obj.District == value[0]
                           select obj).ToList();
                    return list;

                case "CarCapacity":

                    list = (from obj in list
                            where obj.CarCapacity == value[0]
                            select obj).ToList();
                    return list;

                case "Status":

                    list = (from obj in list
                            where obj.Status == value[0] && obj.NearStation == value[1]
                            select obj).ToList();
                    return list;
                default:
                    throw new ArgumentException("Данное поле не поддерживается.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBotLib
{
    
    /// <summary>
    /// Represents a keyboard
    /// </summary>
    public class Keyboard
    {
        /// <summary>
        /// The first menu
        /// </summary>
        /// <returns></returns>
        public static ReplyKeyboardMarkup FileTypeKeyboard()
        {
            var kbrd = new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
        new []  {
                new KeyboardButton("Прислать CSV файл")
                },
        new[]
        {
            new KeyboardButton("Прислать JSON файл")
        },
            });
            return kbrd;
        }

        /// <summary>
        /// The second menu
        /// </summary>
        /// <returns></returns>
        public static ReplyKeyboardMarkup CommandKeyboard()
        {
            var kbrd = new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
        new []  {
                new KeyboardButton("Отсортировать по полю AvailableTransport (по алфавиту)")
                },
        new[]
        {
            new KeyboardButton("Отсортировать по полю YearOfCommisioning (по убыванию)")
        },
        new[]
        {
            new KeyboardButton("Сделать выборку по полю District")
        },
        new[]
        {
            new KeyboardButton("Сделать выборку по полю CarCapacity")
        },
        new[]
        {
            new KeyboardButton("Сделать выборку по полям Status и NearStation")
        }
            });
            return kbrd;
        }
    }


}

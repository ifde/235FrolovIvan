using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class VideoFile
    {
        private string _name; // videofile's name
        private int _duration; // duration in seconds
        private int _quality; // the quality of the videofile

        public VideoFile(string name, int duration, int quality)
        {
            _name = name;
            _duration = duration;
            _quality = quality;
        }

        /// <summary>
        /// The size of the videofile
        /// </summary>
        public int Size => _duration * _quality;

        public override string ToString()
        {
            return $"Name = {_name}, Duration = {_duration}, Quality = {_quality}";
        }
    }
}

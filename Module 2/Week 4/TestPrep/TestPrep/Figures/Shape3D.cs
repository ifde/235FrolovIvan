using System.Threading.Tasks.Dataflow;

namespace Figures
{
    public class Shape3D
    {
        protected Random rnd = new Random();

        /// <summary>
        /// Calcuates the area of the shape
        /// </summary>
        /// <returns></returns>
        public virtual double S()
        {
            return 0;
        }

        /// <summary>
        /// Calculates the volume of the shape
        /// </summary>
        /// <returns></returns>
        public virtual double V()
        {
            return 0;
        }

    }
}
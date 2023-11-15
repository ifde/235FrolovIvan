using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03Lib_Employee
{
    public class PartTimeEmployee : Employee
    {
        private int workingDays; // the number of working days

        // The constructor calls the base-class version, and
        // initializes the workingDays field.
        public PartTimeEmployee(string name, decimal basepay, int workingDays)
            : base(name, basepay)
        {
            this.workingDays = workingDays;
        }

        // Override the CalculatePay method
        // to take the number of working days into account.
        override public decimal CalculatePay()
        {
            return _basepay * ((decimal)workingDays / 25);
        }

        public override string ToString()
        {
            return $"Part-time Employee. Name = {Name}, salarie = {CalculatePay()}";
        }
    }
}

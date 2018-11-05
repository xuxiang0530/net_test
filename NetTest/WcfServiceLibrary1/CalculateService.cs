using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalculateService" in both code and config file together.
    public class CalculateService : ICalculateService
    {
        
        public double AddOperation(double num1, double num2)
        {
            return num1 + num2;
        }

        public double SubOperation(double num1, double num2)
        {
            return num1 - num2;
        }

        public double MulOperation(double num1, double num2)
        {
            return num1 * num2;
        }

        public double DivOperation(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}

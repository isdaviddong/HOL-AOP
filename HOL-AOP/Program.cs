using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOL_AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            BMIProcessor BMI = new BMIProcessor();
            //其餘程式碼完全不變
            BMI.Height = 170;
            BMI.Weight = 70;

            //計算BMI
            var ret = BMI.Calculate();

            Console.WriteLine($"\nBMI : {ret}");
            Console.ReadKey();

            //測試exception
            BMI.Height = 0;
            BMI.Weight = 0;

            //計算BMI
            ret = BMI.Calculate();

            Console.WriteLine($"\nBMI : {ret}");
            Console.ReadKey();
        }
    }
    public class BMIProcessor 
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public Decimal BMI
        {
            get
            {
                return Calculate();
            }
        }
 
        //計算BMI
        public Decimal Calculate()
        {
            Decimal result = 0;
            Decimal height = (Decimal)Height / 100;
            result = Weight / (height * height);

            return result;
        }
    }
}

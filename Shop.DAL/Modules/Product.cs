using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Modules
{
    public class Currency
    {
        public int CurCode { get; set; }
        public string CurName { get; set; }
        public override string ToString()
        {
            string str = string.Format("{0} ({1})", CurName, CurCode);
            return str;
        }
    }
    public class Product
    {

        public string Name { get; set; }
        private double Price_;
        public double price
        {
            get { return Price_; }

            set
            {
                if (value < 0)
                    Price_ = 0;
                else Price_ = value;
            }
        }
        public Currency Cur { get; set; } = new Currency();
        public int Barcode { get; set; }
        public int Qunatity { get; set; }
        public double ExpiredDay { get; set; }
        public DateTime DataOfProduction { get; set; }
        private DateTime ExpiredTime_;
        public DateTime ExpireTime
        {
            get
            {
                return ExpiredTime_;
            }
            set
            {
                double TotalDays = (value - DataOfProduction).TotalDays;

                if (TotalDays < 0)
                    ExpiredTime_ = DataOfProduction.AddDays(ExpiredDay);
                else if (TotalDays > ExpiredDay)
                    ExpiredTime_ = DataOfProduction.AddDays(ExpiredDay);
                else ExpiredTime_ = value;
            }
        }
        public static Product operator >(Product a, Product b)
        {
            if (a.price > b.price)
            
                return a;
            else
                return b;
        }
        public static Product operator <(Product a, Product b)
        {
            if (a.price < b.price)

                return b;
            else
                return a;
        }
        public void PrintInfo()
        {
            Console.WriteLine("{0} - {1} - ({2} - {3}) - {4} {5}",
                Barcode, Name, DataOfProduction, ExpiredTime_, price, Cur);
        }
    }
}


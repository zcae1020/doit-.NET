using System;
namespace Assignment01Class
{
    public class Toy
    {
        public string name {get; private set;}
        public int year {get; private set;}
        public int price {get; private set;}

        public int point {get; private set;}

        //Constructor
        public Toy( string name, string year, string price  ){
            this.name = name;
            this.year = Convert.ToInt32(year);
            this.price = Convert.ToInt32(price);
            this.point = CalculatePoint(this.year, this.price);
        }

        //Method
        public int CalculatePoint(int year, int price){
            return (year % 100) * (price / 1000);
        }
    }
}
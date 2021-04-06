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
        public Toy(string toyData){
            
            string[] parseing_data = toyData.Split(' ');
            name = parseing_data[0];
            year = Convert.ToInt32(parseing_data[1]);
            price = Convert.ToInt32(parseing_data[2]);
            CalculatePoint();
        }

        //Method
        public void CalculatePoint(){
            point = (year%100) * (price / 1000);
        }
    }
}
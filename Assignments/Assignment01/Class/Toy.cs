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
        public Toy( /* ex:) string _name */  ){

            /* Code */
            
        }

        //Method
        public void CalculatePoint(){
            point = (year%100) * (price/1000);
        }
    }
}
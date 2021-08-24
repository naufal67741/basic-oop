using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    class VIPRoom : Room
    {
        public string Food { get; set; }

        public VIPRoom(int id, string name, string type, int price, string food)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
            Food = food;
        }
    }
}

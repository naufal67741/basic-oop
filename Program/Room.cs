using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }

        public Room(int id, string name, string type, int price)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }

        public Room()
        {
        }
    }
}

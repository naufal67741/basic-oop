using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        /*static string[] listRoom = new string[100];*/
        static List<string> listRoom = new List<string>();
        static List<Room> roomList = new List<Room>();
        static List<VIPRoom> roomListVIP = new List<VIPRoom>();
        static void Main(string[] args)
        {
            string passwordLogin;

            Console.WriteLine("Welcome to Admin Page");
            do
            {
                Console.Write("Masukkan password : ");
                passwordLogin = Console.ReadLine();
                if (passwordLogin != "admin")
                {
                    Console.WriteLine("Wrong password");
                }
            } while (passwordLogin != "admin");
            int userChoice = 0;
            do
            {
                PrintMenu();
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Masukkan angka saja! [Press Enter to continue]");
                    char ch = Console.ReadKey(true).KeyChar;
                }
                switch (userChoice)
                {
                    case 1:
                        ViewRoom();
                        break;
                    case 2:
                        AddRoom();
                        break;
                    case 3:
                        DeleteRoom();
                        break;
                    default:
                        if (userChoice != 4)
                        {
                            Console.WriteLine("Please choose 1 - 4 only! [Press Enter to continue]");
                            char ch = Console.ReadKey(true).KeyChar;
                        }
                        break;
                }

            } while (userChoice != 4);
            Console.WriteLine("Thank you");

        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Penginapan ABC");
            Console.WriteLine("1. view room");
            Console.WriteLine("2. add room");
            Console.WriteLine("3. delete room");
            Console.WriteLine("4. exit");
            Console.Write("Your choice : ");
        }

        static void AddRoom()
        {

            string newRoomName = "";
            string newRoomType = "";
            int newRoomPrice = 0;
            Console.Clear();

            do
            {
                Console.Write("Masukkan type room [VIP | Regular] : ");
                newRoomType = Console.ReadLine();
            } while (newRoomType != "VIP" && newRoomType != "Regular");

            do
            {
                Console.Write("Masukkan nama room : ");
                newRoomName = Console.ReadLine();
                if (IsDuplicate(newRoomName))
                {
                    Console.WriteLine("Duplicate data ! please try again");
                    char ch = Console.ReadKey(true).KeyChar;
                }
            } while (IsDuplicate(newRoomName));

            do
            {
                Console.Write("Masukkan price room [ > 10 ] : ");
                newRoomPrice = Convert.ToInt32(Console.ReadLine());
            } while (newRoomPrice <= 10);

            if(newRoomType == "Regular")
            {
                /*Room room = new Room(roomList.Count, newRoomName, newRoomType, newRoomPrice);*/
                roomList.Add(new Room(roomList.Count+1, newRoomName, newRoomType, newRoomPrice));
            }
            else
            {
                Console.Write("Masukkan food : ");
                string newRoomFood = Console.ReadLine();
                /*VIPRoom viproom = new VIPRoom(roomList.Count+1, newRoomName, newRoomType, newRoomPrice, newRoomFood);*/
                roomListVIP.Add(new VIPRoom(roomListVIP.Count + 1, newRoomName, newRoomType, newRoomPrice, newRoomFood));
            }
/*
            if (!IsDuplicate(newRoomName))
            {
                listRoom.Add(newRoomName);
            }*/
        }

        static void ViewRoom()
        {
            if (roomList.Count == 0)
            {
                Console.WriteLine("There is no regular room data!");
            }
            else
            {
                Console.WriteLine("======== Regular Room =========");
                for (int i = 0; i < roomList.Count; i++)
                {
                    Console.WriteLine($"{roomList[i].Id}. {roomList[i].Name} - {roomList[i].Type} - {roomList[i].Price}");
                }
            }

            if (roomListVIP.Count == 0)
            {
                Console.WriteLine("There is no VIP room data! [Press Enter to continue]");
            }
            else
            {
                Console.WriteLine("======== VIP Room =========");
                for (int i = 0; i < roomListVIP.Count; i++)
                {
                    Console.WriteLine($"{roomListVIP[i].Id}. {roomListVIP[i].Name} - {roomListVIP[i].Type} - {roomListVIP[i].Price} - {roomListVIP[i].Food}");
                }
            }
            Console.WriteLine("[Press Enter to continue]");
            char ch = Console.ReadKey(true).KeyChar;
        }

        static void DeleteRoom()
        {
            int deleteChoice;
            string deleteType;
            if (roomList.Count == 0 && roomListVIP.Count == 0)
            {
                Console.WriteLine("There is no data! [Press Enter to continue]");
                char ch = Console.ReadKey(true).KeyChar;
            }
            else
            {
                Console.Clear();
                ViewRoom();
                do
                {
                    Console.Write("Masukkan type room [VIP | Regular] : ");
                    deleteType = Console.ReadLine();
                } while (deleteType != "VIP" && deleteType != "Regular");
                if(deleteType == "VIP")
                {
                    do
                    {
                        Console.Write("Which room do you want to delete ? [Index] : ");
                        deleteChoice = Convert.ToInt32(Console.ReadLine());
                    } while (deleteChoice < 1 || deleteChoice > roomListVIP.Count);

                    roomListVIP.RemoveAt(deleteChoice - 1);
                }
                else
                {
                    do
                    {
                        Console.Write("Which room do you want to delete ? [Index] : ");
                        deleteChoice = Convert.ToInt32(Console.ReadLine());
                    } while (deleteChoice < 1 || deleteChoice > roomList.Count);

                    roomList.RemoveAt(deleteChoice - 1);
                }
                
            }
        }

        static bool IsDuplicate(string keyRoom)
        {
            foreach (string room in listRoom)
            {
                if (keyRoom == room) return true;
            }
            return false;
        }


    }
}

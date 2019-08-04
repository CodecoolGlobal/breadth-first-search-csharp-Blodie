using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            Console.WriteLine(users[0].MinDistanceFrom(users[2]));
            Console.WriteLine(users[0].FriendsAtDistance(2).Count);
            foreach (var user in users[0].FriendsAtDistance(2))
            {
                Console.WriteLine(user);
            }

            //foreach (var user in users)
            //{
            //    Console.WriteLine(user);
            //}

            //Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}

using System.Collections.Generic;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private HashSet<UserNode> Friends { get; } = new HashSet<UserNode>();
        private UserNode parent = null;

        public UserNode() { }

        public UserNode(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public int MinDistanceFrom(UserNode b)
        {
            return MinDistanceBetween(this, b);
        }

        public static int MinDistanceBetween(UserNode a, UserNode b)
        {
            var discovered = new HashSet<UserNode>();
            var queue = new Queue<UserNode>();  
            discovered.Add(a);
            queue.Enqueue(a);
            while (queue.Count > 0)
            {
                var friend = queue.Dequeue();
                if (friend == b)
                {
                    return GetDist(friend);
                }

                foreach (var friendOfFriend in friend.Friends)
                {
                    if (!discovered.Contains(friendOfFriend))
                    {
                        discovered.Add(friendOfFriend);
                        friendOfFriend.parent = friend;
                        queue.Enqueue(friendOfFriend);
                    }
                }
            }

            return 0;
        }

        private static int GetDist(UserNode friend)
        {
            int dist = 0;
            while (friend.parent != null)
            {
                friend = friend.parent;
                dist++;
            }
            return dist;
        }

        public List<UserNode> FriendsAtDistance(int dist)
        {
            var friendsAtDistance = new HashSet<UserNode>();
            var discovered = new HashSet<UserNode>();
            var queue = new Queue<UserNode>();
            discovered.Add(this);
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var friend = queue.Dequeue();
                if (GetDist(friend) == dist)
                {
                    friendsAtDistance.Add(friend);
                }

                foreach (var friendOfFriend in friend.Friends)
                {
                    if (!discovered.Contains(friendOfFriend))
                    {
                        discovered.Add(friendOfFriend);
                        friendOfFriend.parent = friend;
                        queue.Enqueue(friendOfFriend);
                    }
                }
            }

            return new List<UserNode>(friendsAtDistance);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(" + Friends.Count + ")";
        }
    }
}

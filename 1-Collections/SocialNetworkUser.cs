using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {

        private Dictionary<string, List<TUser>> _followed = new();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            //throw new NotImplementedException("TODO add user to the provided group. Return false if the user was already in the group");
            List<TUser> groupList;
            _followed.TryGetValue(group, out groupList);
            if(groupList.Contains(user)) return false;
            groupList.Add(user);
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                List<TUser> ret = new();
                foreach (var item in _followed) ret.AddRange(item.Value);
                return ret;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            List<TUser> ret = new();
            _followed.TryGetValue(group, out ret);
            return ret;
        }
    }
}

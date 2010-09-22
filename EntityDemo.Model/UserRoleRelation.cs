using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkHelper;

namespace EntityDemo.Model
{
    [Serializable]
    public class UserRoleRelation : TableBase
    {
        public User User
        {
            get { return user; }
            set
            {
                if (Object.ReferenceEquals(user, value)) return;
                user = value;

                userId = user != null ? value.Id : 0;

                if (value != null && !value.UserRoleRelation.Contains(this))
                    value.UserRoleRelation.Add(this);
            }
        }
        private User user;

        public int UserId
        {
            get { return userId; }
            set
            {
                if (user != null && user.Id != value)
                    User = null;

                userId = value;
            }
        }
        private int userId;

        public Role Role
        {
            get { return role; }
            set
            {
                if (Object.ReferenceEquals(role, value)) return;
                role = value;

                roleId = role != null ? value.Id : 0;

                if (value != null && !value.UserRoleRelation.Contains(this))
                    value.UserRoleRelation.Add(this);
            }
        }
        private Role role;

        public int RoleId
        {
            get { return roleId; }
            set
            {
                if (role != null && role.Id != value)
                    Role = null;

                roleId = value;
            }
        }
        private int roleId;
    }
}

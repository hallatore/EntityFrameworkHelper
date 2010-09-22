using System.Collections.Generic;
using EntityFrameworkHelper;
using System.Collections.ObjectModel;
using System;

namespace EntityDemo.Model
{
    [Serializable]
    public class User : TableBase
    {
        public User()
        {
            message = new ObservableCollection<Message>();
            ModelHelper.OneToMany<Message>(message, "User", this);

            userRoleRelation = new ObservableCollection<UserRoleRelation>();
            ModelHelper.OneToMany<UserRoleRelation>(userRoleRelation, "User", this);
        }

        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Message> Message
        {
            get
            {
                return message;
            }
        }
        private ICollection<Message> message;

        public virtual ICollection<UserRoleRelation> UserRoleRelation
        {
            get
            {
                return userRoleRelation;
            }
        }
        private ICollection<UserRoleRelation> userRoleRelation;
    }
}

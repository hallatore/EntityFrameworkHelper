using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkHelper;

namespace EntityDemo.Model
{
    [Serializable]
    public enum MessageTypes
    {
        Normal = 1,
        Important = 2
    }

    [Serializable]
    public class Message : TableBase
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public int DbType { get; set; }

        public MessageTypes Type
        {
            get { return (MessageTypes) DbType; }
            set { DbType = (int) value;  }
        }

        public User User
        {
            get { return user; }
            set
            {
                if (Object.ReferenceEquals(user, value)) return;
                user = value;

                userId = user != null ? value.Id : 0;

                if (value != null && !value.Message.Contains(this))
                    value.Message.Add(this);
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
    }
}

using EntityDemo.Model;
using System.Data.Objects;
using System.Data.EntityClient;

namespace EntityDemo.Dal.Sql
{
    public class Entities : ObjectContext, IEntities
    {
        public Entities()
            : base("name=Model1Container", "Model1")
        {
            Init();
        }

        public Entities(string connectionString)
            : base(connectionString, "Model1")
        {
            Init();
        }

        public Entities(EntityConnection connection)
            : base(connection, "Model1")
        {
            Init();
        }

        private void Init()
        {
            User = CreateObjectSet<User>("User");
            Message = CreateObjectSet<Message>("Message");
            Role = CreateObjectSet<Role>("Role");
            UserRoleRelation = CreateObjectSet<UserRoleRelation>("UserRoleRelation");
            this.ContextOptions.LazyLoadingEnabled = true;
        }

        IObjectSet<User> IEntities.User
        {
            get { return this.User; }
        }
        protected virtual ObjectSet<User> User { get; set; }

        IObjectSet<Message> IEntities.Message
        {
            get { return this.Message; }
        }
        protected virtual ObjectSet<Message> Message { get; set; }

        IObjectSet<Role> IEntities.Role
        {
            get { return this.Role; }
        }
        protected virtual ObjectSet<Role> Role { get; set; }

        IObjectSet<UserRoleRelation> IEntities.UserRoleRelation
        {
            get { return this.UserRoleRelation; }
        }
        protected virtual ObjectSet<UserRoleRelation> UserRoleRelation { get; set; }
    }
}

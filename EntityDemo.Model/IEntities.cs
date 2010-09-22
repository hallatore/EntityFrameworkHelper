using System.Data.Objects;
using EntityFrameworkHelper;

namespace EntityDemo.Model
{
    public interface IEntities : IObjectContext
    {
        IObjectSet<User> User { get; }
        IObjectSet<Message> Message { get; }
        IObjectSet<Role> Role { get; }
        IObjectSet<UserRoleRelation> UserRoleRelation { get; }
    }
}

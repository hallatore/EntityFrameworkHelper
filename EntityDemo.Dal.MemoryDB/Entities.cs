using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityDemo.Model;
using EntityFrameworkHelper;
using System.Web;
using System.Data.Objects;

namespace EntityDemo.Dal.MemoryDB
{
    [Serializable]
    public class Entities : IEntities
    {
        public Entities()
        {
            User = new MockObjectSet<User>();
            Role = new MockObjectSet<Role>();
            Message = new MockObjectSet<Message>();
            UserRoleRelation = new MockObjectSet<UserRoleRelation>();

            HttpContext context = HttpContext.Current;
            if (context.Session[this.GetType().GUID.ToString()] != null)
            {
                var sessionDb = context.Session[this.GetType().GUID.ToString()] as Entities;

                if (sessionDb != null)
                {
                    Entities newEntity = ObjectCloner.Clone(sessionDb);

                    User = newEntity.User;
                    Message = newEntity.Message;
                    UserRoleRelation = newEntity.UserRoleRelation;
                    Role = newEntity.Role;

                    return;
                }
            }

            LoadDummyData();
            context.Session[this.GetType().GUID.ToString()] = ObjectCloner.Clone(this);
        }

        public IObjectSet<User> User { get; private set; }
        public IObjectSet<Message> Message { get; private set; }
        public IObjectSet<UserRoleRelation> UserRoleRelation { get; private set; }
        public IObjectSet<Role> Role { get; private set; }

        public int SaveChanges()
        {
            HttpContext context = HttpContext.Current;
            var session = context.Session[typeof(Entities).GUID.ToString()] as Entities;

            this.UpdateLinks(session, "User", "Message");
            this.UpdateLinks(session, "User", "UserRoleRelation");
            this.UpdateLinks(session, "Role", "UserRoleRelation");

            context.Session[this.GetType().GUID.ToString()] = ObjectCloner.Clone(this);
            return 1;
        }

        private void LoadDummyData()
        {
            var user1 = new User()
            {
                Id = 1,
                Name = "Tore Lervik",
                Password = "qwerty"
            };

            var user2 = new User()
            {
                Id = 2,
                Name = "Petter hansen",
                Password = "qwerty"
            };

            var user3 = new User()
            {
                Id = 3,
                Name = "Mats Matsen",
                Password = "qwerty"
            };

            var message1 = new Message()
            {
                Id = 1,
                Subject = "Message nr #1",
                Text = "A lot of text in this message nr #1",
                Type = MessageTypes.Normal,
                UserId = 1
            };

            var message2 = new Message()
            {
                Id = 2,
                Subject = "Message nr #2",
                Text = "A lot of text in this message nr #2",
                Type = MessageTypes.Important,
                UserId = 1
            };

            var message3 = new Message()
            {
                Id = 3,
                Subject = "Message nr #3",
                Text = "A lot of text in this message nr #3",
                Type = MessageTypes.Normal,
                UserId = 2
            };

            var role1 = new Role()
            {
                Id = 1,
                Name = "Administrator"
            };

            var role2 = new Role()
            {
                Id = 2,
                Name = "Editor"
            };


            User.AddObject(user1);
            User.AddObject(user2);
            User.AddObject(user3);
            Message.AddObject(message1);
            Message.AddObject(message2);
            Message.AddObject(message3);
            Role.AddObject(role1);
            Role.AddObject(role2);

            UserRoleRelation.AddObject(new UserRoleRelation() {Id = 1, UserId = 1, RoleId = 1});
            UserRoleRelation.AddObject(new UserRoleRelation() { Id = 2, UserId = 1, RoleId = 2 });
            UserRoleRelation.AddObject(new UserRoleRelation() { Id = 3, UserId = 1, RoleId = 2 });
            SaveChanges();
        }

        public void AcceptAllChanges()
        {
            throw new NotImplementedException();
        }

        public void AddObject(string entitySetName, object entity)
        {
            throw new NotImplementedException();
        }

        public TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity ApplyOriginalValues<TEntity>(string entitySetName, TEntity originalEntity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Attach(System.Data.Objects.DataClasses.IEntityWithKey entity)
        {
            throw new NotImplementedException();
        }

        public void AttachTo(string entitySetName, object entity)
        {
            throw new NotImplementedException();
        }

        public int? CommandTimeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Data.Common.DbConnection Connection
        {
            get { throw new NotImplementedException(); }
        }

        public ObjectContextOptions ContextOptions
        {
            get { throw new NotImplementedException(); }
        }

        public void CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public string CreateDatabaseScript()
        {
            throw new NotImplementedException();
        }

        public System.Data.EntityKey CreateEntityKey(string entitySetName, object entity)
        {
            throw new NotImplementedException();
        }

        public T CreateObject<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public ObjectSet<TEntity> CreateObjectSet<TEntity>(string entitySetName) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void CreateProxyTypes(IEnumerable<Type> types)
        {
            throw new NotImplementedException();
        }

        public ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public bool DatabaseExists()
        {
            throw new NotImplementedException();
        }

        public string DefaultContainerName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteDatabase()
        {
            throw new NotImplementedException();
        }

        public void DeleteObject(object entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }

        public void DetectChanges()
        {
            throw new NotImplementedException();
        }

        public int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteStoreCommand(string commandText, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public object GetObjectByKey(System.Data.EntityKey key)
        {
            throw new NotImplementedException();
        }

        public void LoadProperty<TEntity>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, object>> selector, MergeOption mergeOption)
        {
            throw new NotImplementedException();
        }

        public void LoadProperty<TEntity>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, object>> selector)
        {
            throw new NotImplementedException();
        }

        public void LoadProperty(object entity, string navigationProperty, MergeOption mergeOption)
        {
            throw new NotImplementedException();
        }

        public void LoadProperty(object entity, string navigationProperty)
        {
            throw new NotImplementedException();
        }

        public event ObjectMaterializedEventHandler ObjectMaterialized;

        public ObjectStateManager ObjectStateManager
        {
            get { throw new NotImplementedException(); }
        }

        public void Refresh(RefreshMode refreshMode, object entity)
        {
            throw new NotImplementedException();
        }

        public void Refresh(RefreshMode refreshMode, System.Collections.IEnumerable collection)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges(SaveOptions options)
        {
            throw new NotImplementedException();
        }

        public event EventHandler SavingChanges;

        public ObjectResult<TEntity> Translate<TEntity>(System.Data.Common.DbDataReader reader, string entitySetName, MergeOption mergeOption)
        {
            throw new NotImplementedException();
        }

        public ObjectResult<TElement> Translate<TElement>(System.Data.Common.DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public bool TryGetObjectByKey(System.Data.EntityKey key, out object value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

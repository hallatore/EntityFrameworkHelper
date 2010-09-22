using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using EntityFrameworkHelper;

namespace EntityDemo.Model
{
    [Serializable]
    public class Role : TableBase
    {
        public Role()
        {
            userRoleRelation = new ObservableCollection<UserRoleRelation>();
            ModelHelper.OneToMany<UserRoleRelation>(userRoleRelation, "Role", this);
        }

        public string Name { get; set; }

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

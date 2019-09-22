using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class User : BaseEntity
    {
        public Guid IdentityGuid { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
    }
}

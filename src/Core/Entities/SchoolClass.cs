using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class SchoolClass : BaseEntity
    {
        public string Name { get; set; }
        public Guid TecherId { get; set; }
        public Guid SchoolAdminId { get; set; }  
        public virtual Teacher Teacher { get; set; } 
        public virtual School SchoolAdmin { get; set; }

    }
}

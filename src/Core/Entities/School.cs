using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Domain { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }     
        public virtual ICollection<Survey> Surveys { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public Guid SchoolClassId { get; set; }     
        public virtual SchoolClass SchoolClass { get; set; }       
        public virtual ICollection<SurveyRecord> SurveyRecords { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}

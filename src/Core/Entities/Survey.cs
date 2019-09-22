using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Survey : BaseEntity
    {
        public string Name { get; set; }
        public SurveyStatus Status { get; set; }
        public Guid SchoolAdminId { get; set; }   
        public virtual School SchoolAdmin { get; set; }       
        public virtual ICollection<SurveyClass> SurveyClasses { get; set; }
    }


    public enum SurveyStatus
    {
        Open = 1,
        Closed = 2
    }
}

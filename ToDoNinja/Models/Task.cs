//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoNinja.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public int ResourceID { get; set; }
        public int StatusID { get; set; }
        public int PriorityID { get; set; }
        public int UrgencyID { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    
        public virtual Priority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Status Status { get; set; }
        public virtual Urgency Urgency { get; set; }
    }
}

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
    
    public partial class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime DateDue { get; set; }
        public System.DateTime DateStart { get; set; }
        public int PercentComplete { get; set; }
        public string UpdaedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
    
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProlabProje3
{
    using System;
    using System.Collections.Generic;
    
    public partial class AcedemicMember
    {
        public AcedemicMember()
        {
            this.Groups = new HashSet<Group>();
            this.Lessons = new HashSet<Lesson>();
            this.Departments = new HashSet<Department>();
        }
    
        public int AcedemicMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegisterNumber { get; set; }
    
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RolePermissionGroup
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionGroupId { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual PermissionGroup PermissionGroup { get; set; }
        public virtual Role Role { get; set; }
    }
}

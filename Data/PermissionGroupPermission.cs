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
    
    public partial class PermissionGroupPermission
    {
        public int Id { get; set; }
        public int PermissionGroupId { get; set; }
        public int PermissionId { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Permission Permission { get; set; }
        public virtual PermissionGroup PermissionGroup { get; set; }
    }
}
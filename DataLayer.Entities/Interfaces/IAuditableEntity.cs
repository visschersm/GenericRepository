using System;

namespace DataLayer.Entities.Interfaces
{
    interface IAuditableEntity
    {
        DateTime Created { get; set; }
        int CreatedById { get; set; }
        DateTime? LastModified { get; set; }
        int? LastModifiedBy { get; set; }
    }
}

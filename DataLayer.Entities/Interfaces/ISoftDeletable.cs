using System;

namespace DataLayer.Entities.Interfaces
{
    public interface ISoftDeletable
    {
        DateTime? DeletedOn { get; set; }
        int? DeletedBy { get; set; }
    }
}

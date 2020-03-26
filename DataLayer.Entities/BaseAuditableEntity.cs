using DataLayer.Entities.Interfaces;
using System;

namespace DataLayer.Entities
{
    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity, IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        public DateTime Created { get; set; }
        public int CreatedById { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}

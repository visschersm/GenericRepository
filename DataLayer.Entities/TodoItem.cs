using DataLayer.Entities.Interfaces;
using System;

namespace DataLayer.Entities
{
    public class TodoItem : BaseAuditableEntity<int>, ISoftDeletable
    {
        public string Title { get; set; } = null!;
        public bool IsComplete { get; set; } = false;

        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
    }
}

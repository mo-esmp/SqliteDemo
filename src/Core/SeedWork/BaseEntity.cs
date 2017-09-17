using System;

namespace Core.SeedWork
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
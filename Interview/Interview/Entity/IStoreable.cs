using System;

namespace Interview.Entity
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
    }
    
}
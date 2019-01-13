using System;

namespace SriSloka.SharedKernel
{
    public interface IStateObject
    {
        ObjectState ObjectState { get; set; }
    }

    public enum ObjectState
    {
        Unchanged = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SriSloka.Model
{
    public class TrackableEntity: ITrackableEntity
    {
        public DateTime UpdatedTime { get; set; }
        public DateTime InsertedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }

    public interface ITrackableEntity
    {
        DateTime UpdatedTime { get; set; }

        DateTime InsertedTime { get; set; }

        string LastModifiedBy { get; set; }
    }
}

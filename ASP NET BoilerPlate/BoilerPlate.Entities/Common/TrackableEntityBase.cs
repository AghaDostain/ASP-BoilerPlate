using System;

namespace BoilerPlate.Entities
{
    public abstract class TrackableEntityBase<TId> : KeyedEntityBase<TId>
    {
        public Nullable<int> CreatedBy { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<int> ModifiedBy { get; set; }

        public Nullable<DateTime> ModifiedOn { get; set; }
    }
}

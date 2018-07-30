using System;

namespace BoilerPlate.Entities
{
    public abstract class BaseEntityTrackable
    {
        public Nullable<int> CreatedBy { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }

        public Nullable<int> ModifiedBy { get; set; }

        public Nullable<DateTime> ModifiedOn { get; set; }
    }

}

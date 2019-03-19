namespace ProjectEWS.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MasterRole
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public int? MasterId { get; set; }

        public virtual Master Master { get; set; }

        public virtual Role Role { get; set; }
    }
}

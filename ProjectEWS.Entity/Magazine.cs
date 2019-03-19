namespace ProjectEWS.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Magazine
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int StudentId { get; set; }

        public DateTime SentDate { get; set; }

        public string Comment { get; set; }

        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Student Student { get; set; }
    }
}

namespace Student.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Record")]
    public partial class Record
    {
        public int RecordID { get; set; }
        [DisplayName("µÇÂ¼Ãû³Æ")]
        public int StudentID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("µÇÂ¼ÃÜÂë")]
        public string RecordPassword { get; set; }
        [DisplayName("µÇÂ¼Éí·Ý")]
        public int? Pid { get; set; }

        //public virtual Position Position { get; set; }

        //public virtual StudentInfo StudentInfo { get; set; }
    }
}

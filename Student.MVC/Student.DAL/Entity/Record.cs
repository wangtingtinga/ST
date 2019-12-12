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
        [DisplayName("��¼����")]
        public int StudentID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("��¼����")]
        public string RecordPassword { get; set; }
        [DisplayName("��¼���")]
        public int? Pid { get; set; }

        //public virtual Position Position { get; set; }

        //public virtual StudentInfo StudentInfo { get; set; }
    }
}

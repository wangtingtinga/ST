namespace Student.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentInfo")]
    public partial class StudentInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentInfo()
        {
            Record = new HashSet<Record>();
        }

        [Key]
        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("����")]
        public string StudentName { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("�Ա�")]
        public string StudentSex { get; set; }

        [DisplayName("����")]
        public int StudentAge { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("�绰")]
        public string StudentPhone { get; set; }

        [DisplayName("רҵ")]
        public int? MajorID { get; set; }

        [DisplayName("�ɼ�")]
        public int? Score { get; set; }
        [DisplayName("ְλ")]
        public int? Pid { get; set; }

        //public virtual Major Major { get; set; }

        //public virtual Position Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Record> Record { get; set; }
    }
}

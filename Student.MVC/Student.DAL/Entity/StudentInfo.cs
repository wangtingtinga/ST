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
        [DisplayName("名字")]
        public string StudentName { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("性别")]
        public string StudentSex { get; set; }

        [DisplayName("年龄")]
        public int StudentAge { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("电话")]
        public string StudentPhone { get; set; }

        [DisplayName("专业")]
        public int? MajorID { get; set; }

        [DisplayName("成绩")]
        public int? Score { get; set; }
        [DisplayName("职位")]
        public int? Pid { get; set; }

        //public virtual Major Major { get; set; }

        //public virtual Position Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Record> Record { get; set; }
    }
}

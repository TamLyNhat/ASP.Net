namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(5)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(5)]
        public string MaQuyen { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        public bool? Phai { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(15)]
        public string DiaChiNV { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SoDienThoaiNV { get; set; }

        [StringLength(24)]
        public string MatKhauNV { get; set; }
    }
}

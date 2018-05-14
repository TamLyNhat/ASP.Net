namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoginABCD : DbContext
    {
        public LoginABCD()
            : base("name=LoginABCD")
        {
        }

        public virtual DbSet<NhanVien> NhanVien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TenNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DiaChiNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoaiNV)
                .HasPrecision(15, 0);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhauNV)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

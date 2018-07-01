namespace Plataforma_FindU.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class bd_FindU : DbContext
    {
        public bd_FindU()
            : base("name=bd_FindU")
        {
        }

        public virtual DbSet<tb_curso> tb_curso { get; set; }
        public virtual DbSet<tb_demonstracao_interesse> tb_demonstracao_interesse { get; set; }
        public virtual DbSet<tb_match> tb_match { get; set; }
        public virtual DbSet<tb_usuario> tb_usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_curso>()
                .Property(e => e.des_nome_cur)
                .IsUnicode(false);

            modelBuilder.Entity<tb_curso>()
                .HasMany(e => e.tb_usuario)
                .WithRequired(e => e.tb_curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_usuario>()
                .Property(e => e.des_nome_usu)
                .IsUnicode(false);

            modelBuilder.Entity<tb_usuario>()
                .Property(e => e.des_biografia_usu)
                .IsUnicode(false);

            modelBuilder.Entity<tb_usuario>()
                .Property(e => e.des_genero_usu)
                .IsUnicode(false);

            modelBuilder.Entity<tb_usuario>()
                .Property(e => e.des_orientacao_usu)
                .IsUnicode(false);

            modelBuilder.Entity<tb_usuario>()
                .Property(e => e.cod_senha_usu)
                .IsUnicode(false);

            modelBuilder.Entity<tb_usuario>()
                .Property(e => e.des_email_usu)
                .IsUnicode(false);

            modelBuilder.Entity<tb_usuario>()
                .HasMany(e => e.tb_demonstracao_interesse)
                .WithOptional(e => e.tb_usuario)
                .HasForeignKey(e => e.cod_interessado_por_int);

            modelBuilder.Entity<tb_usuario>()
                .HasMany(e => e.tb_demonstracao_interesse1)
                .WithOptional(e => e.tb_usuario1)
                .HasForeignKey(e => e.cod_usuario_interessado_int);

            modelBuilder.Entity<tb_usuario>()
                .HasMany(e => e.tb_match)
                .WithOptional(e => e.tb_usuario)
                .HasForeignKey(e => e.cod_usuario_um_mat);

            modelBuilder.Entity<tb_usuario>()
                .HasMany(e => e.tb_match1)
                .WithOptional(e => e.tb_usuario1)
                .HasForeignKey(e => e.cod_usuario_dois_mat);
        }
    }
}

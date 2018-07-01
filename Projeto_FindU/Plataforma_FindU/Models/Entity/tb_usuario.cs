namespace Plataforma_FindU.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_usuario()
        {
            tb_demonstracao_interesse = new HashSet<tb_demonstracao_interesse>();
            tb_demonstracao_interesse1 = new HashSet<tb_demonstracao_interesse>();
            tb_match = new HashSet<tb_match>();
            tb_match1 = new HashSet<tb_match>();
        }

        [Key]
        public int cod_usuario_usu { get; set; }

        [StringLength(150)]
        [Display(Name = "Nome")]
        public string des_nome_usu { get; set; }

        [Display(Name = "Idade")]
        public int? num_idade_usu { get; set; }

        [Display(Name = "Curso")]
        public int cod_curso_cur { get; set; }

        [Display(Name = "Semestre")]
        public int? num_semestre_usu { get; set; }

        [StringLength(500)]
        [Display(Name = "Biografia")]
        public string des_biografia_usu { get; set; }

        [StringLength(50)]
        [Display(Name = "Gênero")]
        public string des_genero_usu { get; set; }

        [StringLength(100)]
        [Display(Name = "Orientação Sexual")]
        public string des_orientacao_usu { get; set; }

        public bool? sts_status_usu { get; set; }

        public DateTime? dat_cadastro_usu { get; set; }

        [StringLength(15)]
        public string cod_senha_usu { get; set; }

        [StringLength(100)]
        public string des_email_usu { get; set; }

        public virtual tb_curso tb_curso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_demonstracao_interesse> tb_demonstracao_interesse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_demonstracao_interesse> tb_demonstracao_interesse1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_match> tb_match { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_match> tb_match1 { get; set; }
    }
}

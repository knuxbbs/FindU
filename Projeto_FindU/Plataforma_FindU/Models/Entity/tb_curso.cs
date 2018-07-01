namespace Plataforma_FindU.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_curso()
        {
            tb_usuario = new HashSet<tb_usuario>();
        }

        [Key]
        public int cod_curso_cur { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Curso")]
        public string des_nome_cur { get; set; }

        public DateTime? dat_cadastro_cur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario { get; set; }
    }
}

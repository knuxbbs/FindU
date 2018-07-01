namespace Plataforma_FindU.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_match
    {
        [Key]
        public int cod_match_mat { get; set; }

        public int? cod_usuario_um_mat { get; set; }

        public int? cod_usuario_dois_mat { get; set; }

        public DateTime? dat_match_mat { get; set; }

        public virtual tb_usuario tb_usuario { get; set; }

        public virtual tb_usuario tb_usuario1 { get; set; }
    }
}

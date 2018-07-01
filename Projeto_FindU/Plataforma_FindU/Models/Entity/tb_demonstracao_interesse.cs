namespace Plataforma_FindU.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_demonstracao_interesse
    {
        [Key]
        public int cod_interesse_int { get; set; }

        public int? cod_usuario_interessado_int { get; set; }

        public int? cod_interessado_por_int { get; set; }

        public DateTime? dat_interesse_int { get; set; }

        public virtual tb_usuario tb_usuario { get; set; }

        public virtual tb_usuario tb_usuario1 { get; set; }
    }
}

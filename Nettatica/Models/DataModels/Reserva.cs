namespace Nettatica.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserva")]
    public partial class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdReserva { get; set; }

        public int IdVuelo { get; set; }

        public int IdCliente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Precio { get; set; }

        public virtual Vuelo Vuelo { get; set; }
    }
}

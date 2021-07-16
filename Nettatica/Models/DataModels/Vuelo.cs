namespace Nettatica.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vuelo")]
    public partial class Vuelo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vuelo()
        {
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVuelo { get; set; }

        public TimeSpan HoraSalida { get; set; }

        public int AeropuertoOrigen { get; set; }

        public TimeSpan HoraLlegada { get; set; }

        public int AeropuertoDestino { get; set; }

        public int Aerolinea { get; set; }

        public virtual Aerolinea Aerolinea1 { get; set; }

        public virtual Aeropuerto Aeropuerto { get; set; }

        public virtual Aeropuerto Aeropuerto1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}

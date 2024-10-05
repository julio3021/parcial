using System.ComponentModel.DataAnnotations.Schema;


namespace parcial.Models
{
    [Table("t_historial_conversion")]
    public class HistorialConversion
    {
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public decimal TasaConversion { get; set; }
        public decimal TipoConversion { get; set; }  
    }
}
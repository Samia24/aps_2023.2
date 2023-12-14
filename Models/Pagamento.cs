using Microsoft.VisualBasic;

namespace samiabraga.Models
{
   public class Pagamento
   {
       public int Id { get; set; }
       public DateTime DataLimite { get; set; }
       public double Valor { get; set; }
       public bool Pago { get; set; }
       
   }
}
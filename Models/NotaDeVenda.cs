using Microsoft.VisualBasic;

namespace samiabraga.Models
{
   public class NotaDeVenda
   {
       public int Id { get; set; }
       public DateTime Data { get; set; }
       public bool Tipo { get; set; }

       
       public ICollection<Item> Itens { get; set; } = new List<Item>();
       public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();


       public void Cancelar(){
        if (this.Tipo == true)
            {
                throw new Exception("Nota cancelada!");
            }
            else
            {
                this.Tipo = true;
            }
       }
       public void Devolver(){
        if (this.Tipo == false)
            {
                throw new Exception("Nota devolvida!");
            }
            else
            {
                this.Tipo = false;
            }
       }
   }
}

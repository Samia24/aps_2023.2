namespace samiabraga.Models
{
   public class Produto
   {
       public int Id { get; set; }
       public string Nome { get; set; }
       public string Descricao { get; set; }
       public int Quantidade { get; set; }
       public double Preco { get; set; }

       public ICollection<Item> Itens { get; set; } = new List<Item>();

   }
}

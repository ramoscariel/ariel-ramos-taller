using System.ComponentModel.DataAnnotations;

namespace ArielRamos_Taller.Models
{
    public class Burger
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [Range(0.01, 100.99)]
        public decimal Precio { get; set; }
    }
}

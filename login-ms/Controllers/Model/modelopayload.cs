using System.ComponentModel.DataAnnotations;

namespace Presentation.Application.Controllers.Model
{
    public class modelopayload
    {
        [Required]
        public string Nome { get; set; }
        public int Ano { get; set;}
    }
}

using System.Text.Json.Serialization;

namespace APIAMBIPARDEV.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Ocorrencia>? OcorrenciasAbertas { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Ocorrencia>? OcorrenciasResponsaveis { get; set; }

    }
}

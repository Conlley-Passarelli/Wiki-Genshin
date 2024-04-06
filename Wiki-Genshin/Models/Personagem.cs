namespace Wiki_Genshin.Models;

    public class Personagem
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Elemento { get; set; } = [];
        public string Regiao { get; set; }
        public string Aniversario { get; set; }
        public string Imagem { get; set; }
    }

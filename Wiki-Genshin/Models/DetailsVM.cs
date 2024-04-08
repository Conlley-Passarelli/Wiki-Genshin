namespace Wiki_Genshin.Models;

public class DetailsVM
{
    public Personagem Anterior { get; set; }
    public Personagem Atual { get; set; }
    public Personagem Proximo { get; set; }
    public List<Elemento> Elementos { get; set; }
}
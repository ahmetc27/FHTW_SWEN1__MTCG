namespace MTCG;

public class Card
{
    public enum ElementType
    {
        Spell,
        Monster
    }
    public string? Name { get; set; }
    public int Damage { get; set; }
    public ElementType Element { get; set; }
    
    public Card(int element, string name, int damage)
    {
        element = element;
        name = name;
        damage = damage;
    }
}
namespace MTCG;

public class Deck
{
    private readonly List<Card> Cards = [];

    public void ListCounter()
    {
        Console.WriteLine(Cards.Count);   
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);
    }
}
using System;
using System.Timers;


/// Representerar en nod i sjukhushierarkin.
/// Trädet använder modellen FirstChild / NextSibling
/// för att kunna ha flera barn per nod.

class HospitalNode
{
    // Namnet på noden, t.ex. Sjukhus, Avdelning eller Rum.
    public string Name;

    // Referens till nodens första barn.
    // Exempel: Sjukhus -> Kirurgi
    public HospitalNode FirstChild;

    // Referens till nästa syskon på samma nivå.
    // Exempel: Kirurgi -> Ortopedi
    public HospitalNode NextSibling;

    /// Skapar en ny nod med angivet namn.

   
    public HospitalNode(string name)
    {
        Name = name;
    }
}

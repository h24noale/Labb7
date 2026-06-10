using System;


/// Representerar en nod i beslutsträdet.
/// En nod kan vara antingen en fråga eller ett slutgiltigt råd.

class DecisionNode
{
    // Texten som visas för användaren.
    // Kan vara en fråga eller ett råd.
    public string Text;

    // Anger om noden är en fråga.
    // true = fråga
    // false = slutgiltigt råd (lövnod)
    public bool IsQuestion;

    // Referens till nästa nod om användaren svarar "Ja".
    public DecisionNode Yes;

    // Referens till nästa nod om användaren svarar "Nej".
    public DecisionNode No;
}
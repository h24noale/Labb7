using System;


/// Representerar en tidbokning i ett binärt sökträd.
/// Varje nod innehåller en tid samt referenser
/// till vänster och höger barnnod.
class BookingNode
{
    // Bokningstid som lagras i noden
    public int Time;

    // Referens till vänster barnnod
    // (innehåller mindre tider än aktuell nod)
    public BookingNode Left;

    // Referens till höger barnnod
    // (innehåller större eller lika stora tider än aktuell nod)
    public BookingNode Right;

    /// Skapar en ny bokningsnod med angiven tid.
    /// time är bokningstiden som ska sparas i noden
    public BookingNode(int time)
    {
        Time = time;
    }
}

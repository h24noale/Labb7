using System;

class BookingNode
{
    public int Time;
    public BookingNode Left;
    public BookingNode Right;

    public BookingNode(int time)
    {
        Time = time;
    }
}

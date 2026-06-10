using System;

class HospitalNode
{
    public string Name;
    public HospitalNode FirstChild;
    public HospitalNode NextSibling;

    public HospitalNode(string name)
    {
        Name = name;
    }
}

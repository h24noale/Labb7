using System;

class Program
{
    static void Main()
    {
        // Skapar roten i trädet
        var hospital = new HospitalNode("Sjukhus");

        // Skapar avdelningar
        var surgery = new HospitalNode("Kirurgi");
        var orthopedics = new HospitalNode("Ortopedi");

        // Kopplar avdelningarna till sjukhuset
        hospital.FirstChild = surgery;
        surgery.NextSibling = orthopedics;

        // Lägger till rum under Kirurgi
        surgery.FirstChild = new HospitalNode("Rum 101");
        surgery.FirstChild.NextSibling = new HospitalNode("Rum 102");

        Console.WriteLine("SJUKHUSHIERARKI");

        // Startar Pre-order traversal från roten
        TraversePreOrder(hospital, 0);

        // Tom rot från början
        BookingNode root = null;

        // Lägger in bokningstider i trädet
        root = Insert(root, 15);
        root = Insert(root, 8);
        root = Insert(root, 22);
        root = Insert(root, 5);
        root = Insert(root, 12);

        Console.WriteLine("\nTIDBOKNINGAR I ORDNING");

        // Skriver ut tiderna sorterade med In-order traversal
        InOrder(root);

     
        // Rotfråga
        var diagnosisRoot = new DecisionNode
        {
            Text = "Har du feber?",
            IsQuestion = true
        };

        // Ja-svar leder direkt till ett råd
        diagnosisRoot.Yes = new DecisionNode
        {
            Text = "Kontakta vården vid behov.",
            IsQuestion = false
        };

        // Nej-svar leder till nästa fråga
        diagnosisRoot.No = new DecisionNode
        {
            Text = "Har du ont i halsen?",
            IsQuestion = true
        };

        // Ja-svar på fråga två
        diagnosisRoot.No.Yes = new DecisionNode
        {
            Text = "Vila och drick mycket vatten.",
            IsQuestion = false
        };

        // Nej-svar på fråga två
        diagnosisRoot.No.No = new DecisionNode
        {
            Text = "Du verkar inte behöva vård just nu.",
            IsQuestion = false
        };

        Console.WriteLine("\nDIAGNOS-BOT");

        // Startar den iterativa traverseringen
        RunDecisionTree(diagnosisRoot);
    }

    
    /// Pre-order traversal för sjukhusträdet.
    /// Skriver först ut aktuell nod,
    /// sedan dess barn och därefter syskon.
       static void TraversePreOrder(HospitalNode node, int level)
    {
        // Avsluta om noden saknas
        if (node == null)
            return;

        // Skriver ut noden med indrag beroende på nivå
        Console.WriteLine(new string(' ', level * 2) + node.Name);
        // Besöker syskonnoden
        TraversePreOrder(node.NextSibling, level);

        // Besöker barnnoden
        TraversePreOrder(node.FirstChild, level + 1);

        


    }

     /// In-order traversal för binärt sökträd.
    /// Besöker vänster nod, aktuell nod och höger nod.
    /// Ger sorterad utskrift.
   
    static void InOrder(BookingNode node)
    {
        if (node == null)
            return;

        InOrder(node.Left);

        Console.WriteLine(node.Time);

        InOrder(node.Right);
    }

  
    /// Lägger in en ny tid i det binära sökträdet.
    /// Mindre tider placeras till vänster,
    /// större eller lika stora till höger.
    
    static BookingNode Insert(BookingNode root, int time)
    {
        // Skapar en ny nod om platsen är tom
        if (root == null)
            return new BookingNode(time);

        // Vänster delträd
        if (time < root.Time)
            root.Left = Insert(root.Left, time);

        // Höger delträd
        else
            root.Right = Insert(root.Right, time);

        return root;
    }

    
    /// Iterativ traversering av beslutsträdet.
    /// Användaren svarar ja eller nej
    /// tills ett slutgiltigt råd nås.
   
    static void RunDecisionTree(DecisionNode node)
    {
        // Startar vid roten
        DecisionNode current = node;

        // Fortsätt så länge aktuell nod är en fråga
        while (current.IsQuestion)
        {
            Console.Write(current.Text + " (ja/nej): ");

            string answer = Console.ReadLine()?.ToLower();

            // Flytta till nästa nod beroende på svaret
            if (answer == "ja")
                current = current.Yes;
            else
                current = current.No;
        }

        // Ett löv har nåtts och ett råd kan visas
        Console.WriteLine("Råd: " + current.Text);
    }
}
using System;

class Program
{
    static void Main()
    {
        // =========================
        // Uppgift 1 - Sjukhusträd
        // =========================

        var hospital = new HospitalNode("Sjukhus");

        var surgery = new HospitalNode("Kirurgi");
        var orthopedics = new HospitalNode("Ortopedi");

        hospital.FirstChild = surgery;
        surgery.NextSibling = orthopedics;

        surgery.FirstChild = new HospitalNode("Rum 101");
        surgery.FirstChild.NextSibling = new HospitalNode("Rum 102");

        Console.WriteLine("SJUKHUSHIERARKI");
        TraversePreOrder(hospital, 0);

        // =========================
        // Uppgift 2 - BST
        // =========================

        BookingNode root = null;

        root = Insert(root, 15);
        root = Insert(root, 8);
        root = Insert(root, 22);
        root = Insert(root, 5);
        root = Insert(root, 12);

        Console.WriteLine("\nTIDBOKNINGAR I ORDNING");
        InOrder(root);

        // =========================
        // Uppgift 3 - Beslutsträd
        // =========================

        var diagnosisRoot = new DecisionNode
        {
            Text = "Har du feber?",
            IsQuestion = true
        };

        diagnosisRoot.Yes = new DecisionNode
        {
            Text = "Kontakta vården vid behov.",
            IsQuestion = false
        };

        diagnosisRoot.No = new DecisionNode
        {
            Text = "Har du ont i halsen?",
            IsQuestion = true
        };

        diagnosisRoot.No.Yes = new DecisionNode
        {
            Text = "Vila och drick mycket vatten.",
            IsQuestion = false
        };

        diagnosisRoot.No.No = new DecisionNode
        {
            Text = "Du verkar inte behöva vård just nu.",
            IsQuestion = false
        };

        Console.WriteLine("\nDIAGNOS-BOT");
        RunDecisionTree(diagnosisRoot);
    }

    static void TraversePreOrder(HospitalNode node, int level)
    {
        if (node == null)
            return;

        Console.WriteLine(new string(' ', level * 2) + node.Name);

        TraversePreOrder(node.FirstChild, level + 1);
        TraversePreOrder(node.NextSibling, level);
    }

    static void InOrder(BookingNode node)
    {
        if (node == null)
            return;

        InOrder(node.Left);
        Console.WriteLine(node.Time);
        InOrder(node.Right);
    }

    static BookingNode Insert(BookingNode root, int time)
    {
        if (root == null)
            return new BookingNode(time);

        if (time < root.Time)
            root.Left = Insert(root.Left, time);
        else
            root.Right = Insert(root.Right, time);

        return root;
    }

    static void RunDecisionTree(DecisionNode node)
    {
        DecisionNode current = node;

        while (current.IsQuestion)
        {
            Console.Write(current.Text + " (ja/nej): ");
            string answer = Console.ReadLine()?.ToLower();

            if (answer == "ja")
                current = current.Yes;
            else
                current = current.No;
        }

        Console.WriteLine("Råd: " + current.Text);
    }
}
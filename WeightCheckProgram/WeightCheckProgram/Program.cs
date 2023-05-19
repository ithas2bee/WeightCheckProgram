using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int maxWeight = 2500;
        int currentWeight = 0;

        Console.WriteLine("Welcome to the New Year's Eve party!");

        Console.Write("How many participants are entering the elevator? ");
        int numParticipants = int.Parse(Console.ReadLine());

        List<PartyParticipant> participants = new List<PartyParticipant>();

        for (int i = 0; i < numParticipants; i++)
        {
            Console.Write("Enter the name of participant #" + (i + 1) + ": ");
            string name = Console.ReadLine();

            Console.Write("Enter the weight of participant #" + (i + 1) + " (in pounds): ");
            int weight = int.Parse(Console.ReadLine());

            Console.Write("Enter the type of participant (DJ, Bartender, Server, Caterer, or BandMember): ");
            string participantType = Console.ReadLine();

            PartyParticipant participant;
            switch (participantType.ToLower())
            {
                case "dj":
                    participant = new DJ(name, weight);
                    break;
                case "bartender":
                    participant = new Bartender(name, weight);
                    break;
                case "server":
                    participant = new Server(name, weight);
                    break;
                case "caterer":
                    participant = new Caterer(name, weight);
                    break;
                case "bandmember":
                    participant = new BandMember(name, weight);
                    break;
                default:
                    Console.WriteLine("Invalid participant type. Defaulting to PartyParticipant.");
                    participant = new PartyParticipant(name, weight);
                    break;
            }

            participants.Add(participant);
        }

        Console.WriteLine("\nParticipants in the elevator:");
        foreach (PartyParticipant participant in participants)
        {
            Console.WriteLine(participant);
            currentWeight += participant.Weight;
        }

        Console.WriteLine("\nTotal weight of participants: " + currentWeight + " pounds");

        // Compare the current weight with the maximum weight allowed
        if (currentWeight <= maxWeight)
        {
            Console.WriteLine("Let's go");
        }
        else
        {
            int excessWeight = currentWeight - maxWeight;
            Console.WriteLine("This elevator is too heavy by " + excessWeight + " pounds.");
        }
    }
}

// Base class representing a party participant
class PartyParticipant
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public PartyParticipant(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight} pounds");
    }
}

// Derived classes representing different types of party participants
class DJ : PartyParticipant
{
    public DJ(string name, int weight) : base(name, weight)
    {
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"DJ: Name: {Name}, Weight: {Weight} pounds");
    }
}

class Bartender : PartyParticipant
{
    public Bartender(string name, int weight) : base(name, weight)
    {
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Bartender: Name: {Name}, Weight: {Weight} pounds");
    }
}

class Server : PartyParticipant
{
    public Server(string name, int weight) : base(name, weight)
    {

    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Server: Name: {Name}, Weight: {Weight} pounds");
    }
}

class Caterer : PartyParticipant
{
    public Caterer(string name, int weight) : base(name, weight)
    {
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Caterer: Name: {Name}, Weight: {Weight} pounds");
    }
}

class BandMember : PartyParticipant
{
    public BandMember(string name, int weight) : base(name, weight)
    {
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Band Member: Name: {Name}, Weight: {Weight} pounds");
    }
}


using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new PersonQueue();

    public int Length => _people.Length;

    /// <summary>
    /// Add a person to the queue with a name and number of turns remaining.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and display their name.
    /// Re-enqueue the person unless they have no more turns left (turns <= 0).
    /// Display an error message if the queue is empty.
    /// </summary>
    public void GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            Console.WriteLine("Error: Queue is empty.");
            return;
        }

        Person person = _people.Dequeue();
        Console.WriteLine(person.Name);

        if (person.Turns > 0)
        {
            person.Turns--; // Decrease turns if finite
            _people.Enqueue(person);
        }
        else
        {
            // For turns <= 0 (infinite turns), no need to decrease turns
            _people.Enqueue(person);
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }

    /// <summary>
    /// Inner class to manage the queue of people.
    /// </summary>
    private class PersonQueue
    {
        private Queue<Person> queue;

        public PersonQueue()
        {
            queue = new Queue<Person>();
        }

        public int Length => queue.Count;

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public void Enqueue(Person person)
        {
            queue.Enqueue(person);
        }

        public Person Dequeue()
        {
            return queue.Dequeue();
        }

        public override string ToString()
        {
            return $"PersonQueue: Count={queue.Count}";
        }
    }

    /// <summary>
    /// Inner class representing a person with a name and turns remaining.
    /// </summary>
    public class Person
    {
        public string Name { get; }
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }
    }
}

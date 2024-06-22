using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new PersonQueue();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and display them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left. Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns. An error message is displayed 
    /// if the queue is empty.
    /// </summary>
    public void GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            Console.WriteLine("No one in the queue.");
        }
        else
        {
            Person person = _people.Dequeue();
            if (person.Turns > 1)
                person.Turns -= 1;
            else if (person.Turns <= 0)
                person.Turns = 0; // Handle infinite turns scenario

            _people.Enqueue(person);

            Console.WriteLine(person.Name);
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

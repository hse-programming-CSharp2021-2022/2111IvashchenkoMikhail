using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Seminar_19._11
{
    abstract class Person
    {
        protected string Name { get; }
        protected string Pocket { get; set; }
        
        protected Person(string name)
        {
            Name = name;
            Pocket = string.Empty;
        }

        public abstract void Receive(string present);

        public override string ToString()
        {
            if (Pocket != string.Empty)
                return Name + ": " + Pocket;

            return Name;
        }
    }

    internal class SnowMaiden : Person
    { 
        public SnowMaiden(string name) : base(name)
        {
        }
        
        public string[] CreatePresents(int amount)
        {
            var gifts = new string[amount];
            for (int i = 0; i < gifts.Length; i++)
                gifts[i] = CreateGift();
            
            return gifts;
        }

        private string CreateGift()
        {
            var present = "";
            Random random = new();
            for (int i = 0; i < 3; i++)
                present += (char) random.Next('a','z' + 1);

            present += $"{present[1]}" + $"{present[0]}";
            
            return present;
        }

        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException($"Person {Name} already have a present.");
        }
    }
    
    class Santa : Person
    {
        private readonly List<string> _sack;
        
        public Santa(string name) : base(name)
        {
            _sack = new List<string>();
        }
        
        public void Request(SnowMaiden snowMaiden, int amount)
        {
            string[] gifts = snowMaiden.CreatePresents(amount);
            _sack.AddRange(gifts);
        }
        
        public void Give(Person person)
        {
            if (_sack.Count > 0)
            {
                Random random = new();
                int n = random.Next(0, _sack.Count);

                string present = _sack[n];
                _sack.RemoveAt(n);
                person.Receive(present);
            }
            else
            {
                throw new IndexOutOfRangeException("There're no presents left in the Santa's sack.");
            }
        }
        
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException($"Person {Name} already have a present.");
        }
    }
    
    class Child : Person
    {
        private string AdditionalPocket { get; set; }
        
        public Child(string name) : base(name)
        {
            AdditionalPocket = string.Empty;
        }
        
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else if (AdditionalPocket.Equals(string.Empty))
                AdditionalPocket = present;
            else
                throw new ArgumentException($"Child {Name} already have two presents.");
        }
        
        public override string ToString()
        {
            if (AdditionalPocket != string.Empty)
                return Name + ": " + Pocket + ", " + AdditionalPocket;

            if (Pocket == string.Empty)
                return Name;
            
            return Name + ": " + Pocket;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var santa = new Santa("Santa");
            var snowMaiden = new SnowMaiden("SnowMaiden");
            
            var random = new Random();
            var people = new List<Person>
            {
                santa,
                snowMaiden
            };

            var kidsNames = new List<string>
            {
                "Bob", "Ben", "Barry", "Bishop", "Brendan",
                "Gianna", "Georgia", "Greta", "Gina", "Gabrielle"
            };
            
            // Добавление 10 Child в people, с помощью списка имен kidsNames.  
            const int numberOfKids = 10;
            for (var i = 0; i < numberOfKids; i++)
            {
                var n = random.Next(0, kidsNames.Count);
                people.Add(new Child(kidsNames[n]));
                kidsNames.RemoveAt(n);
            }
            
            while (true)
            {
                if (!people.Contains(santa))
                    break;

                if (people.Contains(santa) && people.Count == 1)
                    break;

                if (!people.Contains(snowMaiden))
                    break;
                    
                santa.Request(snowMaiden, random.Next(1, 5));
                var prob = random.Next(0, 101);
                Person randomPerson = people[random.Next(1, people.Count)];
                try
                {
                    if (prob > 10)
                    {
                        santa.Give(randomPerson);
                    }
                    else
                    {
                        santa.Give(people[0]);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    
                    if (prob > 10)
                        people.Remove(randomPerson);
                    else
                        people.Remove(santa);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine();
            people.ForEach(Console.WriteLine);
        }
    }
}
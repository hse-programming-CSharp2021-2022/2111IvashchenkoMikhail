using System;

namespace SeminarTask1
{
    abstract class Animal
    {
        protected string Name { get; set; }
        protected int Age { get; set; }

        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        protected virtual string AnimalSound()
        {
            return null;
        }

        protected void AnimalInfo()
        {
            Console.WriteLine($"Кличка: {Name} , возраст: {Age}, {AnimalSound()}");
        }
    }

    class Dog : Animal
    {
        public Dog(string name, int age) : base(name, age) { }

        public string Breed { get; set; }
        public bool IsTrained { get; protected internal set; }
        
        protected override string AnimalSound()
        {
            return "WOOF WOOF";
        }

        public new void AnimalInfo()
        {
            Console.WriteLine($"Кличка: {Name} , возраст: {Age}, порода: {Breed}, тренерована: {IsTrained}," +
                              $" {AnimalSound()}");
        } 
        
    }

    class Cow : Animal
    {
        public Cow(string name, int age) : base(name, age) { }

        public int MilkADay { get; set; }
        
        protected override string AnimalSound()
        {
            return "MOO MOO";
        }
        
        public new void AnimalInfo()
        {
            Console.WriteLine($"Кличка: {Name} , возраст: {Age}, молоко в день: {MilkADay}, {AnimalSound()}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var cow = new Cow("Dazy", 2);
            var dog = new Dog("Barboss", 1);

            Console.Write("Dog's breed is ");
            dog.Breed = Console.ReadLine();

            Console.WriteLine("Is it trained? 1 - True / else - False");
            string input = Console.ReadLine();
            dog.IsTrained = input == "1";

            Console.Write("Cow's milk a day = ");
            cow.MilkADay = int.Parse(Console.ReadLine());
            
            dog.AnimalInfo();
            cow.AnimalInfo();
        }
    }
}
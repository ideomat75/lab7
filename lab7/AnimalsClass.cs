using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsLib
{

    public abstract class Animal
    {
        public string Country { get; }
        public bool HideFromOtherAnimals { get; }
        public string Name { get; }
        public string WhatAnimal { get; }
        public eClassificationAnimal classification;

        public Animal(string _country, bool _hideOrNo, string _name, string _what, eClassificationAnimal classif)
        {
            Country = _country;
            HideFromOtherAnimals = _hideOrNo;
            Name = _name;
            WhatAnimal = _what;
            classification = classif;
        }

        public void Deconstruct()
        {

        }

        public eClassificationAnimal GetClassificationAnimal()
        {
            return classification;
        }

        public virtual void GetFavoriteFood()
        {
            Console.WriteLine("Food");
        }

        public virtual void SayHello()
        {
            Console.WriteLine("Animal Say Hello");
        }
    }

    [Comment("Cow is not a lion, you know?")]
    public class Cow : Animal
    {
        public Cow(string _country, bool _hideOrNo, string _name, string _whatAnimal, eClassificationAnimal classif) : base(_country, _hideOrNo, _name, _whatAnimal, classif) { }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavoriteFood.Plants);
        }
        public override void SayHello()
        {
            Console.WriteLine("Moooooo!");
        }

    }

    [Comment("Lion is a king of animal!")]
    public class Lion : Animal
    {
        public Lion(string _country, bool _hideOrNo, string _name, string _whatAnimal, eClassificationAnimal classif) : base(_country, _hideOrNo, _name, _whatAnimal, classif) { }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavoriteFood.Meat);
        }
        public override void SayHello()
        {
            Console.WriteLine("Rrrrrrrrr!");
        }

    }

    [Comment("It is Peppa Pig, you know?")]
    public class Pig : Animal
    {
        public Pig(string _country, bool _hideOrNo, string _name, string _whatAnimal, eClassificationAnimal classif) : base(_country, _hideOrNo, _name, _whatAnimal, classif) { }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavoriteFood.Everything);
        }
        public override void SayHello()
        {
            Console.WriteLine("Hru Hru!");
        }

    }
    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomashnoKursovProekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> weapons = new List<Item>();
            List<Item> armors = new List<Item>();
            List<Hero> heroes = new List<Hero>();

            weapons.Add(new Item("sword", 9, 0));
            weapons.Add(new Item("bow", 2, 0));
            weapons.Add(new Item("spear", 9, 3));
            weapons.Add(new Item("claymore", 5, 4));
            weapons.Add(new Item("magicbook", 3, 5));

            armors.Add(new Item("helmet", 0, 8));//0
            armors.Add(new Item("chestplate", 7, 10));//1
            armors.Add(new Item("leggings", 0, 5));//2
            armors.Add(new Item("boots", 2, 3));//3

            heroes.Add(new("Xiao", Fraction.Knight));
            heroes[0].LevelUp();
            heroes[0].LevelUp();
            heroes[0].LevelUp();
            heroes[0].LevelUp();

            heroes[0].ItemSet.Add(weapons[0]);
            string[] unwantedArmor = new string[] { "boots", "leggings" };
            heroes[0].ItemSet.AddRange(armors.Where(x => !unwantedArmor.Contains(x.Name)));

            heroes.Add(new("Ganyu", Fraction.Rogue));
            heroes[1].Fraction = Fraction.Ranged;
            heroes[1].LevelUp();
            heroes[1].LevelUp();

            heroes[1].ItemSet.Add(weapons[1]);
            heroes[1].ItemSet.AddRange(armors);

            int[] upgradeAttacks = { 14, 14, 14, 67, 14 };
            int[] upgradeDefense = { 35, 35, 55, 35 };
            for (int i = 0; i < upgradeAttacks.Length; i++)
            {
                weapons[i].UpgradeAttack(upgradeAttacks[i]);
            }

            for (int i = 0; i < upgradeDefense.Length; i++)
            {
                armors[i].UpgradeDefence(upgradeDefense[i]);
            }
            int counter = 0;
            foreach (Item item in weapons)
            {
                Console.WriteLine($"Weapon N {++counter}:\n{item}");
            }
            counter = 0;
            foreach (Item item in armors)
            {
                Console.WriteLine($"Armor N {++counter}:\n{item.ToString()}");
            }

            Console.WriteLine(new String('=', 30));
            Console.WriteLine("Heroes:");
            counter = 0;
            foreach (Hero hero in heroes)
            {
                Console.WriteLine($"\tPlayer N{++counter}\n{hero.ToString()}");
            }

            Console.WriteLine(new String('=',50));


            foreach (var hero in heroes.OrderByDescending(x => x.Name))
            {
                Console.WriteLine($"{hero.Name}\n with defense {hero.GetDeffence()}\n with attack {hero.GetAttack()}");
                Console.WriteLine("<" + new String('=', 6) + "Items" + new String('=', 6) + ">");
                foreach (var item in hero.ItemSet.OrderByDescending(x => x.Defence))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
    class Hero
    {
        private double attackCoef = 15;
        private double defenceCoef = 20;

        public string Name { get; set; }
        public Fraction Fraction { get; set; }
        public int Level { get; private set; }
        public double Health { get; private set; }
        public double Stamina { get; private set; }
        public double Mana { get; private set; }
        public List<Item> ItemSet { get; }
        public Hero(string Name, Fraction fraction)
        {
            Level = 0;
            Health = 100;
            Stamina = 100;
            Mana = 100;
            ItemSet = new List<Item>();
            this.Name = Name;
            Fraction = fraction;
        }

        public double LevelUp()
        {
            Level += 1;
            Health = 100;
            Stamina = 100;
            Mana = 100;
            return Level;

        }
        public double GetAttack()
        {
            double getAttack = ItemSet.Sum(i => i.Attack);
            getAttack += Level * attackCoef;
            return getAttack;
        }

        public double GetDeffence()
        {
            double result = ItemSet.Sum(i => i.Defence) + Level * defenceCoef;
            return result;
        }

        //Аналогично на горното съкратен метод когато  е прост и става на един ред може да се напише и с ламбда стрелка (пример давам просто)
        public double GetDef() =>
            ItemSet.Sum(i => i.Defence) + Level * defenceCoef;


        public override string ToString()
        {
            string format = "Level: {0},\nHero name: {1},\nHealth: {2},\nMana: {3},\nStamina: {4},\nFraction: {5},\nDamage: {6},\nDefence: {7}\n";
            string result = string.Format(format, Level, Name, Health, Mana, Stamina, Fraction, GetAttack(), GetDeffence());
            return result;
        }
    }
    class Item
    {
        public string Name { get; private set; }
        public double Attack { get; private set; }
        public double Defence { get; private set; }
        public Item(string name, double atk, double def)
        {
            Name = name;
            Attack = atk;
            Defence = def;
            if (atk < 0 || atk > 10 || def < 0 || def > 10)
            {
                Console.WriteLine("Invalid Attack / Defence item value");
            }
        }

        public void UpgradeAttack(double atk)
        {
            if (atk > 50 || atk < 0)
            {
                Console.WriteLine("Invalid Attack improvement value.");
                return;
            }
            Attack += atk;
        }

        public void UpgradeDefence(double def)
        {
            Defence += def;
            if (def < 0 || def > 50)
            {
                Console.WriteLine("Invalid Defence improvement value.");
            }
        }

        public override string ToString() => $"{Name} \n  Attack: {Attack}\n  Defence: {Defence}";

        //Тука има малко проблем ако дадем лоша стойност на атаката/дефенса ние ще изпишем съобщение ама
        //реално ще я променим стойността а идеята е ако не е добра стойността това да не става. 
    }
    enum Fraction
    {
        Mage,
        Knight,
        Priest,
        Ranged,
        Rogue
    }
}


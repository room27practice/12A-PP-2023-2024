//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace marin
//{
//    public static class Program
//    {
//        static void Main(string[] args)
//        {
//            Hero HuTao = new Hero("Hu Tao", Fraction.Rogue);
//            Item StaffOfHoma = new Item("StaffOfHoma", 9, 4);
//            HuTao.LevelUp();
//            Item CWOF = new Item("Crimson Witch of Flame", 7, 6);
//            HuTao.ItemSet.Add(CWOF);
//            HuTao.ItemSet.Add(StaffOfHoma);
//            HuTao.LevelUp();
//            CWOF.UpgradeAttack(40);
//            StaffOfHoma.UpgradeAttack(30);
//            HuTao.LevelUp();

//            Hero Zhongli = new Hero("Zhongli", Fraction.Rogue);
//            Item VortexVanquisher = new Item("Vortex Vanquisher", 5, 3);
//            Zhongli.LevelUp();
//            Item TOTM = new Item("Tenacity of the Millelith", 8, 9);
//            Zhongli.ItemSet.Add(VortexVanquisher);
//            Zhongli.ItemSet.Add(TOTM);
//            Zhongli.LevelUp();
//            VortexVanquisher.UpgradeAttack(21);
//            TOTM.UpgradeAttack(48);
//            Zhongli.LevelUp();


//            Console.WriteLine("-----------------Statistics-----------------");
//            Console.WriteLine(HuTao.Name + " have " + HuTao.GetAttack() + " Attack and " + HuTao.GetDefence() + " Defence");
//            Console.WriteLine(Zhongli.Name + " have " + Zhongli.GetAttack() + " Attack and " + Zhongli.GetDefence() + " Defence");
//        }
//    }



//    public enum Fraction
//    {
//        Mage,
//        Knight,
//        Priest,
//        Ranged,
//        Rogue,
//    }

//    public class Hero
//    {
//        private double attackCoef = 15;

//        private double defenceCoef = 20;

//        public Hero(string name, Fraction fraction)
//        {
//            this.Name = name;
//            this.Fraction = fraction;
//            this.Level = 0;
//            this.Health = 100;
//            this.Stamina = 100;
//            this.Mana = 100;
//            this.ItemSet = new List<Item>();
//        }

//        public string Name { get; private set; }

//        public Fraction Fraction { get; set; }

//        public int Level { get; private set; }

//        public double Health { get; private set; }

//        public double Stamina { get; private set; }

//        public double Mana { get; private set; }

//        public List<Item> ItemSet { get; }

//        public int LevelUp()
//        {
//            this.Level++;
//            this.Health = 100;
//            this.Stamina = 100;
//            this.Mana = 100;
//            return this.Level;
//        }
//        public double GetAttack()
//        {
//            double getAttack = this.ItemSet.Sum(i => i.Attack);
//            getAttack += this.Level * this.attackCoef;
//            return getAttack;
//        }
//        public double GetDefence()
//        {
//            double getDefence = this.ItemSet.Sum(i => i.Defence);
//            getDefence += this.Level * this.defenceCoef;
//            return getDefence;
//        }
//    }


//    public class Item
//    {
//        public Item(string name, double atk, double def)
//        {
//            if (atk > 10 || atk < 0)
//                throw new Exception("Invalid Attack");
//            else if (def > 10 || def < 0)
//                throw new Exception("Invalid Defence");
//            else
//            {
//                Name = name;
//                Attack = atk;
//                Defence = def;
//            }
//        }

//        public string Name { get; private set; }

//        public double Attack { get; private set; }

//        public double Defence { get; private set; }

//        public void UpgradeAttack(double atk)
//        {
//            if (atk < 0 || atk > 50)
//                throw new Exception("Invalid Attack improvement value");
//            else
//                this.Attack += atk;
//        }
//        public void UpgradeDefence(double def)
//        {
//            if (def < 0 || def > 50)
//                throw new Exception("Invalid Defence improvement value");
//            else
//                this.Defence += def;
//        }
//    }
//}
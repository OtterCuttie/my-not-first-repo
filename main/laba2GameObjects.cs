using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public abstract class GameObject
    {
        protected int Id;
        protected string Name;
        protected int X;
        protected int Y;

        public GameObject(int id, string name, int x, int y)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
        }

        public int getId()
        {
            return Id;
        }

        public string getName()
        {
            return Name;
        }

        public int getX()
        {
            return X;
        }

        public int getY()
        {
            return Y;
        }
    }
    public abstract class Building : GameObject
    {
        protected bool Built;

        public Building(int id, string name, int x, int y, bool built): base(id, name, x, y)
        {
            Built = built;
        }

        public bool IsBuilt()
        {
            return Built;
        }
    }
    public abstract class Unit : GameObject
    {
        private float Hp;

        public Unit(int id, string name, int x, int y, float hp) : base(id, name, x, y)
        {
            Hp = hp;
        }

        public bool IsAlive()
        {
            return Hp > 0;
        }

        public float GetHp()
        {
            return Hp;
        }

        public void ReceiveDamage(float damage)
        {
            if (damage > 0)
            {
                Hp -= damage;

                if (Hp < 0)
                    Hp = 0;
            }
        }
    }
    public class Fort : Building, IAttacker
    {
        private float Damage;

        public Fort(int id, string name, int x, int y,bool built, float damage): base(id, name, x, y, built)
        {
            Damage = damage;
        }

        public void Attack(Unit unit)
        {
            if (IsBuilt() && unit != null && unit.IsAlive())
            {
                unit.ReceiveDamage(Damage);
            }
        }
    }
    public class MobileHome : Building, IMoveable
    {
        public MobileHome(int id, string name, int x, int y, bool built): base(id, name, x, y, built)
        {
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Archer : Unit, IAttacker, IMoveable
    {
        private float Damage;

        public Archer(int id, string name, int x, int y,float hp, float damage): base(id, name, x, y, hp)
        {
            Damage = damage;
        }

        public void Attack(Unit unit)
        {
            if (IsAlive() && unit != null && unit.IsAlive())
            {
                unit.ReceiveDamage(Damage);
            }
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}


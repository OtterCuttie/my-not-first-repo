using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public abstract class GameObject
    {
        private int _id;
        public int Id { get => _id; private set => _id = value; }

        private string _name;
        public string Name { get => _name; private set => _name = value; }

        private int _x;
        public int X { get => _x; protected set => _x = value; }

        private int _y;
        public int Y { get => _y; protected set => _y = value; }

        public GameObject(int id, string name, int x, int y)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
        }

        public int getId() => Id;
        public string getName() => Name;
        public int getX() => X;
        public int getY() => Y;
    }

    public abstract class Building : GameObject
    {
        private bool _built;
        public bool Built { get => _built; protected set => _built = value; }

        public Building(int id, string name, int x, int y, bool built): base(id, name, x, y)
        {
            Built = built;
        }
        
        public bool IsBuilt() => Built;
    }

    public abstract class Unit : GameObject
    {
        private float _hp;
        public float Hp { get => _hp; private set => _hp = value; }

        public Unit(int id, string name, int x, int y, float hp): base(id, name, x, y)
        {
            Hp = hp;
        }

        public bool IsAlive() => Hp > 0;

        public float GetHp() => Hp;

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
        private float _damage;
        public float Damage { get => _damage; private set => _damage = value; }

        public Fort(int id, string name, int x, int y, bool built, float damage): base(id, name, x, y, built)
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
        private float _damage;
        public float Damage { get => _damage; private set => _damage = value; }

        public Archer(int id, string name, int x, int y, float hp, float damage): base(id, name, x, y, hp)
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


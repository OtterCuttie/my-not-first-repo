using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public abstract class GameObject
    {
        protected int _id;
        protected string _name;
        protected int _x;
        protected int _y;

        public GameObject(int id, string name, int x, int y)
        {
            _id = id;
            _name = name;
            _x = x;
            _y = y;
        }

        public int getId()
        {
            return _id;
        }

        public string getName()
        {
            return _name;
        }

        public int getX()
        {
            return _x;
        }

        public int getY()
        {
            return _y;
        }
    }
    public abstract class Building : GameObject
    {
        protected bool _built;

        public Building(int id, string name, int x, int y, bool built): base(id, name, x, y)
        {
            _built = built;
        }

        public bool IsBuilt()
        {
            return _built;
        }
    }
    public abstract class Unit : GameObject
    {
        private float _hp;

        public Unit(int id, string name, int x, int y, float hp) : base(id, name, x, y)
        {
            _hp = hp;
        }

        public bool IsAlive()
        {
            return _hp > 0;
        }

        public float GetHp()
        {
            return _hp;
        }

        public void ReceiveDamage(float damage)
        {
            if (damage > 0)
            {
                _hp -= damage;

                if (_hp < 0)
                    Hp = 0;
            }
        }
    }
    public class Fort : Building, IAttacker
    {
        private float _damage;

        public float Damage
        {
            get { return _damage; }
            private set { _damage = value; }
        }

        public Fort(int id, string name, int x, int y,bool built, float damage): base(id, name, x, y, built)
        {
            _damage = damage;
        }

        public void Attack(Unit unit)
        {
            if (IsBuilt() && unit != null && unit.IsAlive())
            {
                unit.ReceiveDamage(_damage);
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
            _x = x;
            _y = y;
        }
    }
    public class Archer : Unit, IAttacker, IMoveable
    {
        private float _damage;

        public Archer(int id, string name, int x, int y,float hp, float damage): base(id, name, x, y, hp)
        {
            _damage = damage;
        }

        public void Attack(Unit unit)
        {
            if (IsAlive() && unit != null && unit.IsAlive())
            {
                unit.ReceiveDamage(_damage);
            }
        }

        public void Move(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}


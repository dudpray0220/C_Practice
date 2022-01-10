using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern03
{
    class Program
    {
        static void Main(string[] args)
        {
            Building[] Buildings = new Building[2]; // Buildin타입의 배열생성

            // 객체 생성
            Buildings[0] = new Barracks();
            Buildings[1] = new StarPort();

            List<Unit> AllUnit = new List<Unit>(); // Unit타입의 리스트 생성
            // makeUnit 메서드로 Unit생성 후 리스트에 추가
            AllUnit.Add(Buildings[0].makeUnit("Enemy 마린"));
            AllUnit.Add(Buildings[1].makeUnit("드랍쉽"));

            AllUnit[0].Move("언덕");
            Unit unitMarine = AllUnit[0];
            AllUnit[1].Attacked(ref unitMarine);

            Console.ReadLine();
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // FactoryMethodPattern Class 
    public abstract class Unit // Product에 해당
    {
        public string m_strName;
        public int m_intAttackPower;
        public int m_intHealth;

        public abstract void Move(string _strPoint); // 이동 추상화 메서드
        public abstract void Attacked(ref Unit _unitTarget); // 공격당함 추상화 메서드 (대상은 Unit 클래스를 참조시켰다)
    }
    public class Marine : Unit // ConcreteProduct A에 해당
    {
        public Marine(string _strName) // 생성자
        {
            this.m_strName = _strName;
            this.m_intAttackPower = 15;
            this.m_intHealth = 100;
            Console.WriteLine(_strName + " : 생성완료");
        }
        public override void Move(string _strPoint)
        {
            Console.WriteLine(m_strName + " : " + _strPoint + " 이동 완료!");
        }
        public override void Attacked(ref Unit _unitTarget)
        {
            this.m_intHealth -= _unitTarget.m_intAttackPower;
            Console.WriteLine(m_strName + "공격당함!!   공격자 : " + _unitTarget.m_strName + "!!   " + m_strName + " 남은체력 : " + this.m_intHealth.ToString());
        }
    }
    public class Dropship : Unit // ConcreteProduct B에 해당
    {
        public Dropship(string _strName) //  생성자
        {
            this.m_strName = _strName;
            this.m_intAttackPower = 0;
            this.m_intHealth = 200;
            Console.WriteLine(_strName + " : 생성완료");
        }
        public override void Move(string _strPoint)
        {
            Console.WriteLine(m_strName + " : " + _strPoint + " 이동 완료!");
        }
        public override void Attacked(ref Unit _unitTarget)
        {
            this.m_intHealth -= _unitTarget.m_intAttackPower;
            Console.WriteLine(m_strName + "공격당함!!   공격자 : " + _unitTarget.m_strName + "!!   " + m_strName + " 남은체력 : " + this.m_intHealth.ToString());
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    public abstract class Building // Creator에 해당
    {
        public abstract Unit makeUnit(string _strName); // return type이 Unit인 메서드. Unit을 생성한다!
    }
    public class Barracks : Building // ConcreteCreatorA에 해당
    {
        public override Unit makeUnit(string _strName)
        {
            return new Marine(_strName);
        }
    }
    public class StarPort : Building // // ConcreteCreatorB에 해당
    {
        public override Unit makeUnit(string _strName)
        {
            return new Dropship(_strName);
        }
    }
}

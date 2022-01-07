using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInLOL
{
    abstract class BaseCharacter
    {
        public virtual void Attack() // virtual로 한 이유 : 기본 공격동작에 다른 동작을 추가하고 싶다면 override 하면 됨!
        {
            // 공격한다.
        }
        public void Stop() // 멈추는 동작은 다 같다.
        {
            // 멈춘다.
        }
        public abstract void Skill_Q();
        public abstract void Skill_W();
        public abstract void Skill_E();
        public abstract void Skill_R();
    }
}

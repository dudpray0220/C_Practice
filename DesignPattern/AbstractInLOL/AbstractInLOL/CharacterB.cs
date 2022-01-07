using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInLOL
{
    class CharacterB : BaseCharacter
    {
        public override void Attack()
        {
            base.Attack(); // 이건 BaseCharacter의 Attack. 만일 다른 동작하고싶으면 삭제하면 됨!
        }
        public override void Skill_Q()
        {
            // 스킬
        }
        public override void Skill_W()
        {
            // 스킬
        }
        public override void Skill_E()
        {
            // 스킬
        }
        public override void Skill_R()
        {
            // 스킬
        }
    }
}

using Interface;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "PlayerSkillData", menuName = "ScriptableObj/PlayerSkillData", order = 0)]
    public class PlayerSkillData : ScriptableObject
    {
        [Header("Dash")] 
        public float DashSkillDuration;
        public float DashSkillCooldown;

        [Header("Invisible")] 
        public float InvisibleSkillDuration;
        public float InvisibleSkillCooldown;
    }

    public class DashSkill : ISkill
    {
        public float CoolDown { get; set; }
        public float Duration { get; set; }
    }

    public class InvisibleSkill : ISkill
    {
        public float CoolDown { get; set; }
        public float Duration { get; set; }
    }
}
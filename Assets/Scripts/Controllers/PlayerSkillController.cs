using System.Collections;
using Data.UnityObject;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerSkillController : MonoBehaviour
    {
        [SerializeField] private GameObject meshModel;
        
        [Header("Invis Particles")]
        [SerializeField] private ParticleSystem invisStartParticle;
        [SerializeField] private ParticleSystem duringInvisParticle;
        [SerializeField] private ParticleSystem invisEndParticle;
        
        [Header("Dash Particles")]
        [SerializeField] private ParticleSystem dashParticle;
        
        private PlayerSkillData _playerSkillData;
        
        private void Awake()
        {
            _playerSkillData = Resources.Load<PlayerSkillData>("Data/PlayerSkillData");
        }
        


        private IEnumerator InvisibleSkillCooldown()
        {
            while (_playerSkillData.InvisibleSkillCooldown > 0)
            {
                
                yield return new WaitForEndOfFrame();
            }
        }
        
        public void OnDashSkillUsed()
        {
            /*
            Model one 25* egilecek.
            Hızlı sekilde 5m ileriye atılacak. run speed * 2 mb? or .2 || .4 sec
            movement duration particle (like wind)
            Model normal açısına gelecek.
            */
        }
    }
}
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
        private Coroutine _invisibleSkillTimer;
        private Coroutine _dashSkillTimer;
        
        private void Awake()
        {
            _playerSkillData = Resources.Load<PlayerSkillData>("Data/PlayerSkillData");
        }
        
        public void OnInvisibleSkillUsed()
        {
            // invisStartParticle.Play();
            meshModel.SetActive(false);
            // invisEndParticle.Play();
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
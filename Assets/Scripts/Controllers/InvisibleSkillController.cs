using System.Collections;
using Data.UnityObject;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class InvisibleSkillController : MonoBehaviour
    {
        [SerializeField] private GameObject meshModel;
        
        [Header("Invis Particles")]
        [SerializeField] private ParticleSystem invisStartParticle;
        [SerializeField] private ParticleSystem duringInvisParticle;
        [SerializeField] private ParticleSystem invisEndParticle;

        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI cooldownText;
        
        private PlayerSkillData _playerSkillData;

        private bool _isCooldown;
        private float _cooldownTime;
        private float _cooldownTimer;
        private float _skillDuration;
        
        private void Awake()
        {
            _playerSkillData = Resources.Load<PlayerSkillData>("Data/PlayerSkillData");
            _cooldownTime = _playerSkillData.InvisibleSkillCooldown;
            _skillDuration = _playerSkillData.InvisibleSkillDuration;
        }

        private void Start()
        {
            cooldownText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_isCooldown)
                ApplyCooldown();
        }

        private void ApplyCooldown()
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer < 0)
            {
                _isCooldown = false;
                cooldownText.gameObject.SetActive(false);
            }
            else
            {
                cooldownText.text = Mathf.RoundToInt(_cooldownTimer).ToString();
            }
        }
        
        public void UseSpell()
        {
            if (_isCooldown)
                return;
            StartCoroutine(InvisibleSkill());
        }

        private IEnumerator InvisibleSkill()
        {
            while (_playerSkillData.InvisibleSkillCooldown <= 0)
            {
                cooldownText.gameObject.SetActive(true);
                meshModel.SetActive(false);
                invisStartParticle.Play();
                yield return new WaitForSeconds(_skillDuration);
                meshModel.SetActive(true);
                invisEndParticle.Play();
                _isCooldown = true;
                _cooldownTimer = _cooldownTime;
            }
        }
        
    }
}
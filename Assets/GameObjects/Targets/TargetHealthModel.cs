using System;
using UnityEngine;

namespace GameObjects.Targets
{
    public class TargetHealthModel : MonoBehaviour
    {
        [SerializeField]
        private float maxHealth = 100;
        public float MaxHealth => maxHealth;
        
        public event Action<float, float> OnHealthChanged;

        private float _health;

        public void Reset()
        {
            _health = maxHealth;
        }

        public float Health
        {
            get => _health;
            set
            {
                OnHealthChanged?.Invoke(_health, value);
                _health = value;
            }
        }

        private void OnDestroy()
        {
            OnHealthChanged = null;
        }
    }
}

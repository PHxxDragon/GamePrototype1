using Sisus.Init;
using UnityEngine;
using UnityEngine.UI;

namespace GameObjects.Targets
{
    public class TargetHealthView : MonoBehaviour<TargetHealthModel>
    {
        [SerializeField]
        private Slider healthSlider;
        
        private TargetHealthModel _targetHealthModel;
        protected override void Init(TargetHealthModel targetHealthModel)
        {
            _targetHealthModel = targetHealthModel;
            _targetHealthModel.OnHealthChanged += TargetHealthModelOnOnHealthChanged;
        }

        private void TargetHealthModelOnOnHealthChanged(float oldValue, float newValue)
        {
            healthSlider.value = newValue / _targetHealthModel.MaxHealth;
        }

        private void OnDestroy()
        {
            _targetHealthModel.OnHealthChanged -= TargetHealthModelOnOnHealthChanged;
        }
    }
}

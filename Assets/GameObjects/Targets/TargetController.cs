using System;
using GameModels;
using Sisus.Init;

namespace GameObjects.Targets
{
    public class TargetController : MonoBehaviour<TargetControllerList, TargetHealthModel>
    {
        protected override void Init(TargetControllerList targetControllerList, TargetHealthModel targetHealthModel)
        {
            _targetControllerList = targetControllerList;
            _targetHealthModel = targetHealthModel;
        }
        
        private TargetControllerList _targetControllerList;
        private TargetHealthModel _targetHealthModel;

        private void Start()
        {
            _targetHealthModel.Reset();
        }

        private void OnDestroy()
        {
            _targetControllerList.TargetComponents.Remove(this);
        }

        public void TakeDamage(float damage)
        {
            _targetHealthModel.Health -= damage;
            if (_targetHealthModel.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

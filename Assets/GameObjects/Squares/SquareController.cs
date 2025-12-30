using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameModels;
using GameObjects.Targets;
using Sisus.Init;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameObjects.Squares
{
    public class SquareController : MonoBehaviour<SquareControllerList, TargetControllerList, ScoreModel, SquareFactory>
    {
        [SerializeField] private float remainHealth = 10f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject scoreCircle;
        
        protected override void Init(SquareControllerList squareControllerList, TargetControllerList targetControllerList, ScoreModel scoreModel, SquareFactory squareFactory)
        {
            _squareControllerList = squareControllerList;
            _targetControllerList = targetControllerList;
            _scoreModel = scoreModel;
            _squareFactory = squareFactory;
        }

        private SquareControllerList _squareControllerList;
        private TargetControllerList _targetControllerList;
        private ScoreModel _scoreModel;
        private TargetController _currentTarget;
        private SquareFactory _squareFactory;
        
        private int _remainScoreToHaveChild = Constants.Constants.SquareSpawner.ScoreToHaveChild;
        private float _currentStopTime = Constants.Constants.SquareSpawner.StopTime;

        private static TargetController SelectTarget(List<TargetController> targets)
        {
            if (targets.Count <= 0) return null;
            var random = Random.Range(0, targets.Count);
            return targets[random];
        }

        private void Update()
        {
            if (!_currentTarget) _currentTarget = SelectTarget(_targetControllerList.TargetComponents);

            var currentDistance = _currentTarget ? Vector3.Distance(transform.position, _currentTarget.transform.position) : float.MaxValue;
            if (Mathf.Abs(currentDistance) < Constants.Constants.SquareSpawner.StopRadius)
            {
                if (remainHealth <= 10f)
                {
                    remainHealth += Time.deltaTime;
                    _currentTarget.TakeDamage(Time.deltaTime * 10f);
                }
                
                if (remainHealth >= 3f)
                {
                    spriteRenderer.color = new Color(0.26f, 0.7f, 0.33f);
                }
                
                _currentStopTime -= Time.deltaTime;
                if (_currentStopTime <= 0f)
                {
                    _currentTarget = SelectTarget(_targetControllerList.TargetComponents);
                    _scoreModel.AddScore(1);
                    _ = ShowCoin();
                    _currentStopTime = Constants.Constants.SquareSpawner.StopTime;
                    _remainScoreToHaveChild--;

                    if (_remainScoreToHaveChild <= 0)
                    {
                        _remainScoreToHaveChild =  Constants.Constants.SquareSpawner.ScoreToHaveChild;
                        var child = _squareFactory.CreateSquareChild(transform.position);
                        child.SetParent(this);
                    }
                }
            }
            else
            {
                if (_currentTarget) transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, Constants.Constants.SquareSpawner.MoveSpeed * Time.deltaTime);
                remainHealth -= Time.deltaTime;
                
                if (remainHealth <= 3f)
                {
                    spriteRenderer.color = Color.darkGoldenRod;
                } 
                
                if (remainHealth <= 0f)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            _squareControllerList.SquareComponents.Remove(this);
        }

        private async UniTaskVoid ShowCoin()
        {
            scoreCircle.SetActive(true);
            await UniTask.WaitForSeconds(0.4f);
            if (scoreCircle) scoreCircle.SetActive(false);
        }
    }
}

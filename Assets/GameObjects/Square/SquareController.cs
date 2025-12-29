using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameManagers;
using GameObjects.SquareChild;
using GameObjects.Target;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameObjects.Square
{
    public class SquareController: ITickable
    {
        [Inject]
        public SquareController(
            GameManager gameManager,
            GameUI gameUI,
            [Key(InjectKeys.RemainHealth)] float remainHealth,
            SpriteRenderer spriteRenderer,
            [Key(InjectKeys.ScoreCircle)] GameObject scoreCircle,
            SquareChildFactory squareChildFactory,
            SquareView squareView
        )
        {
            _gameManager = gameManager;
            _gameUI = gameUI;
            _remainHealth = remainHealth;
            _spriteRenderer = spriteRenderer;
            _scoreCircle = scoreCircle;
            _squareChildFactory = squareChildFactory;
            _squareView = squareView;
            
        }
        
        private readonly GameManager _gameManager;
        private readonly GameUI _gameUI;
        private float _remainHealth;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly GameObject _scoreCircle;
        private readonly SquareView _squareView;
        private readonly SquareChildFactory _squareChildFactory;
        
        private int _remainScoreToHaveChild = Constants.Constants.SquareSpawner.ScoreToHaveChild;

        private TargetController _currentTarget;
        private float _currentStopTime = Constants.Constants.SquareSpawner.StopTime;

        private TargetController SelectTarget(List<TargetController> targets)
        {
            if (targets.Count <= 0) return null;
            var random = Random.Range(0, targets.Count);
            return targets[random];
        }

        public void Tick()
        {
            if (!_currentTarget)
            {
                _currentTarget = SelectTarget(_gameManager.TargetComponents);
            } 
            else
            {
                var currentDistance = Vector3.Distance(_squareView.transform.position, _currentTarget.transform.position);
                if (Mathf.Abs(currentDistance) < Constants.Constants.SquareSpawner.StopRadius)
                {
                    _currentStopTime -= Time.deltaTime;
                    if (_currentStopTime <= 0f)
                    {
                        _currentTarget = SelectTarget(_gameManager.TargetComponents);
                        _currentStopTime = Constants.Constants.SquareSpawner.StopTime;
                        _gameUI.AddScore(1);
                        _ = ShowCoin();
                        _remainScoreToHaveChild--;

                        if (_remainScoreToHaveChild <= 0)
                        {
                            _remainScoreToHaveChild =  Constants.Constants.SquareSpawner.ScoreToHaveChild;
                            var squareChildView = _squareChildFactory.CreateSquareChild(_squareView.transform.position);
                            squareChildView.SquareChildController.SetParent(_squareView);
                        }
                    }

                    if (_remainHealth <= 10f)
                    {
                        _remainHealth += Time.deltaTime;
                    }

                    if (_remainHealth >= 3f)
                    {
                        _spriteRenderer.color = new Color(0.26f, 0.7f, 0.33f);
                    }
                }
                else
                {
                    _squareView.transform.position = Vector3.MoveTowards(_squareView.transform.position, _currentTarget.transform.position, Constants.Constants.SquareSpawner.MoveSpeed * Time.deltaTime);
                    _remainHealth -= Time.deltaTime;
                    
                    if (_remainHealth <= 3f)
                    {
                        _spriteRenderer.color = Color.darkGoldenRod;
                    } 
                    
                    if (_remainHealth <= 0f)
                    {
                        Object.Destroy(_squareView.gameObject);
                    }
                }
            }
        }

        private async UniTaskVoid ShowCoin()
        {
            _scoreCircle.SetActive(true);
            await UniTask.WaitForSeconds(0.4f);
            _scoreCircle.SetActive(false);
        }
    }
}

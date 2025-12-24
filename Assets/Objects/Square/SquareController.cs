using System.Collections.Generic;
using Objects.Target;
using UI;
using UnityEngine;

namespace Objects.Square
{
    public class SquareController : MonoBehaviour
    {
        [SerializeField] private GameManager.GameManager gameManager;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private float remainHealth = 10f;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetGameManager(GameManager.GameManager gm)
        {
            gameManager = gm;
        }

        public void SetGameUI(GameUI ui)
        {
            gameUI = ui;
        }

        private TargetController _currentTarget;
        private float _currentStopTime = Constants.Constants.SquareSpawner.StopTime;

        private TargetController SelectTarget(List<TargetController> targets)
        {
            if (targets.Count <= 0) return null;
            var random = Random.Range(0, targets.Count);
            return targets[random];
        }

        private void Update()
        {
            if (!_currentTarget)
            {
                _currentTarget = SelectTarget(gameManager.TargetComponents);
            } 
            else
            {
                var currentDistance = Vector3.Distance(transform.position, _currentTarget.transform.position);
                if (Mathf.Abs(currentDistance) < Constants.Constants.SquareSpawner.StopRadius)
                {
                    _currentStopTime -= Time.deltaTime;
                    if (_currentStopTime <= 0f)
                    {
                        _currentTarget = SelectTarget(gameManager.TargetComponents);
                        _currentStopTime = Constants.Constants.SquareSpawner.StopTime;
                        gameUI.AddScore(1);
                    }

                    if (remainHealth <= 10f)
                    {
                        remainHealth += Time.deltaTime;
                    }

                    if (remainHealth >= 3f)
                    {
                        spriteRenderer.color = new Color(0.26f, 0.7f, 0.33f);
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, Constants.Constants.SquareSpawner.MoveSpeed * Time.deltaTime);
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
        }
    }
}

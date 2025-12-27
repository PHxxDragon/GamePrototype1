using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameManagers;
using GameObjects.SquareChild;
using GameObjects.Target;
using Sisus.Init;
using UI;
using UnityEngine;

namespace GameObjects.Square
{
    public class SquareController : MonoBehaviour<GameManager, GameUI>
    {
        [SerializeField] private float remainHealth = 10f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject scoreCircle;
        [SerializeField] private SquareChildController childPrefab;

        private int remainScoreToHaveChild = Constants.Constants.SquareSpawner.ScoreToHaveChild;
        
        protected override void Init(GameManager firstArgument, GameUI secondArgument)
        {
            gameManager = firstArgument;
            gameUI = secondArgument;
        }
        
        private GameManager gameManager;
        private GameUI gameUI;

        private TargetController currentTarget;
        private float currentStopTime = Constants.Constants.SquareSpawner.StopTime;

        private TargetController SelectTarget(List<TargetController> targets)
        {
            if (targets.Count <= 0) return null;
            var random = Random.Range(0, targets.Count);
            return targets[random];
        }

        private void Update()
        {
            if (!currentTarget)
            {
                currentTarget = SelectTarget(gameManager.TargetComponents);
            } 
            else
            {
                var currentDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
                if (Mathf.Abs(currentDistance) < Constants.Constants.SquareSpawner.StopRadius)
                {
                    currentStopTime -= Time.deltaTime;
                    if (currentStopTime <= 0f)
                    {
                        currentTarget = SelectTarget(gameManager.TargetComponents);
                        currentStopTime = Constants.Constants.SquareSpawner.StopTime;
                        gameUI.AddScore(1);
                        _ = ShowCoin();
                        remainScoreToHaveChild--;

                        if (remainScoreToHaveChild <= 0)
                        {
                            remainScoreToHaveChild =  Constants.Constants.SquareSpawner.ScoreToHaveChild;
                            SquareChildController child = Instantiate(childPrefab, transform.position, Quaternion.identity);
                            child.SetParent(this);
                            child.SetGameManager(gameManager);
                            child.SetGameUI(gameUI);
                        }
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
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, Constants.Constants.SquareSpawner.MoveSpeed * Time.deltaTime);
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

        private async UniTaskVoid ShowCoin()
        {
            scoreCircle.SetActive(true);
            await UniTask.WaitForSeconds(0.4f);
            scoreCircle.SetActive(false);
        }
    }
}

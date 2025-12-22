using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SquareController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    private TargetController _currentTarget;
    private float _currentStopTime = Constants.SquareSpawner.StopTime;

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
            if (Mathf.Abs(currentDistance) < Constants.SquareSpawner.StopRadius)
            {
                _currentStopTime -= Time.deltaTime;
                if (_currentStopTime <= 0f)
                {
                    _currentTarget = SelectTarget(gameManager.TargetComponents);
                    _currentStopTime = Constants.SquareSpawner.StopTime;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, Constants.SquareSpawner.MoveSpeed * Time.deltaTime);
            }
        }
    }
}

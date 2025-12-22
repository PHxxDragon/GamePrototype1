using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SquareController : MonoBehaviour
{
    [SerializeField] GameManager GameManager;

    public void SetGameManager(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    TargetController currentTarget;
    float currentStopTime = Constants.SquareSpawner.STOP_TIME;

    TargetController SelectTarget(List<TargetController> targets)
    {
        if (targets.Count > 0)
        {
            int random = Random.Range(0, targets.Count);
            return targets[random];
        }
        return null;
    }

    void Update()
    {
        if (currentTarget == null)
        {
            currentTarget = SelectTarget(GameManager.targetComponents);
        } 
        else
        {
            float currentDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (Mathf.Abs(currentDistance) < Constants.SquareSpawner.STOP_RADIUS)
            {
                currentStopTime -= Time.deltaTime;
                if (currentStopTime <= 0f)
                {
                    currentTarget = SelectTarget(GameManager.targetComponents);
                    currentStopTime = Constants.SquareSpawner.STOP_TIME;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, Constants.SquareSpawner.MOVE_SPEED * Time.deltaTime);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Assertions;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField] 
    GameManager GameManager;

    [SerializeField]
    SquareController SquarePrefab;

    [SerializeField]
    Transform RegionTopLeft;

    [SerializeField]
    Transform RegionBottomRight;

    float remainTime;

    void Start()
    {
        Assert.IsNotNull(SquarePrefab);
        remainTime = Constants.SquareSpawner.SPAWN_TIME;
    }

    void Update()
    {
        remainTime -= Time.deltaTime;
        if (remainTime <= 0f)
        {
            remainTime += Constants.SquareSpawner.SPAWN_TIME;

            Vector3 newPosition = new(Random.Range(RegionTopLeft.position.x, RegionBottomRight.position.x), Random.Range(RegionTopLeft.position.y, RegionBottomRight.position.y), 0);
            SquareController squareController = Instantiate(SquarePrefab, newPosition, Quaternion.identity);
            squareController.SetGameManager(GameManager);
            GameManager.squareComponents.Add(squareController);
        }
    }
}

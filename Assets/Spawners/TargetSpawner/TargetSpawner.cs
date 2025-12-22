using UnityEngine;
using UnityEngine.Assertions;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    GameManager GameManager;

    [SerializeField]
    TargetController TargetPrefab;

    [SerializeField]
    Transform RegionTopLeft;

    [SerializeField]
    Transform RegionBottomRight;

    float remainTime;

    void Start()
    {
        Assert.IsNotNull(TargetPrefab);
        remainTime = Constants.TargetSpawner.SPAWN_TIME;
    }

    void Update()
    {
        remainTime -= Time.deltaTime;
        if (remainTime <= 0f)
        {
            remainTime += Constants.TargetSpawner.SPAWN_TIME;

            Vector3 newPosition = new(Random.Range(RegionTopLeft.position.x, RegionBottomRight.position.x), Random.Range(RegionTopLeft.position.y, RegionBottomRight.position.y), 0);
            TargetController targetController = Instantiate(TargetPrefab, newPosition, Quaternion.identity);
            GameManager.targetComponents.Add(targetController);

        }
    }
}

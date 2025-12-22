using UnityEngine;
using UnityEngine.Assertions;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TargetController targetPrefab;

    [SerializeField] private Transform regionTopLeft;

    [SerializeField] private Transform regionBottomRight;

    private float _remainTime;

    private void Start()
    {
        Assert.IsNotNull(targetPrefab);
        _remainTime = Constants.TargetSpawner.SpawnTime;
    }

    private void Update()
    {
        _remainTime -= Time.deltaTime;
        if (_remainTime <= 0f)
        {
            _remainTime += Constants.TargetSpawner.SpawnTime;

            Vector3 newPosition = new(Random.Range(regionTopLeft.position.x, regionBottomRight.position.x), Random.Range(regionTopLeft.position.y, regionBottomRight.position.y), 0);
            var targetController = Instantiate(targetPrefab, newPosition, Quaternion.identity);
            gameManager.TargetComponents.Add(targetController);

        }
    }
}

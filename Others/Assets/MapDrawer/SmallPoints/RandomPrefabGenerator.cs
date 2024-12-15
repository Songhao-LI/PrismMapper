using UnityEngine;

public class RandomPrefabGenerator : MonoBehaviour
{
    public GameObject prefabToGenerate; // 需要生成的预制体
    public int numberOfPrefabs = 10; // 默认生成的数量
    private Renderer spawnAreaRenderer; // 生成范围的渲染器

    void Start()
    {
        spawnAreaRenderer = GetComponent<Renderer>(); // 获取平面模型的渲染器
        if (spawnAreaRenderer == null)
        {
            Debug.LogError("Spawn area renderer not found!");
            return;
        }

        GeneratePrefabs();
        gameObject.SetActive(false);
    }

    void GeneratePrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector3 randomPosition = GetRandomPositionInsideRendererBounds();
            Instantiate(prefabToGenerate, randomPosition, Quaternion.Euler(90,0,0));
        }
    }

    Vector3 GetRandomPositionInsideRendererBounds()
    {
        Vector3 randomPosition;
        randomPosition.x = Random.Range(spawnAreaRenderer.bounds.min.x, spawnAreaRenderer.bounds.max.x);
        randomPosition.y = 0.2f; // Assuming the plane is at y=0
        randomPosition.z = Random.Range(spawnAreaRenderer.bounds.min.z, spawnAreaRenderer.bounds.max.z);
        return randomPosition;
    }
}

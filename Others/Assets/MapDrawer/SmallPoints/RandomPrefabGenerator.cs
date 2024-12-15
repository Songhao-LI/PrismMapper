using UnityEngine;

public class RandomPrefabGenerator : MonoBehaviour
{
    public GameObject prefabToGenerate; // ��Ҫ���ɵ�Ԥ����
    public int numberOfPrefabs = 10; // Ĭ�����ɵ�����
    private Renderer spawnAreaRenderer; // ���ɷ�Χ����Ⱦ��

    void Start()
    {
        spawnAreaRenderer = GetComponent<Renderer>(); // ��ȡƽ��ģ�͵���Ⱦ��
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

using System.Collections;
using UnityEngine;

public class PipelineSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    float x;
    float minY = -2f;
    float maxY = 2f;

    void Start()
    {
        InvokeRepeating("spawnPipeline", 0f, 3f);
        x = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 1f;
    }

    void spawnPipeline()
    {
        Instantiate(prefab, new Vector3(x, Random.Range(minY, maxY)), Quaternion.identity);
    }
}

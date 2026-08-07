using UnityEngine;

public class PiplineDestroyer : MonoBehaviour
{
    float minX;

    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
}

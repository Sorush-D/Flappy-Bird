using UnityEngine;

public class BackGround : MonoBehaviour
{
    // It's better to make it responsive but it's just for training purpose
    Vector3 startPosition = new Vector3(5.5f, 0, 0);
    Vector3 endPosition = new Vector3(-5.5f, 0, 0);
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= endPosition.x)
        {
            transform.position = startPosition;
        }
    }
}

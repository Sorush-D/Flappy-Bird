using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PiplineMover : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.linearVelocity = Vector3.left * speed;
    }
}

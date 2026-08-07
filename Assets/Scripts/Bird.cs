using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 initialPosition;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float angularSpeed = 5f;

    float minY, maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        initialPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.5f, 0));
        initialPosition.z = 0;

        transform.position = initialPosition;

        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }


    void Update()
    {
        HandleJump();
        HandleRotation();

        if (transform.position.y < minY || transform.position.y > maxY)
        {
            GameManager.Instance.GameOver();
        }
    }


    void HandleJump()
    {
        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    void HandleRotation()
    {
        float targetAngle = rb.linearVelocity.y > 0 ? 40f : -30f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            angularSpeed * Time.deltaTime
            );
    }
}

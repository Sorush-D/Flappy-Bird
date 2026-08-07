using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 initialPosition;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float angularSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        initialPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.5f, 0));
        initialPosition.z = 0;

        transform.position = initialPosition;
    }


    void Update()
    {
        HandleJump();
        HandleRotation();
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

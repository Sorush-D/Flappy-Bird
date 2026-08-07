using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);
        }
    }
}

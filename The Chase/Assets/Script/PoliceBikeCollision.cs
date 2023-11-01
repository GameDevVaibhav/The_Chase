using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBikeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PoliceBike"))
        {
            Destroy(gameObject);
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseBountyOnDestroy(10); // Adjust the bounty amount as needed.
            }
        }
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            Destroy(gameObject);
        }
    }
}

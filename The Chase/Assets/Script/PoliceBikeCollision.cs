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
        }
        if (collision.gameObject.CompareTag("PoliceCar"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatCarCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Baricet"))
        {
            Destroy(gameObject);
        }
    }
}

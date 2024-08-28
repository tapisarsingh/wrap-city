using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform startPos;
    public bool targetPlayer;
    public bool isChekPoint;
    public float speed;
    public float selfDestroyAfter;
    private void Start()
    {
        Fire();
        Destroy(this.gameObject, selfDestroyAfter);
    }
    void Fire()
    {
        rb.AddForce(startPos.right * speed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChekPoint)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.instance.lastCheckPoint = this.transform;
                return;
            }
        }


        if (!targetPlayer)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<AiMovement>().GetHit();
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerMovement>().GetHit();
                Destroy(this.gameObject);
            }
        }

    }
}

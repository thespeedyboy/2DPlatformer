using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cratescrip : MonoBehaviour
{
    
    [SerializeField] float hitForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * hitForce, ForceMode2D.Impulse);
        }
    }
}

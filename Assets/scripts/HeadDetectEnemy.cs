using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]


public class HeadDetectEnemy : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    [SerializeField]private GameObject Enemy;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(Enemy);
        }
    }
}

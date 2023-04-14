using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int direction = -1;
    private Vector3 movement;
    public PlayerController player;
    public SpriteRenderer sprites;

    void Start(){
        StartCoroutine(SpriteSwap());
    }

    void Update()
    {
        movement = new Vector3(2 * direction, 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime;
    }  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = direction * -1;
        sprites.flipX = !sprites.flipX;
        if (collision.gameObject.CompareTag("Player"))
        {
           player.Hit();
        }
    }

    IEnumerator SpriteSwap(){
        while(true){
            sprites.flipX = !sprites.flipX;
            yield return new WaitForSeconds(1f);
            sprites.flipX = !sprites.flipX;
        }
    }
}

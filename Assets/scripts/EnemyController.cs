using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int direction = -1;
    private Vector3 movement;
    public PlayerController player;
    public SpriteRenderer sp;
    public Sprite[] sprites;

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

        if (collision.gameObject.CompareTag("Player"))
        {
           player.Hit();
        }
    }

    IEnumerator SpriteSwap(){
        while(true){
            sp.flipX = sprites[0];
            yield return new WaitForSeconds(0.30f);
            sp.flipX = sprites[1];
        }
    }
    public IEnumerator DiedAnimation(){
        while(true){
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<AudioSource>().Play();
            sp.sprite = sprites[2];
            yield return new WaitForSeconds(0.20f);
            Destroy(gameObject);
        }
    }
}

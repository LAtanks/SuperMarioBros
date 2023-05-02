
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LuckBlock : MonoBehaviour
{
    //"0" Empty sprite
    //"1" normal sprite
    public Sprite[] LuckBlockSprites;
    public SpriteRenderer sr;
    public AudioSource audioSource;
    public AudioClip LuckBlockSfx;
    public Vector2 size;
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4f;
    private Vector2 originalPosition;
    
    private bool canBounce = true;
    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")) LuckBlockBounce();
    }

    public void LuckBlockBounce(){
        if(canBounce){
            canBounce = false;
            audioSource.clip = LuckBlockSfx;
            audioSource.Play();
            StartCoroutine(HitAnimation());
        }
    }

    private void Update()   
    {

    }
    IEnumerator HitAnimation(){
        sr.sprite = LuckBlockSprites[0];    

        while(true){
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            if(transform.localPosition.y >= originalPosition.y  + bounceHeight)break;

            yield return null; 
        }
        while(true){
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);

            if(transform.localPosition.y <= originalPosition.y){
                
                transform.localPosition = originalPosition;
                break;
            }

            yield return null;
        }
    }
}


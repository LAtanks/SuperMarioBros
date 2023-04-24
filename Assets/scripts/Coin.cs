using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayerController player;
    public Sprite[] spr;
    public SpriteRenderer sr;
    public AudioSource _as;
    public AudioClip as_sfx;

    private void Awake()
    {
        StartCoroutine(SpriteAnimation());
        _as = GetComponent<AudioSource>();
        _as.clip = as_sfx; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {_as.Play();
        if (collision.gameObject.CompareTag("Player"))
        {
            
            player.coinCount++;
            Destroy(gameObject);
        }
    }

    IEnumerator SpriteAnimation()
    {
        while (true)
        {
            sr.sprite = spr[0];
            yield return new WaitForSeconds(0.30f);
            sr.sprite = spr[1];
            yield return new WaitForSeconds(0.30f);
            sr.sprite = spr[2];
            yield return new WaitForSeconds(0.30f);
            sr.sprite = spr[3];
            yield return new WaitForSeconds(0.30f);
        }
    }
}

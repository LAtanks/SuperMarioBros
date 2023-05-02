using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayerController player;
    public Sprite[] spr;
    public SpriteRenderer sr;
    private void Awake()
    {
        StartCoroutine(SpriteAnimation());
    }
    IEnumerator SpriteAnimation()
    {
        while (true)
        {
            sr.sprite = spr[0];
            yield return new WaitForSeconds(0.25f);
            sr.sprite = spr[1];
            yield return new WaitForSeconds(0.25f);
            sr.sprite = spr[2];
            yield return new WaitForSeconds(0.25f);
            sr.sprite = spr[3];
            yield return new WaitForSeconds(0.25f);
        }
    }
}

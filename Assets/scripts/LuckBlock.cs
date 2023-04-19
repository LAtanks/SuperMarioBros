using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LuckBlock : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite LuckBlockNormal;
    public Sprite LuckBlockEmpaty;
    public SpriteRenderer sr;
    [Header("Sounds Effects")]
    public AudioSource audioSource;
    public AudioClip LuckBlockSfx;
    [Header("Configs")]
    public float distance;
    public BoxCollider2D boxCollider;
    RaycastHit hit;
    bool isTouch;
    bool isEmpaty = false;
    public Vector2 size;
    private void Start()
    {
        sr.sprite = LuckBlockNormal;
        audioSource.clip = LuckBlockSfx;
        audioSource.loop = false;
    }
    private void Update()   
    {

        if (isTouch && isEmpaty == false)
        {
            sr.sprite = LuckBlockEmpaty;
            isEmpaty = true;
            audioSource.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouch = true;
        }
    }
}


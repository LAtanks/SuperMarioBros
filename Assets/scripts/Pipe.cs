using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public PlayerController player;
    public AudioSource audiosource;
    public Vector2 newPos;
    public Animator anim;
    public bool statePipe = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (statePipe == true) return;
        if (collision.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.S))
        {
            //audiosource.Play();
            player.transform.position = newPos;
        }
    }
}

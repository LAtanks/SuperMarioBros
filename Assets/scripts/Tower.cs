using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public PlayerController player;
    public Animator winGui;
    public Animator playerAnim;
    public GameObject HUD;
    public AudioClip win_stx;
    public GameObject prefab;
    public GameObject instantiate;
    private void Start()
    {
        player.GetComponent<Animator>().enabled = false;
        if(HUD.active == false) HUD.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            HUD.SetActive(false);
            player.as_stx.clip = win_stx;
            player.as_stx.Play();
            StartCoroutine(Win());
        }
    }
    IEnumerator Win()
    {
        while(true){            
            player.GetComponent<Animator>().enabled = true;
            playerAnim.SetBool("isWin", true);
            HUD.SetActive(false);
            yield return new WaitForSeconds(10f);
            break;
        }
        SceneManager.LoadScene("MainMenu");
    }

    
}

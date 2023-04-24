using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public PlayerController player;
    public Animator winGui;
    public Animator playerAnim;
    public GameObject HUD;
    public AudioClip win_stx;
    //public Color[] Colors = [Color.red, Color.blue, Color.cyan, Color.green, Color.yellow, Color.white];
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
            //player.GetComponent<Animator>().enabled = true;
           // playerAnim.SetBool("isWin", true);
            HUD.SetActive(false);
            player.as_stx.clip = win_stx;
            player.as_stx.Play();

           // player.cam.state = true;
           // player.cam.transform.position = Vector2.up * 10;
            
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        //Vector2 a = Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width, 0));
        //Vector2 b = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        player.GetComponent<Animator>().enabled = true;
        playerAnim.SetBool("isWin", true);
        HUD.SetActive(false);
        Debug.Log("Test1");
            //Instantiate(prefab, new Vector2(Random.Range(a.x, b.x), instantiate.transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(130);
        Debug.Log("Test2");
        winGui.SetBool("AnimationGui", true);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public PlayerController player;
    public Animator winGui;
    public GameObject HUD;
    public AudioClip win_stx;
    //public Color[] Colors = [Color.red, Color.blue, Color.cyan, Color.green, Color.yellow, Color.white];
    public GameObject prefab;
    public GameObject instantiate;
    private void Start()
    {
        HUD.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            HUD.SetActive(false);
            player.as_stx.clip = win_stx;
            player.as_stx.Play();

            player.cam.state = true;
            player.cam.transform.position = Vector2.up * 10;
            winGui.SetBool("AnimationGui",true);
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        Vector2 a = Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width, 0));
        Vector2 b = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        while (true)
        {
            Instantiate(prefab, new Vector2(Random.Range(a.x, b.x), instantiate.transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

    
}

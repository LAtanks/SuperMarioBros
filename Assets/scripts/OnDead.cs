

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OnDead : MonoBehaviour
{
    public PlayerController player;
    public CameraFollow camera;
    public TextMeshProUGUI lastPoints;
    public GameObject DiedGUI;
    void Update()
    {
        if(player.life_count == 0 && player.isDead == false){
            player.isDead = true;
            camera.state = true;
            camera.gameObject.transform.position = Vector2.up * 20f;
            DiedGUI.SetActive(true);
            player.as_stx.clip = player.deadStx;
            player.as_stx.Play();
        }  
        if(Input.GetKeyDown(KeyCode.Tab) && player.isDead == true){
            SceneManager.LoadScene("Kingdom1");
        }
    }
}

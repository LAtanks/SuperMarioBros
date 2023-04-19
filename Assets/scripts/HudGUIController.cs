using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudGUIController : MonoBehaviour
{
    public GameObject GUI;
    public PlayerController player;
    public TextMeshProUGUI _coins;
    public TextMeshProUGUI _points;
    public TextMeshProUGUI _lifes;
    public TextMeshProUGUI _time;

    float time = 0;

    private void Update()
    {
        ++frames;
        float timeNow = (int)Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
        _time.text = timeNow.ToString();
        _coins.text = player.coinCount.ToString();
        _points.text = player.pointCount.ToString();
        _lifes.text = player.life_count.ToString();
    }

    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames;
    private float fps;
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void OnGUI()
    {
        GUILayout.Label("" + fps.ToString("f2"));
    }
}

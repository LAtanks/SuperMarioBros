using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public GameObject leftBounds;
    public GameObject rightBounds;
    public BoxCollider2D inPipe;

    public bool state = false;
    public float smoothDampTime = 0.15F;
    private Vector3 smoothDampVelocity = Vector3.zero;
    private float camWidth, camHeight, levelMinX, levelMaxX, levelY;


    void Start()
    {
        camHeight = Camera.main.orthographicSize * 2;
        camWidth =camHeight * Camera.main.aspect;

        float leftBoundsWidth = leftBounds.GetComponentInChildren<BoxCollider2D>().bounds.size.x / 2;
        float rightBoundsWidth = rightBounds.GetComponentInChildren<BoxCollider2D>().bounds.size.x / 2;

        levelMinX = leftBounds.transform.position.x + leftBoundsWidth + (camWidth / 2);
        levelMaxX = rightBounds.transform.position.x - rightBoundsWidth - (camWidth/2);

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && state == false)
        {

            float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.transform.position.x));
            float targetY = target.transform.position.y +2;

            float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);
            float y = Mathf.SmoothDamp(transform.position.y, targetY, ref smoothDampVelocity.y, smoothDampTime);

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}

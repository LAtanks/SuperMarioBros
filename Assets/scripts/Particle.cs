using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(DestroyThis());
    }



    IEnumerator DestroyThis()
    {
        sprite = GetComponent<SpriteRenderer>();
        Color clor = new Color(
     (float)Random.Range(0, 255),
     (float)Random.Range(0, 255),
     (float)Random.Range(0, 255)
 );
        sprite.color = clor;
        yield return new WaitForSeconds(15f);
        Destroy(this);
    }
}

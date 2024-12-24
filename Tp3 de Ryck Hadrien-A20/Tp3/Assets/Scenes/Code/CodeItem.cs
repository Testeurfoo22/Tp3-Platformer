using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CodeItem : MonoBehaviour
{
    float Timer;
    float positionX;
    float positionY;

    PlayableDirector pD;
    Collider2D c2D;

    void Awake()
    {
        pD = gameObject.GetComponent<PlayableDirector>();
        c2D = gameObject.GetComponent<Collider2D>();

        positionX = gameObject.transform.position.x;
        positionY = gameObject.transform.position.y;
    }

    void OnEnable()
    {
        c2D.enabled = true;
        gameObject.transform.Translate(positionX - gameObject.transform.position.x, positionY - gameObject.transform.position.y, 0F);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        Timer = 0;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Timer > 0)
        {
            Timer += 0.05F;
        }
        if (Timer > 4)
        {
            Timer = 0;
            pD.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pD.Play();
            Timer = 0.1F;
            c2D.enabled = false;
        }
    }
}

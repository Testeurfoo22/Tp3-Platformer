using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class CodePieceNiveau : MonoBehaviour
{
    float Timer;
    float positionX;
    float positionY;
    int sousous;

    PlayableDirector pD;
    Collider2D c2D;

    public TextMeshPro sous;

    void Awake()
    {
        pD = gameObject.GetComponent<PlayableDirector>();
        c2D = gameObject.GetComponent<Collider2D>();

        int.TryParse(sous.text, out sousous);
        sous.text = sousous.ToString();
    }

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
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pD.Play();
            Timer = 0.1F;
            c2D.enabled = false;
            int.TryParse(sous.text, out sousous);
            sousous++;
            sous.text = sousous.ToString();
        }
    }
}

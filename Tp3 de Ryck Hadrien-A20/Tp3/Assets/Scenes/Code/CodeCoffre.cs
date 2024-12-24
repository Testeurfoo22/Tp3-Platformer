using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCoffre : MonoBehaviour
{
    float positionX;
    float positionY;
    float nbSon;
    float Timer;

    Transform casse;
    Animator anim;
    AudioSource aS;

    // Start is called before the first frame update
    void Awake()
    {
        casse = gameObject.transform;
        anim = gameObject.GetComponent<Animator>();
        aS = gameObject.GetComponent<AudioSource>();

        positionX = casse.position.x;
        positionY = casse.position.y;
    }

    private void OnEnable()
    {
        Vector2 cassepos = casse.position;
        casse.Translate((positionX - cassepos.x), (positionY - cassepos.y), 0F);
        nbSon = 0;
        Timer = 0;
    }

    private void FixedUpdate()
    {
        if (nbSon == 1)
        {
            anim.SetFloat("etat", 1);
            aS.Play();
            nbSon++;
            Timer = 0.1F;
        }
        if (Timer > 0)
        {
            Timer += 0.05F;
        }
        if (Timer == 0 || Timer > 2)
        {
            anim.SetFloat("etat", 0);
            Timer = 0;
        }

    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (nbSon == 0)
            {
                nbSon++;
            }
        }
    }
}

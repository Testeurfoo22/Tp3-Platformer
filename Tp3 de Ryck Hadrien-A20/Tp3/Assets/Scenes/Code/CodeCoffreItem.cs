using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCoffreItem : MonoBehaviour
{
    float positionX;
    float positionY;
    float YItem;
    public float vitesse;
    bool Item;
    float nbSon;
    float Timer;

    Transform casse;
    Animator anim;
    AudioSource aS;

    public GameObject Object;

    // Start is called before the first frame update
    void Awake()
    {
        casse = gameObject.transform;
        anim = gameObject.GetComponent<Animator>();
        aS = gameObject.GetComponent<AudioSource>();

        positionX = casse.position.x;
        positionY = casse.position.y;

        YItem = Object.transform.localPosition.y;
    }

    private void OnEnable()
    {
        Vector2 cassepos = casse.position;
        casse.Translate((positionX - cassepos.x), (positionY - cassepos.y), 0F);
        Item = false;
        nbSon = 0;
        Timer = 0;
    }

    private void FixedUpdate()
    {
        if (Item && nbSon == 0)
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
        if (Item && Object.transform.localPosition.y < YItem + 0.3F)
        {
            Object.transform.Translate(0F, vitesse, 0F);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Item = true;
        }
    }
}

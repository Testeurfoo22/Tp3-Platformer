using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMechant1 : MonoBehaviour
{
    public float vitesse;
    float vitesse2;
    float positionX;
    float positionY;
    float Timer = 0;
    bool mort;

    Transform deplacement;
    Animator anim;
    Collider2D bc;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public Transform Robot;

    // Start is called before the first frame update
    void Awake()
    {
        deplacement = gameObject.transform;
        anim = gameObject.GetComponent<Animator>();
        bc = gameObject.GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        positionX = deplacement.position.x;
        positionY = deplacement.position.y;

    }

    private void OnEnable()
    {
        Vector2 deplacementpos = deplacement.position;
        deplacement.Translate((positionX - deplacementpos.x), (positionY - deplacementpos.y), 0F);

        gameObject.transform.tag = "mechant";
        anim.SetFloat("Mechant 1", 0);
        bc.enabled = true;
        gameObject.SetActive(true);
        mort = false;

        vitesse2 = vitesse;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Timer > 0 && Timer < 6)
        {
            Timer += 0.05F;
        }
        if (Timer > 6)
        {
            Timer = 0;
            if (vitesse2 == -vitesse)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }


        if (Timer == 0)
        {
            if (deplacement.position.x < Robot.position.x + 10)
            {
                deplacement.Translate(vitesse2, 0F, 0F);
            }
        }
        if (Timer == 0 && mort)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == ("ATTAQUE"))
        {
            gameObject.transform.tag = "Untagged";
            anim.SetFloat("Mechant 1", 1);
            bc.enabled = false;
            Timer = 0.1F;
            mort = true;
        }
        if (collision.transform.tag != ("Sol"))
        {
            Timer = 0.1F;
            vitesse2 = -vitesse;
            rb.AddRelativeForce(Vector2.right * (vitesse));
        }
    }

}

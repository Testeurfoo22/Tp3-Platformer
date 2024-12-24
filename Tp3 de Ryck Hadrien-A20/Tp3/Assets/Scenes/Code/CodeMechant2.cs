using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMechant2 : MonoBehaviour
{
    public float vitesse;
    float vitesse2;
    float positionX;
    float positionY;
    float Timer = 0;

    Transform deplacement;
    Animator anim;
    Collider2D co2D;
    SpriteRenderer sr;

    public Transform Robot;

    // Start is called before the first frame update
    void Awake()
    {
        deplacement = gameObject.transform;
        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        co2D = gameObject.GetComponent<Collider2D>();

        positionX = deplacement.position.x;
        positionY = deplacement.position.y;
    }

    private void OnEnable()
    {
        Vector2 deplacementpos = deplacement.position;
        deplacement.Translate((positionX - deplacementpos.x), (positionY - deplacementpos.y), 0F);

        gameObject.transform.tag = "mechant";
        co2D.enabled = true;
        anim.SetFloat("mechant 2", 0);
        gameObject.SetActive(true);

        vitesse2 = vitesse;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (deplacement.position.x < Robot.position.x + 10)
        {
            deplacement.Translate(vitesse2, 0F, 0F);
        }
        if (deplacement.position.x < Robot.position.x - 1)
        {
            vitesse2 = -vitesse;
            sr.flipX = false;
        }
        if (deplacement.position.x > Robot.position.x + 1)
        {
            vitesse2 = vitesse;
            sr.flipX = true;
        }



        if (Timer > 0 && Timer < 6)
        {
            Timer += 0.05F;
        }
        if (Timer > 6)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == ("ATTAQUE"))
        {
            gameObject.transform.tag = "Untagged";
            co2D.enabled = false;
            anim.SetFloat("mechant 2", 1);
            Timer = 0.1F;
        }
    }
}

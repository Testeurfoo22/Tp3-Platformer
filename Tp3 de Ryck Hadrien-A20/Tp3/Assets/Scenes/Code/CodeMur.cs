using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMur : MonoBehaviour
{
    public float vitesse;
    public float espacement;
    float placementY;
    bool colision = false;
    float nbColision = 0;
    float Timer = 0F;

    Transform chute;
    Animator anim;
    public Transform Robot;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        chute = gameObject.transform;
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        placementY = chute.position.y;
    }

    private void OnEnable()
    {
        chute.Translate( 0F, (placementY - chute.position.y), 0F);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chute.position.x - Robot.position.x < espacement && colision == false)
        {
            nbColision = 0;
            rb.simulated = true;
            rb.gravityScale = 2F;
        }

        if (colision && nbColision == 0)
        {
            Timer = 0.1F;
            anim.SetTrigger("Hit Bas");
            nbColision++;
        }

        if (Timer > 0 && Timer < 5)
        {
            Timer += 0.1F;
        }

        if (Timer > 5 && chute.position.y < placementY)
        {
            chute.Translate(0F, vitesse, 0F);
        }
        if (chute.position.y > placementY)
        {
            colision = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colision = true;
        rb.gravityScale = 0F; 
        rb.simulated = false;

    }
}

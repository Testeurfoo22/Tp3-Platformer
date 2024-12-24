using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeFeu : MonoBehaviour
{
    float Timer = 0;

    Animator anim;
    BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Timer < 8)
        {
            anim.SetFloat("Feu", 0);
            bc.size = new Vector2(0.16F, 0.18F);
            gameObject.transform.tag = "Untagged";
        }
        if (Timer > 8)
        {
            anim.SetFloat("Feu", 1);
            bc.size = new Vector2(0.16F, 0.5F);
            gameObject.transform.tag = "mechant";
        }
        if (Timer > 16)
        {
            Timer = 0;
        }
        Timer += 0.05F;
    }
}

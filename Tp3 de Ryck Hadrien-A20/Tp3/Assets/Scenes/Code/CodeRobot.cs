using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeRobot : MonoBehaviour
{
    public float vitesse;
    public float saut;

    float deplacement;
    bool sauter;
    float sneak ;
    public float vital;
    float mort ;
    float roulade ;
    float vie;
    bool boolsneak;
    bool TouteFin;
    bool roule;
    int nbSauts;
    float Timer = 0;
    float positionX;
    float positionY;

    public GameObject Fin;
    public GameObject Niveau;
    public GameObject Menu;
    public GameObject Coeur;
    public GameObject Coeur1;
    public TextMeshPro JarreJ;
    public TextMeshPro JarreV;
    public AudioClip Hit;
    public AudioClip GameOver;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    CapsuleCollider2D cC2D;
    CircleCollider2D bC2D;
    AudioSource Son;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        cC2D = gameObject.GetComponent<CapsuleCollider2D>();
        bC2D = gameObject.GetComponent<CircleCollider2D>();
        Son = gameObject.GetComponent<AudioSource>();

        deplacement = 0;
        nbSauts = 0;

        positionX = gameObject.transform.position.x;
        positionY = gameObject.transform.position.y;
    }

    private void OnEnable()
    {
        deplacement = 0;
        nbSauts = 0;
        sneak = 0F;
        mort = vital * 2;
        roulade = 0F;
        boolsneak = false;
        TouteFin = false;
        roule = true;
        vie = mort / 2;


        JarreJ.text = roulade.ToString();
        JarreV.text = sneak.ToString();

        gameObject.transform.Translate(positionX - gameObject.transform.position.x, positionY - gameObject.transform.position.y, 0F);
    }

    // Update is called once per frame
    void Update()
    {
        deplacement = Input.GetAxis("Horizontal");
        if (boolsneak == true)
        {
            anim.SetFloat("etat", Mathf.Abs(2));
        }
        else
        {
            anim.SetFloat("etat", Mathf.Abs(deplacement));
        }

        if (deplacement < 0)
        {
            sr.flipX = true;
            bC2D.offset = new Vector2(-0.5F, 0.95F);
        }
        else
        {
            sr.flipX = false;
            bC2D.offset = new Vector2 (0.5F, 0.95F);
        }

        if (Input.GetKeyDown("space") && nbSauts < 1)
        {
            anim.SetTrigger("Saut");
            sauter = true;
            nbSauts++;
        }

        if (Input.GetKeyDown("s") && sneak != 0F)
        {
            if (boolsneak == false)
            {
                boolsneak = true;
                bC2D.enabled = true;
                cC2D.enabled = false;
            }
            else
            {
                boolsneak = false;
                cC2D.enabled = true;
                bC2D.enabled = false;
                sneak--;
            }
        }

        if (Input.GetKeyDown("x") && roulade != 0F && roule)
        {
            gameObject.transform.tag = "ATTAQUE";
            anim.SetTrigger("Roulade");
            Timer = 0.1F;
            bC2D.enabled = true;
            cC2D.enabled = false;
            roule = false;
        }


        if (Timer > 0)
        {
            Timer += 0.05F;
        }
        if (mort != 0 && Timer > 12 && roulade != 0)
        {
            Timer = 0;
            gameObject.transform.tag = "Player";
            cC2D.enabled = true;
            bC2D.enabled = false;
            roulade--;
            roule = true;
        }

        if ((mort == 3 || mort == 1 )&& Timer > 5)
        {
            mort--;
        }
    }

    void FixedUpdate()
    {
        if (mort != 0F)
        {
            //Son.Play();
            if (nbSauts == 1)
            {
                rb.AddRelativeForce(Vector2.right * (vitesse / 8) * deplacement);
            }
            if (boolsneak)
            {
                rb.AddRelativeForce(Vector2.right * (float)(vitesse / 1.6) * deplacement);
            }
            if (nbSauts == 0 && boolsneak == false)
            {
                rb.AddRelativeForce(Vector2.right * vitesse * deplacement);
            }
            if (sauter)
            {
                rb.AddRelativeForce(Vector2.up * saut, ForceMode2D.Impulse);
                sauter = false;
            }
        }


        if (gameObject.transform.localPosition.x > Fin.transform.localPosition.x)
        {
            TouteFin = true;
        }
        if (TouteFin)
        {
            Timer += 0.005F;
        }
        if ((TouteFin && Timer > 5) || (mort == 0F && Timer > 12))
        {
            Niveau.SetActive(false);
            Menu.SetActive(true);
        }

        if (mort <= 1F)
        {
            anim.SetTrigger("Mort");
        }

        vie = (Mathf.Floor(mort / 2));

        if (vie == 0)
        {
            Coeur.SetActive(false);
            Coeur1.SetActive(false);
        }
        if (vie == 1)
        {
            Coeur.SetActive(false);
            Coeur1.SetActive(true);
        }
        if (vie == 2)
        {
            Coeur.SetActive(true);
            Coeur1.SetActive(true);
        }

        JarreJ.text = roulade.ToString();
        JarreV.text = sneak.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Coeur")
        {
            mort = 4F;
        }
        if (collision.transform.tag == "JarreJ")
        {
            roulade = 3F;
        }
        if (collision.transform.tag == "JarreV")
        {
            sneak = 3F;
        }
        if (collision.transform.tag == "mechant" && gameObject.transform.tag != "ATTAQUE" && (mort != 3 || mort != 1))
        {
            if (mort == 2)
            {
                Son.PlayOneShot(GameOver, 0.75F);
            }
            else
            {
                Son.PlayOneShot(Hit, 0.75F);
            }
            mort--;
            Timer = 0.1F;
        }
        if (collision.transform.tag != "Sous" && collision.transform.tag != "Mur")
        {
            nbSauts = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePics : MonoBehaviour
{
    public float vitesse;
    float vitesse2;
    float placementX;
    float placementY;
    float Timer = 0;

    Transform deplacement;
    private void Awake()
    {
        deplacement = gameObject.transform;
        placementX = deplacement.position.x;
        placementY = deplacement.position.y;

    }

    private void OnEnable()
    {
        Vector2 DepPlateforme = deplacement.position;
        deplacement.Translate((placementX - DepPlateforme.x), (placementY - DepPlateforme.y), 0F);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 DepPlateforme = deplacement.position;

        if (DepPlateforme.y >= placementY)
        {
            Timer = 0.1F;
            vitesse2 = -vitesse;
            deplacement.Translate(0F, vitesse2, 0F);
        }
        if (DepPlateforme.y <= (placementY -1))
        {
            Timer = 0.1F;
            vitesse2 = vitesse;
            deplacement.Translate(0F, vitesse2, 0F);
        }

        if (Timer < 6)
        {
            Timer += 0.1F;
        }
        if (Timer > 6)
        {
            deplacement.Translate(0F, vitesse2, 0F);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeNiveauCache : MonoBehaviour
{
    int sousous;
    public float sousMax;

    public Button Niveau;
    public TextMeshProUGUI NiveauTexte;
    public TextMeshPro sous;

    // Start is called before the first frame update
    void OnEnable()
    {
        int.TryParse(sous.text, out sousous);
        if (sousous == sousMax)
        {
            NiveauTexte.color = new Color32(0, 0, 0, 255);
            Niveau.enabled = true;
        }
    }
}

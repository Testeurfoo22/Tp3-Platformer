using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeChoixNiveau : MonoBehaviour
{
    public Button Niveau;
    public Transform Robot;
    public Transform Fin;
    public TextMeshProUGUI NiveauTexte;

    private void OnEnable()
    {
        if (Robot.transform.position.x > Fin.transform.position.x)
        {
            NiveauTexte.color = new Color32(0, 0, 0, 255);
            Niveau.enabled = true;
        }
    }
}

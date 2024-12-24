using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCamera : MonoBehaviour
{
    float cameradhauteur;
    float cameradlargeur;
    float positionX;
    float positionY;

    public Transform pointhaut;
    public Transform pointbas;
    public Transform Robot;

    Transform deplacement;
    // Start is called before the first frame update
    void Awake()
    {
        deplacement = gameObject.transform;
        Camera cam = gameObject.GetComponent<Camera>();

        cameradhauteur = cam.orthographicSize;
        cameradlargeur = cam.aspect * cameradhauteur;

        positionX = deplacement.position.x;
        positionY = deplacement.position.y;
    }

    private void OnEnable()
    {
        Vector2 deplacementpos = deplacement.position;
        deplacement.Translate((positionX - deplacementpos.x), (positionY - deplacementpos.y), 0F);
    }

    // Update is called once per frame
    void Update()
    {
        float posHor, posVer;

        posHor = Mathf.Clamp(
            Robot.position.x + 1,
            pointhaut.position.x + cameradlargeur,
            pointbas.position.x - cameradlargeur);
        posVer = Mathf.Clamp(
            Robot.position.y + 1,
            pointbas.position.y + cameradhauteur,
            pointhaut.position.y - cameradhauteur);

        deplacement.position = new Vector3(
            posHor ,
            posVer ,
            deplacement.position.z);

    }
}

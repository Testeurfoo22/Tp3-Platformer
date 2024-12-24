using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBoule : MonoBehaviour
{
    public float vitesse;
    float placementR;

    Transform rotation;
    // Start is called before the first frame update
    void Awake()
    {
        rotation = gameObject.transform;
        placementR = rotation.rotation.eulerAngles.z;
    }

    private void OnEnable()
    {
        rotation.Rotate(0F, 0F, (placementR - rotation.rotation.eulerAngles.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotation.Rotate(0F, 0F, vitesse);
    }
}

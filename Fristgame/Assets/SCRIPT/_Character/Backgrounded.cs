using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backgrounds;
    public float fparallax = 0.4f;
    public float layarFraction = 5f;
    public float fSmooth = 5f;

    Transform cam;
    Vector3 previousCamPos;
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        previousCamPos = cam.position;
    }


    // Update is called once per frame
    void Update()
    {
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fparallax;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float fNew = backgrounds[i].position.x + fParrlaxX * (1 + i * layarFraction);
            Vector3 newPos = new Vector3(fNew, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, newPos, fSmooth * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}

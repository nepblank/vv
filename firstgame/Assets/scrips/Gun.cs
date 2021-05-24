using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    playercontrol playCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playCtrl = transform.root.GetComponent<playercontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 direction = new Vector3(0, 0, 0);
            if(playCtrl.bFaceRight)
            {
                direction.y = 180;
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position,
                                                            Quaternion.Euler(direction));
                RockectInstance.velocity = new Vector2(-fSpeed, 0);
            }
            else
            {
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position,
                                                            Quaternion.Euler(direction));
                RockectInstance.velocity = new Vector2(fSpeed, 0);
            }
        }
    }
}

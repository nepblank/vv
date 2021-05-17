using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    playercontrl playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<playercontrl>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(playerCtrl.bFaceRight)
            {
                Rigidbody2D RocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
            }
        }
    }
}

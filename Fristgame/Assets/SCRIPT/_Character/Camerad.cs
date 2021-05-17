using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerad : MonoBehaviour
{
    public Transform playerTran;
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float SmoothX = 4;
    public float SmoothY = 4;

    public Vector2 MaxCamXandY;
    public Vector2 MinCamXandY;

    // Start is called before the first frame update
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > maxDistanceX)
            bMove = true;
        else
            bMove = false;

        return bMove;
    }


    private bool NeedMoveY()
    {
        bool aMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > maxDistanceY)
            aMove = true;
        else
            aMove = false;

        return aMove;
    }


    void Start()
    {
        
    }
    private void Awake()
    {
       playerTran = GameObject.Find("Hero").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TrackPlayer()
    {
        float CamNewX = transform.position.x;
        float CamNewY = transform.position.y;
        if (NeedMoveX()) //计算新摄像机位置
            CamNewX = Mathf.Lerp(transform.position.x, transform .position.x, SmoothX * Time.deltaTime);
        if (NeedMoveY())
            CamNewY = Mathf.Lerp(transform.position.y,
            transform.position.y, SmoothY * Time.deltaTime);
        //将新摄像机位置固定在合法范围内
        CamNewX = Mathf.Clamp(CamNewX,
MinCamXandY.x, MaxCamXandY.x);
        CamNewY = Mathf.Clamp(CamNewY, MinCamXandY.y,
                    MaxCamXandY.y);
        transform.position = new Vector3(CamNewX, CamNewY,
                    transform.position.z);
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }
}

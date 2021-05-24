using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTran; //代表主角的transform
    public float maxDistanceX = 2;//摄像机与主角在X轴的最大距离
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY= new Vector2(-8, 8);
    // Start is called before the first frame update
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x)>maxDistanceX )
            bMove = true;
        else
            bMove = false;

        return bMove;
    }
    private bool NeedMoveY()
    {
        bool cMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > maxDistanceY)
            cMove = true;
        else
            cMove = false;
        return cMove;
    }
   
    void Start()
    {
        
    }
    private void Awake()
    {
        //playerTran = GameObject.Find("hero").transform;
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (NeedMoveX())
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x,
                xSpeed * Time.deltaTime);
        if (NeedMoveY())
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y,
                ySpeed * Time.deltaTime);
        newX = Mathf.Clamp(newX, minXandY.x, maxXandY.x);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
}

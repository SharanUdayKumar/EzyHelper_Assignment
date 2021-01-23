using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_layout : NetworkBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
   
    [SerializeField] Vector2 move;

    [SyncVar] Vector3 transformpos;
    [SyncVar] Vector3 finaltransform;


    public GameObject ballprefab;
    [SerializeField] Transform ball_pos;
    public GameObject playerprefab;
    [SerializeField] Transform playerpos;
    public float speed = 500f;
    [SerializeField] movement_paddle MP;

    public Vector3 targetpos;
    //[Range(-5f,5f)]
    public float _finaltarget;
    mynetworkmanager MNM;


    public static
    int i=0;
   
    private void Start()
    {
        MNM = FindObjectOfType<mynetworkmanager>();
        i++;
        MNM.i = i;
      //  print("instantiating");
       
     //  Ball_Spawn();
    }
    // [ClientRpc]


    public void Ball_Spawn()
    {
        //  GameObject Player_main = Instantiate(playerprefab, playerpos.position, Quaternion.identity);
        GameObject Ball = Instantiate(ballprefab, ball_pos.position, Quaternion.identity);
    }
    // Update is called once per frame
    public void Update()
    {
       // print("processing move");
        if (isLocalPlayer)
        {
            CmdMove_Player();
        }

        else if (isServer)
        {
            RpcMove_Player();
        }


    }

    [Command]
    public void CmdMove_Player()
    {
        RpcMove_Player();
    }
      
  
    [ClientRpc]
    public void RpcMove_Player()
    {
        //

        if (isLocalPlayer)
        {
            if (Input.GetMouseButton(0))
            {
                targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
               
                _finaltarget = targetpos.x;

                if(_finaltarget < -4.5f)
                {
                    _finaltarget = -4.5f;
                }


                if(_finaltarget > 4f)
                {
                    _finaltarget = 4f;
                }
                var finaltargetpos = new Vector3(_finaltarget, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, finaltargetpos, speed * Time.deltaTime);
                //  print("moving right");
                //  transformpos = transform.right * (Time.deltaTime * 5);
                //  finaltransform = transform.position + transformpos;
                //transform.position = finaltransform;


            }
            //if (Input.GetKey(KeyCode.A))
            //{
            //    transformpos = transform.right * (Time.deltaTime * 5);
            //    finaltransform = transform.position - transformpos;
            //   transform.position = finaltransform;
            //}
        }
       // }
    }

    //  private void OnCollisionEnter2D(Collision2D collision)
    //  {

    //    if(collision.gameObject.CompareTag("PlayerBall"))
    //   {
    //rb2d.constraints
    //  }
    // }
}

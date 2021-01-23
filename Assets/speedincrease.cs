using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedincrease : NetworkBehaviour
{
    [SyncVar]
    // Start is called before the first frame update
    public bool playerdeath = false;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
       // rb2d.useGravity = false;
        DestroyBall();
      //  Rotation();
    }
    //  [ClientRpc]

    private void Start()
    {
        transform.SetParent(null);
    }
    private void DestroyBall()
    {
        if (playerdeath == true)
        {
           // print("hitball");
            Destroy(gameObject);
        }
    }


    //private void Rotation()
    //{
    //    transform.position += transform.right * (Time.deltaTime);// * .1f);
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary") && playerdeath == false)
        {
            playerdeath = true;
          //  print("hitball");




        }

        //if (collision.gameObject.CompareTag("Player"))
        //{
        //  //  print("hit player");
        //    Rotation();
        //}
        //  //[SerializeField] Rigidbody2D rb2d;
        // // [SyncVar]
        // //public  bool isincspeed = false;
        //  [SyncVar]
        //  //[SerializeField]
        //  public bool playerdead = false;


        // // [SerializeField] Vector2 speed;
        //  // Start is called before the first frame update

        //  // Update is called once per frame
        ////  [ClientRpc]
        //  void Update()
        //  {
        //      //IncreaseSpeed();
        //      PlayerDeath();
        //  }

        //  [ClientRpc]
        //  private void PlayerDeath()
        //  {
        //      print("initiating death protocol");
        //      if (playerdead == true)
        //      {
        //          print("dead");
        //          Destroy(gameObject);
        //      }
        //  }

        //  //[ClientRpc]
        //  //private void IncreaseSpeed()
        //  //{
        //  //    if (isincspeed == true)
        //  //    {
        //  //        Debug.Log("increasing speed");
        //  //        rb2d.velocity = rb2d.velocity * 2f;

        //  //        print(rb2d.velocity);
        //  //        isincspeed = false;
        //  //    }
        //  //}


        //  public void OnCollisionEnter2D(Collision2D collision)
        //  {
        //      //if (collision.gameObject.CompareTag("Player") && isincspeed == false)
        //      //{
        //      //    isincspeed = true;
        //      //}

        //      if (collision.gameObject.CompareTag("Boundary") && playerdead == false)
        //      {

        //          playerdead = true;
        //          Debug.Log("collided");

        //      }
        //  }

    }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class destroy_ball : NetworkBehaviour
{
    [SyncVar]
    // Start is called before the first frame update
   public bool hitball = false;

    // Start is called before the first frame update

    private void Update()
    {
        DestroyBlock();
    }
   // [ClientRpc]
    private void DestroyBlock()
    {
        if (hitball == true)
        {
          //  print("hitball");
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBall") && hitball == false)
        {
            hitball = true;
          //  print("hitball");
           
            
        }
    }

   
}

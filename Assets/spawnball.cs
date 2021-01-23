using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnball : NetworkBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;


    private void Start()
    {
       
        rb2d = GetComponent<Rigidbody2D>();
        
       
    }
    private void Update()
    {
       
    }
    // Update is called once per frame
    


}

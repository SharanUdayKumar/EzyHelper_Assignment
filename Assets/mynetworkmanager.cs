using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class mynetworkmanager : NetworkManager
{
    [SerializeField]
    GameObject player1_ball;
    [SerializeField]
    GameObject player2_ball;

    [SerializeField]
    Transform player_ball_spawn;

    bool player1connected = false;
    bool player2connected = false;

    [SerializeField]
    public int i = 0;
    // Start is called before the first frame update
    public override void OnClientConnect(NetworkConnection conn)
    {
        print("clientconnect");
        base.OnClientConnect(conn);
       // i++;
    }

    private void Update()
    {



        if(i == 1 && player1connected == false)
        {
            player1_ball.transform.position = player_ball_spawn.transform.position;
            player1connected = true;
        }
        else if ( i == 2 && player2connected == false)
        {
            player2_ball.transform.position = player_ball_spawn.transform.position;
            player2connected = true;
        }

    }
}

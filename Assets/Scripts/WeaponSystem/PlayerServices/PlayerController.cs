using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController 
{
    PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        playerView.SetControllerReference(this);
    }

    public void UpdatePlayerController()
    {
        
    }
}

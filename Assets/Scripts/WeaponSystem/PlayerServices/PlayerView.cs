using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerController controller;

    public void SetControllerReference(PlayerController controller)
    {
        this.controller = controller;
    }
    
    void Update()
    {
        if(controller != null)
        {
            controller.UpdatePlayerController();
        }
    }
}

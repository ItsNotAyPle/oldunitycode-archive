using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    PlayerAnimationHandler instance;

    [SerializeField] private Animation player_idle_anim;

    private void Awake()
    {
        if (this != instance && instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    public void PlayerIdleAnimation()
    { 
        player_idle_anim.Play();
    }


}

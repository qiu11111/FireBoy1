using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoyAirState : IState
{
    private FireBoy fireBoy;
    public FireBoyAirState(FireBoy fireBoy)
    {
        this.fireBoy = fireBoy;
    }
    public void onEnter()
    {
        fireBoy.isAir = true;
        fireBoy.HeadAnim.SetBool("jump", true);
        fireBoy.LegAnim.SetBool("jump", true);
    }

    public void onExit()
    {
        fireBoy.isAir = false;
        fireBoy.HeadAnim.SetBool("jump", false);
        fireBoy.LegAnim.SetBool("jump", false);
    }

    public void onFixedUpdate()
    {
        fireBoy.move1();
    }

    public void onUpdate()
    {
        if (fireBoy.groundCheck())
            fireBoy.tranState(FireBoyStateType.Idle);
    }

    public string returnName()
    {
        return "air";
    }
}

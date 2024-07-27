using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoyIdleState : IState
{
    private FireBoy fireBoy;
    public FireBoyIdleState(FireBoy fireBoy)
    {
        this.fireBoy = fireBoy;
    }
    public void onEnter()
    {
        fireBoy.rd.velocity = Vector2.zero;
        fireBoy.HeadAnim.SetBool("idle", true);
        fireBoy.LegAnim.SetBool("idle",true);
    }

    public void onExit()
    {
        fireBoy.isIdle = false;
        fireBoy.HeadAnim.SetBool("idle", false);
        fireBoy.LegAnim.SetBool("idle", false);
    }

    public void onFixedUpdate()
    {
       
    }

    public void onUpdate()
    {
        fireBoy.rd.velocity = new Vector2(0, fireBoy.rd.velocity.y);
        if (fireBoy.isMove)
            fireBoy.tranState(FireBoyStateType.Move);
        if (fireBoy.isJump)
            fireBoy.tranState(FireBoyStateType.Jump);
        if (!fireBoy.groundCheck())
            fireBoy.tranState(FireBoyStateType.Air);

    }

    public string returnName()
    {
        return "idle";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoyMoveState : IState
{
    private FireBoy fireBoy;
    public FireBoyMoveState(FireBoy fireBoy)
    {
        this.fireBoy = fireBoy;
    }
    public void onEnter()
    {
        fireBoy.HeadAnim.SetBool("move", true);
        fireBoy.LegAnim.SetBool("move", true);
    }

    public void onExit()
    {
        fireBoy.HeadAnim.SetBool("move", false);
        fireBoy.LegAnim.SetBool("move", false);
    }

    public void onFixedUpdate()
    {
        fireBoy.move1();
    }

    public void onUpdate()
    {
        if (!fireBoy.isMove)
        {
            fireBoy.tranState(FireBoyStateType.Idle);
        }
        if (fireBoy.isJump)
            fireBoy.tranState(FireBoyStateType.Jump);
        if (!fireBoy.groundCheck())
            fireBoy.tranState(FireBoyStateType.Air);
        if (fireBoy.isIdle)
            fireBoy.tranState(FireBoyStateType.Idle);
    }

    public string returnName()
    {
        return "move";
    }
}

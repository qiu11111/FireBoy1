using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoyJumpState : IState
{
    private FireBoy fireBoy;
    public FireBoyJumpState(FireBoy fireBoy)
    {
        this.fireBoy = fireBoy;
    }
    public void onEnter()
    {
        fireBoy.rd.AddForce(Vector2.up * fireBoy.jumpForce, ForceMode2D.Impulse);
        fireBoy.HeadAnim.SetBool("jump", true);
        fireBoy.LegAnim.SetBool("jump", true);
    }

    public void onExit()
    {
        fireBoy.isJump = false;
        fireBoy.HeadAnim.SetBool("jump", false) ;
        fireBoy.LegAnim.SetBool("jump", false);
    }

    public void onFixedUpdate()
    {
        fireBoy.move1();
    }

    public void onUpdate()
    {
        if (fireBoy.rd.velocity.y <= 0)
            fireBoy.tranState(FireBoyStateType.Air);
    }

    public string returnName()
    {
        return "jump";
    }
}

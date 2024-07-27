using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public FireBoy fireBoy;
    public int FireBoyScore;
    public int IceGirlScore;


    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }
    public void FireBoyGetScore()
    {
        FireBoyScore++;
    }
    public void IceGirlGetScore()
    {
        IceGirlScore++;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public TextMeshProUGUI textMeshDown;
    public TextMeshProUGUI textMeshUp;
    private void Awake()
    {
        textMeshUp.text = "FireBoyScore:"+ScoreManager.instance.FireBoyScore;
        textMeshDown.text = "IceGirlScore:" + ScoreManager.instance.IceGirlScore;
    }
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    private int FadeTo;
    public Animator anim;
    public void FadeOutTo(int ID)
    {
        FadeTo = ID;
        anim.SetTrigger("FadeOutTrigger");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(FadeTo);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

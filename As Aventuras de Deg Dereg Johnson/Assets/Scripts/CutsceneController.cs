using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : StateMachineBehaviour
{
    private void OnStateExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

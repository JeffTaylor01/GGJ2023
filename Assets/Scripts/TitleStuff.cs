using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleStuff : MonoBehaviour, IAudible
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PlaySoundEffect(AudioSource soundEffectSource)
    {
        throw new System.NotImplementedException();
    }
        
}

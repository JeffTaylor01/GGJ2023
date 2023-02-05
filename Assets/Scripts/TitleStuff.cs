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
    public void PlaySoundEffect(AudioSource soundEffectSource)
    {
        throw new System.NotImplementedException();
    }
        
}

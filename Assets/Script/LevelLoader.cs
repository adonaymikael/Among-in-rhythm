using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Loader(int levelIndex){
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

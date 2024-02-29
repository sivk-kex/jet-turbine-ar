using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; 
using UnityEngine.SceneManagement;
  

public class sceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName) ;
    }
}

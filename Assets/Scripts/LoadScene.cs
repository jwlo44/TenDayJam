using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneAsset SceneToLoad;

    public void LoadTargetScene()
    {
        Debug.Log("loading scene " + SceneToLoad.name);
        SceneManager.LoadSceneAsync(SceneToLoad.name);
    }
}
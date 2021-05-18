using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _sceneIndexToLoad;
    
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(_sceneIndexToLoad, LoadSceneMode.Single);
    }
}

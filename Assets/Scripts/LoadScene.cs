using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneAsset SceneToLoad;

    public void LoadTargetScene()
    {
        SceneManager.LoadSceneAsync(SceneToLoad.name);
    }
}

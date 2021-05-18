using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Scene SceneToLoad;

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(SceneToLoad.name);
    }
}

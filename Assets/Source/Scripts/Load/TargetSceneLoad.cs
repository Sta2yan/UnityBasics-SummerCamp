using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSceneLoad : MonoBehaviour
{
    public void Change(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

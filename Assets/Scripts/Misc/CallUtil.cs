using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CallUtil : MonoBehaviour
{
    [SerializeField] private UnityEvent Event;
    
    private string SceneToLoad;

    public void Call()
    {
        Event.Invoke();
    }

    public void SetSceneToLoad(string scene)
    {
        SceneToLoad = scene;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(SceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

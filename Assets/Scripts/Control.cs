using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Control : MonoBehaviour
{
    public int sceneNumber;
    public void NextScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
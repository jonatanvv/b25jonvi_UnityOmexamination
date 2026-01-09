using UnityEngine;
using UnityEngine.SceneManagement; // Required to load scenes

public class ButtonSceneLoader : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void LoadHuvudscen()
    {
        SceneManager.LoadScene("Huvudscen");
    }
}

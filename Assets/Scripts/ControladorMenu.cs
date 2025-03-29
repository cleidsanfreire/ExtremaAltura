using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
        Time.timeScale = 1.0f;
    }

    public void AbrirRanking()
    {

    }

    public void RemoverAnuncios()
    {

    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    //a cargar escenas
    public void SceneController(int level)
    {

        SceneManager.LoadScene(level);
    
    }
    //Cerrar aplicacion
    public void Salir() {
    
        Application.Quit();
    
    }

}

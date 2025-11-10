using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("Gestor de tiempos para agregar solamente el tiempo requerido el tiempo de recarga de nivel y el texto a contador")]
    [Header("Gestion de tiempo")]
    public float CountDown = 5;
    private float tiempoRestante;
    public bool tiempoTerminado = true;
    public TextMeshProUGUI timer;
    public int levelIndex;
    public float timeEx = 0.5f;

    [Header("Gestion de vidas")]
    public int maxLives = 3;
    private int vidasRestantes;
    public Image[] vidas;
    public static GameManager instance;
    #region principales
    void Awake(){
        
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        tiempoRestante = CountDown;
        UpdateTime();
    }

    void Update()
    {
        if (tiempoTerminado)
        {
            tiempoRestante -= Time.deltaTime;
            //esto redondea los decimales
            int temporizador = Mathf.CeilToInt(tiempoRestante);
            timer.text = temporizador.ToString();

            if (tiempoRestante <= 0)
            {
                tiempoTerminado = false;
                tiempoRestante = 0;
                timer.text = "0";
                StartCoroutine(ChangeLevel(levelIndex));
            }
        }
    }
    #endregion
    #region timer
    //necesito que cambie de color cuando este este cerca de llegar a cero y si llega a cero ponle un color rojito
    /*aqui 
     van
    varias 
    lineas para 
    peticiones*/
    void UpdateTime()
    {

        timer.text = Mathf.CeilToInt(tiempoRestante).ToString();

    }
    #endregion
    #region Gestor de vidas 
    public void PlayerHit(){
       // if (vidasRestantes <= 0) return;
        vidasRestantes--;
        UpdateLivesUI();

        if (vidasRestantes <= 0){
            GameOver();
        }
    }

    void UpdateLivesUI(){
        for (int i = 0; i < vidas.Length; i++){
            vidas[i].enabled = i < vidasRestantes;
        }
    }

    void GameOver(){
        StartCoroutine(ChangeLevel(levelIndex));

    }
    #endregion
    #region controldenivel
    IEnumerator ChangeLevel(int levelIndex)
    {
        yield return new WaitForSeconds(timeEx);
        SceneManager.LoadScene(levelIndex);
    }
    #endregion
}

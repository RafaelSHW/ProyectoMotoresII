using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float CountDown = 5;
    private float tiempoRestante;
    public bool tiempoTerminado = true;
    public TextMeshProUGUI timer;
    public int levelIndex;
    public float timeEx = 0.5f;

    public int nextLevelIndex = 2;

    public int maxLives = 3;
    private int vidasRestantes;
    public Image[] vidas;
    public static GameManager instance;

    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        tiempoRestante = CountDown;
        UpdateTime();

        vidasRestantes = maxLives;
        UpdateLivesUI();

        Time.timeScale = 1f;
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (tiempoTerminado && !isPaused)
        {
            tiempoRestante -= Time.deltaTime;
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

    void UpdateTime()
    {
        timer.text = Mathf.CeilToInt(tiempoRestante).ToString();
    }

    public void PlayerHit(KillBox killer = null)
    {
        vidasRestantes--;
        UpdateLivesUI();

        if (vidasRestantes <= 0)
        {
            GameOver(killer);
        }
        else if (killer != null)
        {
            killer.RespawnWithoutDeathAnim();
        }
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < vidas.Length; i++)
        {
            if (vidas[i] != null)
            {
                vidas[i].enabled = i < vidasRestantes;
            }
        }
    }

    void GameOver(KillBox killer)
    {
        if (killer != null)
        {
            StartCoroutine(killer.Dead());
        }
    }

    public void LevelWin()
    {
        tiempoTerminado = false;
        StartCoroutine(ChangeLevel(nextLevelIndex));
    }

    IEnumerator ChangeLevel(int levelIndex)
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(timeEx);
        SceneManager.LoadScene(levelIndex);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }
}
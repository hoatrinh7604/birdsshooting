using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] GameObject gameOver;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI prisoner;
    [SerializeField] TextMeshProUGUI robber;

    [SerializeField] SpawController spawController;
    int score = 0;
    int sliderValue = 0;

    private float time;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > 30)
        {
            spawController.UpdateSpeed();
            time = 0;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void UpdateScore(int value)
    {
        score += value;
        prisoner.text = score + "";
        robber.text = score + "";
    }

    public void UpdateSlider(int value)
    {
        sliderValue += value;
        slider.value = sliderValue;

        CheckGameState();
    }

    public void Restart()
    {
        GetComponent<SceneController>().StartGame();
    }

    public void CheckGameState()
    {
        if(sliderValue >= slider.maxValue)
        {
            GameOver();
        }
    }

    public void Reset()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);
        sliderValue = 0;
        score = 0;
        slider.value = sliderValue;
        prisoner.text = score + "";
        robber.text = score + "";
    }
}

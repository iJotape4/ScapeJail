using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    #region Private Properties

     
    int _coinCount=0;
    [SerializeField] int livesCount = 2;
    [SerializeField] int EnergyCount = 2;
    int _scoreCount=0;
    int _currentLevel=0;
    bool _isGameOver=false;
    public bool IsGameOver { get => _isGameOver; }
    bool _isPaused=false  ;

   

    #endregion

    #region Player
    PlayerController2D player = new PlayerController2D();
    #endregion
    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this.GetComponent<GameManager>();

        }
        else if (GameManager.Instance != null &&  GameManager.Instance != this) { 
            Destroy(gameObject);
            return;
           
        }
        DontDestroyOnLoad(this);
       

    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdateLives(livesCount);
        EnergyCount = 2;
        livesCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin() {
        _coinCount++;
    }

    public void Updatelives(int lives)
    {

        if (EnergyCount > 0)
        {
            EnergyCount += lives;
            UIManager.Instance.UpdateEnergy();
            return;
        }
        else
            livesCount += lives;
        UIManager.Instance.UpdateLives(livesCount);
        EnergyCount = 2;
        if (livesCount < 0)
        {
            _isGameOver = true;
            UIManager.Instance.ShowGameOver();
            Time.timeScale = 0;
        }
        else 
            {
            SceneManager.LoadScene(0);
        }
    }

    public void RestartGame()
    {
        Start();
        _isGameOver = false;
        Time.timeScale = 1;
        UIManager.Instance.Start();
        SceneManager.LoadScene(0);
    }

}

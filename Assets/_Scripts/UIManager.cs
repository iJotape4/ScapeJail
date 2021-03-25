using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    #region Inspector Properties
    [SerializeField] Button playAgainButton;
    [SerializeField] Text gameOverText;
    [SerializeField] TMPro.TMP_Text livesText;
    [SerializeField] Image Cora1;
    [SerializeField] Image Cora2;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject TutIcon1;
    #endregion

    private void Awake()
    {
        if (UIManager.Instance == null)
        {
            UIManager.Instance = this.GetComponent<UIManager>();

        }
        else if (UIManager.Instance != null && UIManager.Instance != this)
        {
            Destroy(gameObject);
            return;

        }
        DontDestroyOnLoad(this);

        pausePanel = GameObject.Find("PausePanel"); pausePanel.SetActive(false);
       
    }

    // Start is called before the first frame update
    public void Start()
    {
        gameOverText.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
        

    }


    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
            Pause();    
    }
     
    public void UpdateLives(int lives)
    {

        if (lives < 0)
        {
            livesText.text = "";
            return;
        }
        livesText.text ="x"+lives;
        Cora1.enabled = true;
        Cora2.enabled = true;    
    }

    public void UpdateEnergy()
    {
        if (Cora1.IsActive()) {
            Cora1.enabled = false;
        }
        else if (!Cora2.IsActive())
        {
            Cora1.enabled = true;
            Cora2.enabled = true;
        }
        else
        {
            Cora2.enabled = false;
        }
              
       
    }

    public void Pause()
    {
        if (pausePanel.activeSelf)
            pausePanel.SetActive(false);        
        else
            pausePanel.SetActive(true);

        Time.timeScale = (pausePanel.activeSelf) ? 0 : 1;
    }

    public void ActivateTutIcon(string IconName)
    {
        
        TutIcon1.gameObject.SetActive(true);
    }

    public void DesactivateTutIcon(string IconName)
    {
        
        TutIcon1.gameObject.SetActive(false);
    }
}

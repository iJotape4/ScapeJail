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
        
    }
     
    public void UpdateLives(int lives)
    {

        if (lives < 0)
        {
            livesText.text = "";
            return;
        }
        livesText.text ="x "+lives;
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
}

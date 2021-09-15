using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    //handling the menu flow / determining which menu objects are set active or inactive
    //could maybe be cleaned up
    
    public GameObject HowToPlayPanel;
    public GameObject OptionsMenu;
    public GameObject CreditsPanel;
    public GameObject MainMenuBG;
    public GameObject OptionsMenuBG;
    public GameObject[] LoadingScreens = new GameObject[3];
    
    public GameObject MainMenuScreen;
    
    GameObject ActivePanel;
    
    public void Play(){
        
        if(PlayerPrefs.GetInt("hasSeenTutorial", 0) == 0){
            Debug.Log("load tutorial");
            PlayerPrefs.SetInt("hasSeenTutorial", 1);
            SceneManager.LoadScene("Tutorial");
        }else{
            Debug.Log("Load game");
            int loadingScreenChoice = Random.Range(0,3);
            LoadingScreens[loadingScreenChoice].SetActive(true);
            SceneManager.LoadScene("Gameplay");
        }
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            PlayerPrefs.SetInt("hasSeenTutorial", 0);
        }
    }
    
    [SerializeField] private string mainMenuScene;
    public void GoToMenu(string mainMenuScene){
        SceneManager.LoadScene(mainMenuScene);
    }

    public void HowToPlay(){
        HowToPlayPanel.SetActive(true);
        ActivePanel = HowToPlayPanel;
    }
    
    public void Options(){
        MainMenuScreen.SetActive(false);
        MainMenuBG.SetActive(false);
        
        OptionsMenu.SetActive(true);
        OptionsMenuBG.SetActive(true);
        ActivePanel = OptionsMenu;
    }

    public void Credits(){
        CreditsPanel.SetActive(true);
        ActivePanel = CreditsPanel;
    }
    
    public void ClosePanel(){
        ActivePanel.SetActive(false);
        OptionsMenuBG.SetActive(false);
        MainMenuScreen.SetActive(true);
        MainMenuBG.SetActive(true);
    }
    
    public void ExitGame(){
        Application.Quit();
    }
}

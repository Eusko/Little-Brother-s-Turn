using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialScreen;
    
    public GameObject backButton;
    public GameObject nextButton;
    public GameObject finishButton;

    public GameObject[] LoadingScreens = new GameObject[3];

    public void OnNextButtonClick(){
        for(int i = 0; i < tutorialScreen.Length; i++){
            if(tutorialScreen[i].activeInHierarchy){
                if(i == 3){
                    nextButton.SetActive(false);
                    finishButton.SetActive(true);
                }
                if(i == 0){
                    backButton.SetActive(true);
                }
                tutorialScreen[i].SetActive(false);
                tutorialScreen[i+1].SetActive(true);
                break;
            }
        }
    }

    public void OnBackButtonClick(){
        for(int i = 0; i < tutorialScreen.Length; i++){
            if(tutorialScreen[i].activeInHierarchy){
                if(i == 1){
                    backButton.SetActive(false);
                }
                if(i == 4){
                    finishButton.SetActive(false);
                    nextButton.SetActive(true);
                }
                tutorialScreen[i].SetActive(false);
                tutorialScreen[i-1].SetActive(true);
            }
        }
    }

    [SerializeField]
    private string gameplayScene;
    public void OnFinishButtonClick(string gameplayScene){
        int loadingScreenChoice = Random.Range(0,3);
            LoadingScreens[loadingScreenChoice].SetActive(true);
            SceneManager.LoadScene(gameplayScene);
    }
}

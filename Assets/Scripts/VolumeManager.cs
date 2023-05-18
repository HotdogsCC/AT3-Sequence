using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeManager : MonoBehaviour
{
    public static float musicVolume = 1f; //Stores music volume
    public static float cardSFXVolume = 1f; //Stores card SFX volume
    public static float tokenSFXVolume = 1f; //Stores token SFX volume

    [SerializeField] private GameObject settings; //Initalises settings overlay screen

    [SerializeField] private AudioSource musicSource; //Plays the music
    [SerializeField] private List<AudioSource> cardSources; //Plays the card sound
    [SerializeField] private AudioSource tokenSource; //Plays the token sound

    [SerializeField] private Slider musicSlider; //Controls how loud the music is
    [SerializeField] private Slider cardSlider; //Controls how loud the cards are
    [SerializeField] private Slider tokenSlider; //Controls how loud the tokens are

    private Scene gameScene; //Stores which scene is the game scene


    private void Start()
    {
        gameScene = SceneManager.GetSceneByBuildIndex(1); //Sets the game scene

        musicSource.volume = musicVolume; //Sets the music volume

        if(SceneManager.GetActiveScene() == gameScene) //Checks that it is the game scene
        {
            tokenSource.volume = tokenSFXVolume; //Sets token volume

            foreach (var card in cardSources) //Sets card volume
            {
                card.volume = cardSFXVolume;
            }
        }
        
    }

    public void OpenSettings()
    {
        //Sets each slider at the correct value and displays the settings overlay
        musicSlider.value = musicVolume;
        cardSlider.value = cardSFXVolume;
        tokenSlider.value = tokenSFXVolume;
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        //Closes the settings overlay
        settings.SetActive(false);
    }

    public void ChangeMusicValue()
    {
        //Saves and sets the music volume
        musicVolume = musicSlider.value;
        musicSource.volume = musicVolume;
    }

    public void ChangeCardValue()
    {
        //Saves the card volume
        cardSFXVolume = cardSlider.value;

        //Checks that it is in the game scene
        if (SceneManager.GetActiveScene() == gameScene)
        {
            //Sets the card volume
            foreach (var card in cardSources)
            {
                card.volume = cardSFXVolume;
            }
        }

    }

    public void ChangeTokenValue()
    {
        //Saves the music volume
        tokenSFXVolume = tokenSlider.value;

        //Checls thaty it is the game scene
        if (SceneManager.GetActiveScene() == gameScene)
        {
            //Sets the token volume
            tokenSource.volume = tokenSFXVolume;
        }
            
    }
}

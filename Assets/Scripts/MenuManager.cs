using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider fov;
    public Slider game;
    public Slider music;

    public GameObject settings;
    public GameObject main;

    private void Start()
    {
        main.SetActive(true);
        settings.SetActive(false);

        fov.value = 90;
        game.value = 100;
        music.value = 100;
    }

    public void Play()
    {
        PlayerPrefs.SetFloat("fov", fov.value);
        PlayerPrefs.SetFloat("gameVol", game.value);
        PlayerPrefs.SetFloat("musicVol", music.value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
        main.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        main.SetActive(true);
        settings.SetActive(false);
    }
}

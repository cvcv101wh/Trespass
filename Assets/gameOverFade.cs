﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverFade : MonoBehaviour {

    private float _fadeDuration = 2f;

    private void Start()
    {
        FadeToWhite();
        Invoke("FadeFromWhite", _fadeDuration);
    }
    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, _fadeDuration);
    }
    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, _fadeDuration);
    }

}

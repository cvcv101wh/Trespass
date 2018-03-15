using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

    public GameObject allScene;
    public GameObject revivePlace;
    public GameObject guard;
   // public Texture2D fadeTexture;
   // public float fadeSpeed = 0.2f;
    //public int drawDepth = -1000;
    public bool isFadingOut = false;
    public bool isFadingIn = false;
   // private float alpha = 0.0f;
  //  private float fadeDir = 1;
    public float duration = 2;
    void OnGUI()
    {

        if (isFadingOut)
        {
            /*
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            Debug.Log(thisAlpha.a);
            */

            SteamVR_Fade.Start(Color.white, duration);

            duration -= Time.deltaTime;

        }

        if (isFadingIn)
        {
            /*
            alpha -= fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            Debug.Log(thisAlpha.a);
            */
            SteamVR_Fade.Start(new Color(0,0,0,0), duration);
        }

    }
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        //alpha -= fadeDir * fadeSpeed * Time.deltaTime;





        if (duration <= 0)
        {
            duration = 2;
            guard.GetComponent<guardPatrol>().destPoint = 0;
            guard.SetActive(false);
            
            isFadingOut = false;

            allScene.SetActive(false);

            revivePlace.SetActive(true);
        
            isFadingIn = true;


        }
    }
}

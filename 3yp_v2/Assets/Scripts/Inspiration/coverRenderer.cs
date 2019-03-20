using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coverRenderer : MonoBehaviour
{
    public float ftimeOut = 0.2f;
    public float ftimeIn = 0.2f;

    private float time;

    private Renderer[] cubesCover; //array for all the cubes forming the cover
    private enum coverState { fIn, fOut, none}//enum to track the state of effect
    private coverState state; //current state

    // Start is called before the first frame update
    void Start()
    {
        cubesCover = GetComponentsInChildren<Renderer>();
        SetAlpha(0);
        state = coverState.none;
    }

    //true = in the middle of animation
    public bool isAnimating()
    {
        return state != coverState.none;
    }

    //starts the fade out routine if not in middle of coroutine
    public void StartFout()
    {
        if (state == coverState.none)
        {
            state = coverState.fOut;
            StartCoroutine(FadeOut());
        }
    }

    //starts the fade in routine if not in middle of coroutine
    public void StartFin()
    {
        if (state == coverState.none)
        {
            state = coverState.fIn;
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        time = 0f;
        while(time< ftimeIn)
        {
            Fade(0, 1, ftimeIn);
            yield return null;
        }

        state = coverState.none;
    }

    private IEnumerator FadeOut()
    {
        time = 0f;
        while (time < ftimeOut)
        {
            Fade(0, 1, ftimeOut);
            yield return null;
        }

        state = coverState.none;
    }

    private void Fade(float start, float end, float fTime)
    {
        time += Time.deltaTime;
        float alpha = Mathf.Lerp(start, end, time / fTime);
        SetAlpha(alpha);
    }

    private void SetAlpha(float alpha)
    {
        foreach(Renderer coverR in cubesCover)
        {
            Color color = coverR.material.color;
            color.a = alpha;
            coverR.material.color = color;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

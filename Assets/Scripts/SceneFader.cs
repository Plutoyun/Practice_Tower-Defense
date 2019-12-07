using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() // Load scenes with gradient effect
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(66 / 255f, 191 / 255f, 189 / 255f, a);
            yield return 0;
        }
    }

        IEnumerator FadeOut(string scene) //Exit scenes with gradient effect which reverse FadeIn effect
    {
            float t = 0f;
            while(t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                img.color = new Color(66 / 255f, 191 / 255f, 189 / 255f, a);
                yield return 0;
            }

        SceneManager.LoadScene(scene);
        }
    
}

using UnityEngine;
using System.Collections;

public class ButtonAnimation : MonoBehaviour
{
    public float minScale = 0.8f;
    public float maxScale = 1.2f;
    public float animationTime = 0.5f;

    private void Start()
    {
        StartCoroutine(AnimateButton());
    }

    private IEnumerator AnimateButton()
    {
        while (true)
        {
            yield return StartCoroutine(AnimateScale(minScale, maxScale, animationTime));
            yield return StartCoroutine(AnimateScale(maxScale, minScale, animationTime));
        }
    }

    private IEnumerator AnimateScale(float startScale, float endScale, float time)
    {
        float timer = 0f;
        while (timer <= time)
        {
            float scale = Mathf.Lerp(startScale, endScale, timer / time);
            transform.localScale = new Vector3(scale, scale, 1f);

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(endScale, endScale, 1f);
    }
}
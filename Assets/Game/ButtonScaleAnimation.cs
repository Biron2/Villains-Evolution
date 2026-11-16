using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonScaleAnimation : MonoBehaviour
{
    private Vector3 defaultScale;
    [SerializeField] private float scaleDuration = 0.1f;
    [SerializeField] private float scaleAmount = 0.9f;
    public UnityEvent events;
    private Button btn;
    void Start()
    {
        defaultScale = transform.localScale;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => StartCoroutine(ScaleButton()));
    }
    private IEnumerator ScaleButton()
    {
        float timer = 0f;
        while (timer < scaleDuration)
        {
            float scale = Mathf.Lerp(1f, scaleAmount, timer / scaleDuration);
            transform.localScale = defaultScale * scale;

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = defaultScale * scaleAmount;

        // Восстанавливаем кнопку
        timer = 0f;
        while (timer < scaleDuration)
        {
            float scale = Mathf.Lerp(scaleAmount, 1f, timer / scaleDuration);
            transform.localScale = defaultScale * scale;

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = defaultScale;
        events.Invoke();
    }
}

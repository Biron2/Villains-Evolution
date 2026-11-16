using System.Collections;
using UnityEngine;
using YG;

public class computer_press : MonoBehaviour
{
    [SerializeField] private Manager _Manager;

    private Vector3 defaultScale;
    [SerializeField] private float scaleDuration = 0.1f;
    [SerializeField] private float scaleAmount = 0.9f;
    [SerializeField] private AudioSource clickSnd;
    private void Start()
    {
        defaultScale = transform.localScale;
    }
    private void OnMouseDown()
    {
        if (TimerBeforeAdsYG.allowClicks == true)
        {
            switch (YandexGame.savesData.current_comp)
            {
                case 1:
                    _Manager.ProgressUp(2f);
                    break;
                case 2:
                    _Manager.ProgressUp(1f);
                    break;
                case 3:
                    _Manager.ProgressUp(0.5f);
                    break;
                case 4:
                    _Manager.ProgressUp(0.45f);
                    break;
                case 5:
                    _Manager.ProgressUp(0.4f);
                    break;
                case 6:
                    _Manager.ProgressUp(0.35f);
                    break;
                case 7:
                    _Manager.ProgressUp(0.3f);
                    break;
                case 8:
                    _Manager.ProgressUp(0.25f);
                    break;
                case 9:
                    _Manager.ProgressUp(0.20f);
                    break;
                case 10:
                    _Manager.ProgressUp(0.175f);
                    break;
                case 11:
                    _Manager.ProgressUp(0.150f);
                    break;
                case 12:
                    _Manager.ProgressUp(0.1f);
                    break;
                case 13:
                    _Manager.ProgressUp(0.075f);
                    break;
                case 14:
                    _Manager.ProgressUp(0.05f);
                    break;
                case 15:
                    _Manager.ProgressUp(0.025f);
                    break;
                case 16:
                    _Manager.ProgressUp(0.01f);
                    break;
                case 17:
                    _Manager.ProgressUp(0.005f);
                    break;
            }
            clickSnd.PlayOneShot(clickSnd.clip);
            _Manager.UpdateTextCounter();
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ScaleButton());
            }
        }
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
    }
}

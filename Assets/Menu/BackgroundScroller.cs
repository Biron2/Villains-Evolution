using UnityEngine;
using UnityEngine.UI;

public class ImageScroller : MonoBehaviour
{
    [Range(1f, 5f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        rawImage.uvRect = new Rect(offset, 0, rawImage.uvRect.width, rawImage.uvRect.height);
    }
}
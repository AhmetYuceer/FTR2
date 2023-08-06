using UnityEngine;
using UnityEngine.UI;
public class Values : MonoBehaviour
{
    public static float value;
    [SerializeField] private RawImage image;
    private Vector2 imageDefaultSize;
    private Vector2 imageCurrentSize;
    [SerializeField] private float currentValue;
    private float rateValue;
    private void Start() 
    {
        imageDefaultSize = image.rectTransform.sizeDelta;
        rateValue = imageDefaultSize.y / currentValue;
    }
    private void Update() 
    {
        image.rectTransform.sizeDelta = imageCurrentSize;
        imageCurrentSize = new Vector2(imageDefaultSize.x, rateValue * value);
    }
}
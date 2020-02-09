using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Image BarImage;

    public void SetProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);
        var scale = BarImage.rectTransform.localScale;
        scale.x = progress;
        BarImage.rectTransform.localScale = scale;
    }
}

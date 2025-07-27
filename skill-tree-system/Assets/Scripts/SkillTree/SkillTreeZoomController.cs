using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeZoomController : MonoBehaviour
{
    [SerializeField] private RectTransform content;

    [Header("ズーム設定")]
    [SerializeField] private float zoomSpeed = 0.1f;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2.0f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 scale = content.localScale;
            float newScale = Mathf.Clamp(scale.x + scroll * zoomSpeed, minScale, maxScale);
            content.localScale = new Vector3(newScale, newScale, 1);
        }
    }
}

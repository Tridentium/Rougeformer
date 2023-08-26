using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;

    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    DG.Tweening.Sequence moveSequence;

    private void Awake()
    {
        DOTween.Init();
        moveSequence = DOTween.Sequence();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, Color colour, string header = "")
    {

        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
        }

        contentField.text = content;
        headerField.text = header;
        this.GetComponent<Image>().color = colour;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = Mathf.Max(headerField.preferredWidth, contentField.preferredWidth) >= layoutElement.preferredWidth;
        }

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;


        float finalPivotX = 0f;
        float finalPivotY = 0f;



        if (pivotX < 0.5) //If mouse on left of screen move tooltip to right of cursor and vice vera
        {
            finalPivotX = -0.1f;
        }

        else
        {
            finalPivotX = 1.01f;
        }



        if (pivotY < 0.5) //If mouse on lower half of screen move tooltip above cursor and vice versa
        {
            finalPivotY = 0;
        }

        else
        {
            finalPivotY = 1;
        }


        Vector2 finalPivot = new Vector2(finalPivotX, finalPivotY);

        if (rectTransform.pivot != finalPivot)
        {
            moveSequence.Kill();

            moveSequence = DOTween.Sequence()
            .Join(DOTween.To(() => rectTransform.pivot, x => rectTransform.pivot = x, new Vector2(finalPivotX, finalPivotY), .5f))
            .Join(DOTween.To(() => rectTransform.pivot, y => rectTransform.pivot = y, new Vector2(finalPivotX, finalPivotY), 1f))
            .SetRelative(false)
            .Play();
        }


        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;

    public Tooltip tooltip;

    public void Awake()
    {
        current = this;
    }

    public static void Show(string content, Color colour, string header = "")
    {
        current.tooltip.SetText(content, colour, header);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        if(current.tooltip.gameObject != null)
            current.tooltip.gameObject.SetActive(false);
    }
}


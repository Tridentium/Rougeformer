using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static LTDescr delay;
    public string header;
    public SlotTooltip slotTooltip;

    [Multiline()]
    public string content;

    private void Start()
    {
        slotTooltip = GetComponent<SlotTooltip>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        delay = LeanTween.delayedCall(0.5f, () =>
        {   
            TooltipSystem.Show(content,slotTooltip.tooltipColour, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }

}

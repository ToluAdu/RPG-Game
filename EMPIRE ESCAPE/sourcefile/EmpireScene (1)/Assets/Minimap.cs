using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Round;

    public void OnValidate()
    {
        mRectBorder = GetComponent<Image>();
        mRoundBorder = transform.Find("MinimapBorder").GetComponent<Image>();
        mMapMask = transform.Find("MinimapMask").GetComponent<Image>();

        mRectBorder.enabled = !Round;
        mMapMask.enabled = Round;
        mRoundBorder.enabled = Round;
    }

    private Image mRectBorder;
    private Image mRoundBorder;
    private Image mMapMask;
}


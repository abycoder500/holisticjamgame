using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleDisplayer : DisplayModule
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    public override void Display(string subtitle)
    {
        _textMesh.text = subtitle;
    }
}

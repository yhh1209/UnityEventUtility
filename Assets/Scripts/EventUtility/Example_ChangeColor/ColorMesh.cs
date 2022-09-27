using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class ColorMesh : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _mesh;
    [SerializeField]
    private MaterialPropertyBlock _matBlock;
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _matBlock = new MaterialPropertyBlock();
        _mesh.GetPropertyBlock(_matBlock);
        EventManager.AddListener<Color>(EventType.ChangeColor, ChangeColor);
    }

    private void ChangeColor(Color color)
    {
        _matBlock.SetColor("_Color", color);
        _mesh.SetPropertyBlock(_matBlock);
    }

    private void OnDestroy()
    {
        EventManager.RemoveListener<Color>(EventType.ChangeColor, ChangeColor);
    }
}

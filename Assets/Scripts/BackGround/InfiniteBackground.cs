using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteBackground : MonoBehaviour
{
    private MeshRenderer _renderer;
    [SerializeField] private float _speed;
    private float _offset;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _offset += Time.deltaTime * _speed;
        _renderer.material.mainTextureOffset = new Vector2(0, _offset);
    }
}

using UnityEngine;

public class BlendshapeController : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float _value = 0f;

    private float _previousValue = -1f;

    [SerializeField]
    private SkinnedMeshRenderer _meshRenderer = null;
    private Mesh _mesh = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mesh = _meshRenderer.sharedMesh;   
    }

    // Update is called once per frame
    void Update()
    {
        if(_previousValue != _value)
        {
            UpdateValue();
        }
    }

    private void UpdateValue()
    {
        _previousValue = _value;

        if(_meshRenderer == null || _mesh == null)
        {
            return;
        }

        for(int i = 0; i < _mesh.blendShapeCount; ++i)
        {
            _meshRenderer.SetBlendShapeWeight(i, _value * 100);
        }
    }
}

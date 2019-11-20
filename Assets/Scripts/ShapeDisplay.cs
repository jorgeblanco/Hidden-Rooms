using UnityEngine;

public class ShapeDisplay : MonoBehaviour
{
    [SerializeField] private Renderer display;
    [SerializeField] private Material[] shapes;

    private int _currentShapeIndex;
    private int _shapeCount;

    private void Start()
    {
        _shapeCount = shapes.Length;
        display.sharedMaterial = shapes[_currentShapeIndex];
    }

    public void NextShape()
    {
        _currentShapeIndex = (_currentShapeIndex + 1) % _shapeCount;
        display.sharedMaterial = shapes[_currentShapeIndex];
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DisplayValidator : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] displays;
    [SerializeField] private Material[] validShapes;
    [SerializeField] private UnityEvent valid;

    private void Start()
    {
        StartCoroutine(ShapeValidator());
    }

    private IEnumerator ShapeValidator()
    {
        while (true)
        {
            var isValid = true;
            for (var i = 0; i < displays.Length; i++)
            {
                if (displays[i].sharedMaterial != validShapes[i])
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                OnShapesValid();
                yield break;
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnShapesValid()
    {
        valid.Invoke();
        Debug.Log("You solved the puzzle!");
    }
}

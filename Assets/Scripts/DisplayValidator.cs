using System.Collections;
using UnityEngine;

public class DisplayValidator : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] displays;
    [SerializeField] private Material[] validShapes;

    private AudioSource _audioSource;

    private void Start()
    {
        StartCoroutine(ShapeValidator());
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.Play();
        Debug.Log("You solved the puzzle!");
    }
}

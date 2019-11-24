using System.Collections;
using UnityEngine;

public class WinSequence : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDisable;
    [SerializeField] private GameObject[] objectsToEnable;
    
    public void Win()
    {
        StartCoroutine(WinDelay());
    }

    private IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(5);
        
        foreach (var o in objectsToDisable)
        {
            o.SetActive(false);
        }
        foreach (var o in objectsToEnable)
        {
            o.SetActive(true);
        }
        Debug.Log("You Win!");
    }
}

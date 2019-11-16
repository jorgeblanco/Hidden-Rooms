using UnityEngine;

public class SizePointActivator : MonoBehaviour
{
    public void ActivatePoints(GameObject excluded)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject == excluded)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}

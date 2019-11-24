using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject staticDoor;
    [SerializeField] private GameObject dynamicDoor;
    [SerializeField] private AudioSource openDoorAudioSource;
    [SerializeField] private GameObject[] enableOnOpen;

    private Animator _animator;
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    private void Start()
    {
        staticDoor.SetActive(true);
        dynamicDoor.SetActive(false);
        _animator = dynamicDoor.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        staticDoor.SetActive(false);
        dynamicDoor.SetActive(true);
        foreach (var o in enableOnOpen)
        {
            o.SetActive(true);
        }
        
        _animator.SetTrigger(Open);
        openDoorAudioSource.Play();
    }
    
    public void CloseDoor()
    {
        staticDoor.SetActive(false);
        dynamicDoor.SetActive(true);
        
        _animator.SetTrigger(Close);
        openDoorAudioSource.Play();
    }
}

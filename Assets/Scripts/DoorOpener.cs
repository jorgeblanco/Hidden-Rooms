using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject staticDoor;
    [SerializeField] private GameObject dynamicDoor;
    [SerializeField] private AudioSource openDoorAudioSource;

    private Animator _animator;
    private static readonly int Open = Animator.StringToHash("Open");

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
        
        _animator.SetTrigger(Open);
        openDoorAudioSource.Play();
    }
}

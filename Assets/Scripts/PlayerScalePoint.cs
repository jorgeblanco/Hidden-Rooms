using UnityEngine;
using VRTK.Prefabs.Locomotion.Teleporters;
using Zinnia.Data.Type;

public class PlayerScalePoint : MonoBehaviour
{
    [SerializeField] private PlayerScaler playerScaler;
    [SerializeField] private TeleporterFacade teleporter;
    private Transform _scaledTarget;
    private SizePointActivator _sizePointActivator;

    private void Start()
    {
        _scaledTarget = GetComponent<Transform>();
        _sizePointActivator = GetComponentInParent<SizePointActivator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerScaler.ScalePlayer(_scaledTarget.localScale.y);
        teleporter.Teleport(new TransformData(_scaledTarget.transform));
        _sizePointActivator.ActivatePoints(excluded:gameObject);
    }
}

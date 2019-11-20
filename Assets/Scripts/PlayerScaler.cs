using UnityEngine;
using Zinnia.Data.Type;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private Transform player;

    public void ScalePlayer(float scale)
    {
        player.localScale = new Vector3(scale, scale, scale);
    }

    public void ScalePlayerByTransform(TransformData target)
    {
        ScalePlayer(target.Transform.localScale.y);
    }
}

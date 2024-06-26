using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float smoothing = 0.2f;

    [SerializeField]
    Vector2 minCameraBoundary;

    [SerializeField]
    Vector2 maxCameraBoundary;

    private void FixedUpdate()
    {
        Vector3 targetsPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        targetsPos.x = Mathf.Clamp(targetsPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetsPos.y = Mathf.Clamp(targetsPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetsPos, smoothing);
    }
}

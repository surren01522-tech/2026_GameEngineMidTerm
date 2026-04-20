using UnityEngine;

public class PlayerflollowCam : MonoBehaviour
{
    public Transform player;
    public float verticalOffset = 0.1f;   // 카메라 높이 조절

    float cameraOffsetZ = -10.0f;
    // Update is called once per frame
    void Update()
    {

        Vector3 targetPos = new Vector3(player.position.x, player.position.y + verticalOffset, cameraOffsetZ);

        transform.position = targetPos;

    }
}

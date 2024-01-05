using UnityEngine;

public class Room : MonoBehaviour
{

    public static Room Get() => FindFirstObjectByType<Room>();

    public void SetOffset(Vector3 offset) => transform.position = offset;

}
using System;
using UnityEngine;

public class User : MonoBehaviour
{

    private float _height = 1.75f;

    public static User Get() => FindFirstObjectByType<User>();

    public float GetHeight() => _height;

    public void SetHeight(float height)
    {
        _height = height;
        var tPos = transform.position;
        tPos.y = _height;
        transform.position = tPos;
    }

}
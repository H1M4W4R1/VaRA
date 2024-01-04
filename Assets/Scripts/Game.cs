using BDSM;
using UnityEngine;
using Devices.Communication;

public class Game : MonoBehaviour
{

    public static Game Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindFirstObjectByType<Game>();

            return _instance;
        }
    }

    private static Game _instance;

    [Header("Communication Interface")]
    public UnitySerialPort serialPort;

    [Header("Game Objects")]
    public Blindfold blindfold;
    public TargetLock leftHandLock;
    public TargetLock rightHandLock;
    public TargetLock hmdLock;

    [Header("VR Skeleton")]
    public Transform leftHandPosition;
    public Transform rightHandPosition;
    public Transform hmd;

    [Header("Materials")]
    public Material okMaterial;
    public Material errorMaterial;
}
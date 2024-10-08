using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [Header("Tweaks")] [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1f, 0);

    private void Awake()
    {
        this.transform.rotation = Quaternion.Euler(90f, 67.5f, 0);
    }

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    void GyroModifyCamera()
    {
        Quaternion gyroQuaternion = GyroToUnity(Input.gyro.attitude);
        Quaternion calculatedRotation = baseRotation * gyroQuaternion;
        transform.rotation = calculatedRotation;
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private void Update()
    {
        GyroModifyCamera();
        this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.eulerAngles.x,
            this.transform.rotation.eulerAngles.y + 65, 0));
        Debug.Log(this.transform.rotation);
    }
}
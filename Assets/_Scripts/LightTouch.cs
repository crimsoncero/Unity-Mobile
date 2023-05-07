using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class LightTouch : MonoBehaviour
{
    [SerializeField] private Light2D _lightTouch;

    private Gyroscope _gyro;

    private void Start()
    {
        _gyro = Input.gyro;
        _gyro.enabled = false;
        _gyro.enabled = true;
        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("yes");
        }
        else
        {
            Debug.Log("no");

        }
    }


    void Update()
    {
        

        Vector3 angleVector = _gyro.attitude.normalized.eulerAngles;

        Color color = Color.white;
        color.b = Mathf.Clamp(Mathf.Abs(angleVector.x),0,255);
        color.g = Mathf.Clamp(Mathf.Abs(angleVector.y),0,255);
        color.r = Mathf.Clamp(Mathf.Abs(angleVector.z), 0, 255);

        Debug.Log(angleVector.ToString());
        _lightTouch.color = color;

    }

}

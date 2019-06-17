using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    Transform camTransform;

    //카메라 흔들릴지 여부
    bool shake = false;
    bool eventShake = false;

    //카메라 흔들림 정도
    float shakeAmount = 0.2f;

	//간격
	int count = 0;	//

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()/////
    {
        if (shake == true && eventShake == false)
        {
            if ((count > 25 && count < 30) || (count > 35 && count < 43))
            {

                shakeAmount = 0.2f;
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            }
            else if (count > 43)
            {
                count = 0;

            }
            count++;
        }
        if (eventShake == true)
        {
            shakeAmount = 0.5f;
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount; camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }

    }//


    public void setShake(bool change)
    {
        shake = change;
    }
    public bool getShake()
    {
        return shake;
    }

    public void setEventShake(bool change)
    {
        eventShake = change;
    }
    public bool getEventShake()
    {
        return eventShake;
    }
}

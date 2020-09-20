using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    bool moveRight, moveLeft; // просто значения влево/вправо - [b]необязательны[/b]
    Transform selfTransform, mainCamTransform; //сохраняем трансформ нашего объекта и камеры
    [SerializeField]
    Camera mainView;    //вешаем сюда нашу камеру
    Vector3 wantedPosition;
    void Start()
    {
        mainCamTransform = mainView.transform;
        selfTransform = transform;
        StartCoroutine(coUpdate());
    }

    private void Update()
    {
        if(Input.GetAxis("Horizontal")>0)
        {
            moveRight = true;
            moveLeft = false;
        }
        else
        {
            moveLeft = true;
            moveRight = false;
        }
    }

    IEnumerator coUpdate()
    {

        while (true)
        {

            if (moveRight)
            {
                wantedPosition = new Vector3(selfTransform.position.x + 10, mainCamTransform.position.y, mainCamTransform.position.z);
            }
            if (moveLeft)
            {
                wantedPosition = new Vector3(selfTransform.position.x - 10, mainCamTransform.position.y, mainCamTransform.position.z);
            }
            mainCamTransform.position = Vector3.Lerp(mainCamTransform.position, wantedPosition, Time.deltaTime * 5.0f); //плавно сдвигает камеру. В нашем случае по X

            yield return 0;
        }
    }
}

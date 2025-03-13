using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour
{

    private Vector3 inputRotation;
    private Vector3 mousePlacement;
    private Vector3 screenCentre;

    void Update()
    {
        FindCrap();
        transform.rotation = Quaternion.LookRotation(inputRotation);
    }

    void FindCrap()
    {
        screenCentre = new Vector3(Screen.width * 0.5f, 0, Screen.height * 0.5f);
        mousePlacement = Input.mousePosition;
        mousePlacement.z = mousePlacement.y;
        mousePlacement.y = 0;
        inputRotation = mousePlacement - screenCentre;
    } //@2

    //public Transform _arrowTransform;
    ////ㅇㅅㅇ.... @3
    //void Update()
    //{
    //    // Get the vectors of the 2 points, the pivot point which is the ball start and the position of the mouse.
    //    Vector2 objectPoint = Camera.main.WorldToScreenPoint(_arrowTransform.position);
    //    Vector2 mousePoint = (Vector2)Input.mousePosition;
    //    float angle = Mathf.Atan2(mousePoint.y - objectPoint.y, mousePoint.x - objectPoint.x) * 180 / Mathf.PI;
    //    _arrowTransform.rotation = Quaternion.AngleAxis(-angle, Vector2.up) * Quaternion.Euler(0f, 0f, 0f);
    //}

    //3. LookAt.. 마우스의좌표를 게임내 좌표로 변환하고 그걸가리키게
    //4. Ray 마우스가 레이를쏴서..
}

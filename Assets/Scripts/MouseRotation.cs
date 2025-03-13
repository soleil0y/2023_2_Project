using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    void Update()
    {
		Vector3 mPosition = Input.mousePosition; //마우스 좌표,,
		Vector3 oPosition = transform.position; //게임 오브젝트 좌표

		mPosition.z = oPosition.z - Camera.main.transform.position.z; //마우스Z축-카메라

		Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); //대충좌표변환

		//오...
		float dy = target.y - oPosition.y;
		float dx = target.x - oPosition.x; 

		float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg; //ㄹ

		//하?
		transform.rotation = Quaternion.Euler(-rotateDegree, 90f, 0f); //오브젝트의 방향...오,,

		//삼각함수..
		//뭔..

	}
	//https://robotree.tistory.com/7

}

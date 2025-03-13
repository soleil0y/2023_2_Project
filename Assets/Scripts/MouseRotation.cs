using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    void Update()
    {
		Vector3 mPosition = Input.mousePosition; //���콺 ��ǥ,,
		Vector3 oPosition = transform.position; //���� ������Ʈ ��ǥ

		mPosition.z = oPosition.z - Camera.main.transform.position.z; //���콺Z��-ī�޶�

		Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); //������ǥ��ȯ

		//��...
		float dy = target.y - oPosition.y;
		float dx = target.x - oPosition.x; 

		float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg; //��

		//��?
		transform.rotation = Quaternion.Euler(-rotateDegree, 90f, 0f); //������Ʈ�� ����...��,,

		//�ﰢ�Լ�..
		//��..

	}
	//https://robotree.tistory.com/7

}

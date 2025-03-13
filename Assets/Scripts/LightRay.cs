using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    public GameObject hitEffectPrefab;
    ParticleSystem ps;

    public void Ray()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo = new RaycastHit();

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        if (Physics.Raycast(ray, out hitInfo)) //�ε��� ��ü�� �ִٸ�
        {
            if (hitInfo.transform.gameObject.tag == "Enemy") //�ε��� ��ü�� ���̶��
            {
                Debug.Log("��");
                hitInfo.transform.gameObject.SetActive(false);

                GameObject hitEffect = Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

                ps = hitEffect.GetComponent<ParticleSystem>();
                ps.Play(); //�ǰ�����Ʈ ���

                //EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>(); //���� EnemyFSM��ũ��Ʈ(������Ʈ)�� ������
                //eFSM.HitEnemy(weaponPower); //�� ��ũ��Ʈ�� HitEnemy�޼ҵ� ����
            }
        }
    }
}

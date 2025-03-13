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

        if (Physics.Raycast(ray, out hitInfo)) //부딪힌 물체가 있다면
        {
            if (hitInfo.transform.gameObject.tag == "Enemy") //부딪힌 물체가 적이라면
            {
                Debug.Log("적");
                hitInfo.transform.gameObject.SetActive(false);

                GameObject hitEffect = Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

                ps = hitEffect.GetComponent<ParticleSystem>();
                ps.Play(); //피격이펙트 재생

                //EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>(); //적의 EnemyFSM스크립트(컨포넌트)를 가져옴
                //eFSM.HitEnemy(weaponPower); //적 스크립트의 HitEnemy메소드 실행
            }
        }
    }
}

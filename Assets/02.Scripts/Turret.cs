using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Turret : MonoBehaviour
{
    private Transform tr;
    private RaycastHit hit;
    private PhotonView pv;

    void Start()
    {
        tr = GetComponent<Transform>();
        pv = GetComponentInParent<PhotonView>();
        //pv = tr.root.GetComponent<PhotonView>();

        this.enabled = pv.IsMine;
    }

    void Update()
    {
        // 메인카메라에서 레이를 발사
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

        // 터레인만 검출하는 레이캐스팅
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            // 월드좌표인 hit.point를  터렛 기준의 로컬좌표계로 변화
            Vector3 pos = tr.InverseTransformPoint(hit.point);

            // Atan2 이용해서 두 좌표간의 사잇각을 계산
            float angle = Mathf.Atan2(pos.x, pos.z) * Mathf.Rad2Deg;
            // 터렛을 회전
            tr.Rotate(Vector3.up * Time.deltaTime * 10.0f * angle);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Animation anim;
    CharacterController cc;
    Transform m_tran;
    public float moveSpeed = 1;
    private void Start()
    {
        anim = GetComponent<Animation>();
        cc = GetComponent<CharacterController>();
        m_tran = transform;
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h!=0 || v!=0)
        {
            anim.CrossFade("WTD_Run_Front@Loop");
            Vector3 tempV = new Vector3(h,0,v);
            cc.SimpleMove(tempV*moveSpeed);
            m_tran.LookAt(m_tran.position+ tempV);
        }
        else
        {
            anim.CrossFade("WTD_Stand@loop");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim["WTD_AttackA2 np"].layer = 1;
            anim.CrossFade("WTD_AttackA2 np",0.1f);
        }
    }
}

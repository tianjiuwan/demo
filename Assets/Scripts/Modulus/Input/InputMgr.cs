using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
    Event e = null;

    private static InputMgr instance;
    public static InputMgr Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.Find("InputMgr");
                if (go == null)
                {
                    go = new GameObject("InputMgr");
                    instance = go.AddComponent<InputMgr>();
                    GameObject.DontDestroyOnLoad(go);
                }
                else
                {
                    instance = go.GetComponent<InputMgr>();
                }
            }
            return instance;
        }
    }

    public void initialize()
    {

    }

    private event Action<KeyCode> keyDownListener;
    public void addListener(Action<KeyCode> handler)
    {
        keyDownListener += handler;
    }
    public void removeListener(Action<KeyCode> handler)
    {
        keyDownListener -= handler;
    }

    private void OnGUI()
    {
        e = Event.current;
        if (e == null) return;
        if (e.isKey)
        {
            KeyCode code = e.keyCode;
            if (e.type == EventType.KeyDown)
            {
                if (keyDownListener != null)
                {
                    keyDownListener(code);
                }
            }
        }
    }

    private BaseEntity player
    {
        get
        {
            return EntityMgr.Instance.MainPlayer;
        }
    }

    //private void Update()
    //{
    //    if (this.player == null) return;
    //    //水平位移 前进
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        this.player.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward, 0.5f });
    //        this.player.transAnim("fistRightGo");
    //        StartCoroutine(checkAttack(0.2f));
    //    }
    //    //水平位移 前进
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        this.player.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward, 0.5f });
    //        this.player.transAnim("fistLeftGo");
    //        StartCoroutine(checkAttack(0.2f));
    //    }
    //    //水平位移 前进
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        //this.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward, 0f });
    //        this.player.transAnim("leftLegGo");
    //    }
    //    //水平位移 被击退
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        this.player.transFsm(E_FsmState.HorizontalMove, new object[] { this.transform.forward * -1, 0.5f });
    //        int idx = UnityEngine.Random.Range(1, 2);
    //        this.player.transAnim("beHit" + idx);
    //    }
    //    //被击飞 曲线移动        
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        this.player.transFsm(E_FsmState.CurveMove, new object[] { new Vector3(0, 0, 0), 6f, 6f });
    //        this.player.transAnim("lieDown");
    //    }
    //    //被击飞 曲线移动        
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        this.player.transFsm(E_FsmState.CurveMove, new object[] { this.player.Trans.position + this.player.Trans.forward * -1 * 10, 2f, 2f, 1.4f });
    //        this.player.transAnim("bowRight");
    //        StartCoroutine(checkAttack2(0.4f));
    //    }
    //    //浮空 主动
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        this.player.transFsm(E_FsmState.InitiativeFly, new object[] { 6f });
    //    }
    //    //被击 浮空
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        this.player.transFsm(E_FsmState.PassivityFly, new object[] { 5f });
    //        this.player.transAnim("lieDown");
    //    }
    //    //被击 浮空2
    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        this.player.transFsm(E_FsmState.PassivityFly, new object[] { 1.5f });
    //        this.player.transAnim("lieDown");
    //    }
    //}

    //IEnumerator checkAttack(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    List<BaseEntity> lst = SearchUtils.getByDistance(this.player, 1.1f);
    //    for (int i = 0; i < lst.Count; i++)
    //    {
    //        BaseEntity role = lst[i];
    //        role.transFsm(E_FsmState.HorizontalMove, new object[] { role.Trans.forward * -1, 0.5f });
    //        int idx = UnityEngine.Random.Range(1, 2);
    //        role.transAnim("beHit" + idx);
    //    }
    //}
    //IEnumerator checkAttack2(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    List<BaseEntity> lst = SearchUtils.getByDistance(this.player, 2f);
    //    for (int i = 0; i < lst.Count; i++)
    //    {
    //        BaseEntity role = lst[i];
    //        role.transFsm(E_FsmState.HorizontalMove, new object[] { role.Trans.forward * -1, 1.5f });
    //        int idx = UnityEngine.Random.Range(1, 2);
    //        role.transAnim("beHit" + idx);
    //    }
    //}

}


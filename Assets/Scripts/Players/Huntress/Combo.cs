using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator anim;
    public int combo = 1;
    public bool isAtk;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _combo();
    }
    public void _combo()
    {
        if(Input.GetKeyDown(KeyCode.M) && !isAtk)
        {
            isAtk = true;
            anim.SetTrigger("Attack" + combo);
        }
    }
    public void _startCombo()
    {
        isAtk = false;
        if (combo < 2)
        {
            combo++;
        }
    }
    public void _finishAnim()
    {
        isAtk = false;
        combo = 1;
    }
}

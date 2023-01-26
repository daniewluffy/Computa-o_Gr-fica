using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerState{
    Idle, //0
    Walk, //1
    Jump, //2
    Fall, //3
    Landing, //4
    Hurt  //5
}

public class PlayerAnim : MonoBehaviour
{
    public static PlayerAnim inst;

    [SerializeField] private playerState playerState; 
    private Animator anim; 


    private void Awake() {
        if(inst == null){
            inst = this;
        }
    }

    public playerState PlayerState { get => playerState; set => playerState = value; }

    void Start()
    {
        PlayerState = playerState.Idle;    
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        updateAnimtion();
        UpdateStateMachine();
    }

    private void updateAnimtion(){
        anim.SetInteger("state", (int)PlayerState);
        if(playerState == playerState.Hurt){
            anim.SetTrigger("Hurt");
        }
    }

    public void UpdateStateMachine(){
        if(playerState == playerState.Jump ){
            if(Player.inst.PlayerRb.velocity.y < .1f)
                playerState = playerState.Fall;
        }else if (playerState == playerState.Fall ){
            if(Player.inst.IsGround)
                playerState = playerState.Landing;
        }else if(Mathf.Abs(Player.inst.PlayerRb.velocity.x ) >3f ){
            PlayerState = playerState.Walk;
        }else{
            PlayerState = playerState.Idle;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerAnim playerAnim;
    private Rat rat;
    void Start()
    {
        rat = FindObjectOfType<Rat>();
        playerAnim = GetComponent<PlayerAnim>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Rat") && playerAnim.PlayerState != playerState.Hurt){
            if(Player.inst.FeetPosition.gameObject.transform.position.y < other.transform.position.y){
                Player.inst.TakingDamage(rat.BaseDamage);
                Player.inst.KbCounter = Player.inst.Kbdelay;
                playerAnim.PlayerState = playerState.Hurt;

                if(transform.position.x <= other.transform.position.x){
                    Player.inst.KnockFromRigh = true;
                }

                if(transform.position.x >= other.transform.position.x){
                    Player.inst.KnockFromRigh = false;
                }
            }
          

            // morte do inimigo
            if(Player.inst.FeetPosition.gameObject.transform.position.y > other.transform.position.y){
                Destroy(other.gameObject);
            }
        }
    }
}

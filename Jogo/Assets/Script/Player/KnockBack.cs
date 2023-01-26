using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    
    // private float strength = 16, delay = 0.15f;

    // public UnityEvent OnBegin, OnDone;

    // public void PlayFeedBack(GameObject sender){
    //     StopAllCoroutines();
    //     OnBegin?.Invoke();
    //     Vector2 direction = (transform.position - sender.transform.position).normalized;
    //     Player.inst.PlayerRb.AddForce(direction*strength, ForceMode2D.Impulse);
    //     StartCoroutine(Reset());
    // }

    // private IEnumerator Reset(){
    //     yield return new WaitForSeconds(delay);
    //     Player.inst.PlayerRb.velocity = Vector3.zero;

    //     OnDone?.Invoke();
    // }

 

}

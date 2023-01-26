using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trash : MonoBehaviour
{
    [SerializeField] private TypeTrash typeTrash; 
    private HudController hudController; 

    void Start()
    {
        Debug.Log(typeTrash.nameTrash); 
        hudController = FindObjectOfType<HudController>();
        typeTrash.numberTrash = 0 ;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            hudController.TypeOfTrash = typeTrash.typeOfTrash;
            hudController.CoutTrash = typeTrash.numberTrash ++;
            Destroy(gameObject);
        }
    }
}
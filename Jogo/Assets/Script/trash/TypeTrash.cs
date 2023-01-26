using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trash", menuName = "ScriptableObject/Trash")]
public class TypeTrash : ScriptableObject
{
    public string nameTrash; 
    public string typeOfTrash;
    public int numberTrash = 0;

    private void Awake() {
        numberTrash = 0;
    }
  
}

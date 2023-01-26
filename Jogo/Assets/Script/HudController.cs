using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    [SerializeField] private TMP_Text[]  count; 
    
    [SerializeField] private string typeOfTrash;
    [SerializeField] private int coutTrash = 0; 
    

    public string TypeOfTrash { get => typeOfTrash; set => typeOfTrash = value; }
    public int CoutTrash { get => coutTrash; set => coutTrash = value; }

    void Start()
    {
        
    }

    void Update()
    {
       switch (typeOfTrash) {
        case "plastic":
                count[0].text = (coutTrash+1).ToString();
            break;
        case "grass":
                count[1].text = (coutTrash+1).ToString();
                break;
        case "paper":
                count[2].text = (coutTrash+1).ToString();
                break;
        case "metal":
                count[3].text = (coutTrash+1).ToString();
                break;
        default :
            break;
       }
    }
}

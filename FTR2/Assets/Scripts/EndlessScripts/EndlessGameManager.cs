using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGameManager : MonoBehaviour
{
    //Area Spawnner
    static public int thisAreaValue;
    [SerializeField] private List<GameObject> areaList = new List<GameObject>();
    
    private void Start() 
    {
        thisAreaValue = 0;
    }

    public void spawnNewArea()
    {
        var spawnPos = areaList[thisAreaValue].transform.position;
        spawnPos.z += 300;
        GameObject area = Instantiate(areaList[thisAreaValue],spawnPos,Quaternion.identity);
        areaList.Add(area);
        RemoveArea(); 
        thisAreaValue++;
    }

    private void RemoveArea()
    {
        if (areaList.Count > 2)
        {
            Destroy(areaList[thisAreaValue - 1]);
            areaList.RemoveAt(thisAreaValue - 1);
            thisAreaValue = 0;
        }
    }

    //coin
}

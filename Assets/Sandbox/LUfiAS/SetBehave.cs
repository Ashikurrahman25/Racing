using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetBehave : MonoBehaviour
{
    public List<int> behaveList = new List<int>();
    // 0=idle, 1=explore, 2=happy, 3=angry , 4=sad, 5=neutral, 6=turn off

    public int GetBehave()
    {
        int rand = Random.Range(0, behaveList.Count);
        int _behave = behaveList.ElementAt(rand);
        behaveList.RemoveAt(rand);
        return _behave;
    }
}

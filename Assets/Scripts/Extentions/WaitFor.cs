using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFor 
{
    public static WaitForSecondsRealtime one = new WaitForSecondsRealtime(1);
    public static WaitForSecondsRealtime oneHalf = new WaitForSecondsRealtime(1.5f);
    public static WaitForSecondsRealtime half = new WaitForSecondsRealtime(0.5f);
    public static WaitForSecondsRealtime two = new WaitForSecondsRealtime(2f);
    public static WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
    public static WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();

}

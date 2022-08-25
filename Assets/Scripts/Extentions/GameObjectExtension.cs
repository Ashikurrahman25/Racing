using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class GameObjectExtension
{
    public static void SetKill(this GameObject go, float time)
    {
        go.SetActive(true);
        UnityEngine.Component.Destroy(go, time);
    }

    public static void KillAllChild(this GameObject go)
    {
        foreach (Transform t in go.transform)
        {
            UnityEngine.Component.Destroy(t.gameObject);
        }
    }

    public static GameObject[] GetChilldArray(this GameObject go)
    {
        GameObject[] g = new GameObject[go.transform.childCount];
        
        for (int i = 0; i < go.transform.childCount; i++)
        {
            g[i] = go.transform.GetChild(i).gameObject;
        }

        return g;
    }

    public static List<GameObject> GetChildList(this GameObject go)
    {
        List<GameObject> g = new List<GameObject>();
        
        for (int i = 0; i < go.transform.childCount; i++)
        {
            g.Add(go.transform.GetChild(i).gameObject);
        }

        return g;
    }


    public static void SetDisableTime(this GameObject go, float time)
    {
        _ = DelayAction((int)(time * 1000), new Action(() =>
          {
              go.SetActive(false);
          }));
    }

    public static void SetDisableTime(this GameObject go, float time, bool setActive)
    {
        if (setActive) go.SetActive(true);
        _ = DelayAction((int)(time * 1000), new Action(() =>
        {
            go.SetActive(false);
        }));
    }

    public static async Task DelayAction(int ms, Action action)
    {
        await Task.Delay(ms);
        action.Invoke();
    }

    // bounds
    public static List<Vector3> GetCorners(this Bounds obj, bool includePosition = true)
    {
        var result = new List<Vector3>();
        for (int x = -1; x <= 1; x += 2)
            for (int y = -1; y <= 1; y += 2)
                for (int z = -1; z <= 1; z += 2)
                    result.Add((includePosition ? obj.center : Vector3.zero) + (obj.size / 2).Times(new Vector3(x, y, z)));
        return result;
    }

    public static Vector3 Times(this Vector3 self, Vector3 other)
    {
        return new Vector3(self.x * other.x, self.y * other.y, self.z * other.z);
    }
}

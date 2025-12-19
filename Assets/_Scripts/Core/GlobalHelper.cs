using UnityEngine;

public static class GlobalHelper 
{
    public static string GenrateUniqueID(GameObject obj)
    {
        return System.Guid.NewGuid().ToString();
    }
}

using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var objs = GameObject.FindObjectsOfType<DontDestroy>();

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}

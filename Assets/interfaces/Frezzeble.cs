using UnityEngine;

public class Frezzeble : MonoBehaviour
{
    protected bool frozen = true;
    public static bool mainFrozen = true;

    private void Start()
    {
        SaveFrezze();
    }

    public virtual void frezze()
    {
        frozen = true;
    }

    public virtual void unFrezze()
    {
        frozen = false;
    }

    public virtual void SaveFrezze()
    {
        GameControllor.singelton.frezzeble.Add(this);
    }
}

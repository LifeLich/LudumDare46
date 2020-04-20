using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaData : MonoBehaviour
{
    int screen = 0;

    public enum RunnorType
    {
        normal, DoubleBuild, BuildAndRun, Respawn, dieOnWall
    }
    public static RunnorType runnorType = RunnorType.DoubleBuild;

    public static MetaData singelton;
    public int crystals;

    public List<bool> unlockeds = new List<bool>();

    private void Awake()
    {
        if (singelton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singelton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    private void Start()
    {
        singelton = this;
    }
    public void SetRunnor(int runnor)
    {
        switch (runnor)
        {
            case 0:
                runnorType = RunnorType.Respawn;
                break;
            case 1 :
                runnorType = RunnorType.DoubleBuild;
                break;
            case 2:
                runnorType = RunnorType.BuildAndRun;
                break;
            case 3:
                runnorType = RunnorType.normal;
                break;
            case 4:
                runnorType = RunnorType.dieOnWall;
                break;
            default:
                runnorType = RunnorType.normal;
                break;
        }
        
    }

    public void SetScreen(int screen)
    {
        this.screen = screen;
    }

    public void LoadScreen()
    {
        SceneManager.LoadSceneAsync(screen);
    }
    public void LoadScreen(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }
}

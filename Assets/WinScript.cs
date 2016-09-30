using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

    public Texture transparent;
    public Texture xWin;
    public Texture oWin;
    public Texture draw;
    public GameObject runner;
    private int delay;

    private void Start()
    {
        delay = 50;
        GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), transparent);
    }
	
    public void showWinScreen(int value)
    {
        switch(value)
        {
            case 1:
                GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), xWin);
                break;
            case 2:
                GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), oWin);
                break;
            case 3:
                GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), draw);
                break;
        }
    }

    void FixedUpdate()
    {
        if(RunGame.halt) delay--;
    }

	void Update ()
    {
        if (RunGame.halt)
        {
            if (delay <= 0 && Input.GetMouseButtonUp(0))
            {
                delay = 50;
                    GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), transparent);
                    runner.GetComponent<RunGame>().restartGame();
            }
        }

	}
}

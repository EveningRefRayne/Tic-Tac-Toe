using UnityEngine;
using System.Collections;

public class SpaceInteract : MonoBehaviour {

    private int used = 0;
    public Texture transparent;
    public Texture xTexture;
    public Texture oTexture;
    public GameObject glow;
    private GameObject hold;
    public GameObject runner;

	public void clearTile()
    {
        used = 0;
        GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), transparent);
    }

    private void OnMouseEnter()
    {
        if (used == 0 && !RunGame.halt)
            hold = Instantiate(glow, this.transform.position, Quaternion.identity) as GameObject;
    }

    private void OnMouseExit()
    {
        if (used == 0 && !RunGame.halt)
            Destroy(hold);
    }

    private void OnMouseDown()
    {
        if (used == 0 && !RunGame.halt)
        {
            Destroy(hold);
            used = 1;
            if (runner.GetComponent<RunGame>().getTurn() == 0)
            {
                GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), xTexture);

            }
            else
            {
                GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), oTexture);
            }
            runner.GetComponent<RunGame>().updateGameState(gameObject);
        }
    }
	
	
}

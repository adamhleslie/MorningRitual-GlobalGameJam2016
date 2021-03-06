using UnityEngine;
using System.Collections;

public class CoffeeButton : MonoBehaviour {
    
    Animation anim;
    public GameObject coffeeArea;
    public Material pressableMaterial;
    public Material usedMaterial;
    public int timeValidSeconds;
    float endTime;
    bool activated;
    MeshRenderer thisRenderer;

    CapsuleCollider coffeeAreaCollider;
    MeshRenderer coffeeFlowRenderer;
    AudioSource coffeeFlowAudioSource;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		coffeeAreaCollider = coffeeArea.GetComponent<CapsuleCollider>();
		coffeeFlowRenderer = coffeeArea.GetComponent<MeshRenderer>();
		activated = false;
		endTime = 0;
		thisRenderer = this.GetComponent<MeshRenderer>();
		coffeeFlowAudioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (activated && endTime < Time.time)
		{
			thisRenderer.material = pressableMaterial;
			activated = false;
			endTime = 0;
			coffeeAreaCollider.enabled = false;
			coffeeFlowRenderer.enabled = false;
			Debug.Log("Disabled Coffee Area Collider");
		}
	}

    void OnHandHoverBegin(VRHand hand)
    {
    	if (!activated)
    	{
	    	anim.Play();
	        coffeeAreaCollider.enabled = true;
	        coffeeFlowRenderer.enabled = true;
	        thisRenderer.material = usedMaterial;
	        activated = true;
	        Debug.Log("Enabled Coffee Area Collider");
	        coffeeFlowAudioSource.Play();
	        endTime = timeValidSeconds + Time.time;
	    }
    }
}

using UnityEngine;

public class AndroidCallBacks : MonoBehaviour {

    private string yes = "0";
    private string no = "1";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleCallBacks(string buttonIndex)
    {
        Debug.Log(buttonIndex);
        if (buttonIndex == yes)
        {
            GameObject.FindGameObjectWithTag("controller").GetComponent<Controller>().reply.text = "Yes Pressed";
        }else if(buttonIndex == no)
        {
            GameObject.FindGameObjectWithTag("controller").GetComponent<Controller>().reply.text = "No Pressed";
        }
    }
}

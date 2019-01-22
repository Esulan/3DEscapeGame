// DoorDetectionLite.cs
// Created by Alexander Ameye
// Version 3.0.0

using UnityEngine;

[HelpURL("https://alexdoorsystem.github.io/liteversion/")]
public class DoorDetectionLite : MonoBehaviour
{

    // UI Settings
    public GameObject TextPrefab; // A text element to display when the player is in reach of the door
    [HideInInspector] public GameObject TextPrefabInstance; // A copy of the text prefab to prevent data corruption
    [HideInInspector] public bool TextActive;

    public GameObject CrosshairPrefab;
    [HideInInspector] public GameObject CrosshairPrefabInstance; // A copy of the crosshair prefab to prevent data corruption

    // Raycast Settings
    public float Reach = 4.0F;
    [HideInInspector] public bool InReach;
    public string Character = "e";

    public Color DebugRayColor;

	private DialScript dial;
    private ButtonPanelScript buttonPanel;
    private SearchObjectScripts search;
	private bool d_flag;
    private bool b_flag;
    private bool s_flag;
	public GameObject target;
    public GameObject targetPanel;
    public GameObject targetSearch;

    void Start()
    {
        gameObject.name = "Player";
        gameObject.tag = "Player";

        if (CrosshairPrefab == null) Debug.Log("<color=yellow><b>No CrosshairPrefab was found.</b></color>"); // Return an error if no crosshair was specified

        else
        {
            CrosshairPrefabInstance = Instantiate(CrosshairPrefab); // Display the crosshair prefab
            CrosshairPrefabInstance.transform.SetParent(transform, true); // Make the player the parent object of the crosshair prefab
        }

        if (TextPrefab == null) Debug.Log("<color=yellow><b>No TextPrefab was found.</b></color>"); // Return an error if no text element was specified
		target = GameObject.Find("Dial");
		dial = target.GetComponent<DialScript>();

        targetPanel = GameObject.Find("TextPanel");
        buttonPanel = targetPanel.GetComponent<ButtonPanelScript>();

        targetSearch = GameObject.Find("Box");
        search = targetSearch.GetComponent<SearchObjectScripts>();
    }

    void Update()
    {
        // Set origin of ray to 'center of screen' and direction of ray to 'cameraview'
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

        RaycastHit hit; // Variable reading information about the collider hit

		d_flag = dial.DialFlag ();
        b_flag = buttonPanel.PanelFlag();
        s_flag = search.InnerFlag();

        // Cast ray from center of the screen towards where the player is looking
        if (Physics.Raycast(ray, out hit, Reach))
        {
            if (hit.collider.tag == "Door")
            {
                InReach = true;

                // Display the UI element when the player is in reach of the door
                if (TextActive == false && TextPrefab != null)
                {
                    TextPrefabInstance = Instantiate(TextPrefab);
                    TextActive = true;
                    TextPrefabInstance.transform.SetParent(transform, true); // Make the player the parent object of the text element
                }

                // Give the object that was hit the name 'Door'
                GameObject Door1 = hit.transform.gameObject;
                GameObject Door2 = hit.transform.gameObject;
                GameObject Door3 = hit.transform.gameObject;

                // Get access to the 'Door' script attached to the object that was hit
                DoorRotationLite dooropening1 = Door1.GetComponent<DoorRotationLite>();
                DoorRotationLite dooropening2 = Door2.GetComponent<DoorRotationLite>();
                DoorRotationLite dooropening3 = Door3.GetComponent<DoorRotationLite>();

				if (d_flag == true && Door1.name == "DoorFirst") {
					if (Input.GetKey (Character)) {
						// Open/close the door by running the 'Open' function found in the 'Door' script
						if (dooropening1.RotationPending == false)
							StartCoroutine (hit.collider.GetComponent<DoorRotationLite> ().Move ());
					}
				}

                if (s_flag == true && Door2.name == "DoorSecond") {
					if (Input.GetKey (Character)) {
						// Open/close the door by running the 'Open' function found in the 'Door' script
						if (dooropening2.RotationPending == false)
							StartCoroutine (hit.collider.GetComponent<DoorRotationLite> ().Move ());
					}
				}

                if (b_flag == true && Door3.name == "DoorThird") {
					if (Input.GetKey (Character)) {
						// Open/close the door by running the 'Open' function found in the 'Door' script
						if (dooropening3.RotationPending == false)
							StartCoroutine (hit.collider.GetComponent<DoorRotationLite> ().Move ());
					}
				}
            }

            else
            {
                InReach = false;

                // Destroy the UI element when Player is no longer in reach of the door
                if (TextActive == true)
                {
                    DestroyImmediate(TextPrefabInstance);
                    TextActive = false;
                }
            }
        }

        else
        {
            InReach = false;

            // Destroy the UI element when Player is no longer in reach of the door
            if (TextActive == true)
            {
                DestroyImmediate(TextPrefabInstance);
                TextActive = false;
            }
        }

        //Draw the ray as a colored line for debugging purposes.
        Debug.DrawRay(ray.origin, ray.direction * Reach, DebugRayColor);
    }
}

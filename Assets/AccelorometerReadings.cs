using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelorometerReadings : MonoBehaviour {

    public Text x_value;
    public Text y_value;
    public Text z_value;
    public Text x_direction;
   // public Text y_direction;
    //public Text z_direction;
    public Text notification;
    public Text notification_direction;
    public Button save_btn;
    private float x_axis_save, y_axis_save, z_axis_save, x_axis, y_axis, z_axis;
    private bool clicked = false;
    private bool notify = false,direction = false;
    private int z_p_threshold = 300, z_n_threshold = -450;

    float x_direction_value, y_direction_value, z_direction_value, x_direction_save, y_direction_save, z_direction_save;

	// Use this for initialization
	void Start () {
        Input.compass.enabled = true;
        Input.location.Start();
	}
	
	// Update is called once per frame
	void Update () {
        x_direction_value = Input.compass.rawVector.x;
        y_direction_value = Input.compass.rawVector.y;
        z_direction_value = Input.compass.rawVector.z;
        x_axis = Input.acceleration.x;
        y_axis = Input.acceleration.y;
        z_axis = Input.acceleration.z;

        notification.enabled = notify;
        notification_direction.enabled = direction;
        transform.Translate(x_axis, y_axis, z_axis);
        //x_value.text = "X " + x_axis*1000 + "";
        x_value.text = "X axis threshold = " + (x_axis_save - x_axis * 1000);
        y_value.text = "Y axis threshold = " + (y_axis_save - y_axis * 1000);
        z_value.text = "Z axis threshold = " + (z_axis_save - z_axis * 1000);

        x_direction.text = "X direction " + x_direction_value * 1000 + "\nY direction " + y_direction_value * 1000 + "\nZ direction " + z_direction_value * 1000;
      //  y_direction.text = "\nY direction " + y_direction_value * 1000;
       // z_direction.text = "\nZ direction " + z_direction_value * 1000;
        save_btn.onClick.AddListener(Save_coordinates);
        
        if(clicked){
           /* if ((x_axis * 1000 < x_axis_save + 50 && x_axis * 1000 > x_axis_save - 50) && (y_axis * 1000 < y_axis_save + 50 && y_axis * 1000 > y_axis_save - 50) && (z_axis * 1000 < z_axis_save + 50 && z_axis * 1000 > z_axis_save - 50) && (x_direction_value * 1000 < x_direction_save + 10000 && x_direction_value * 1000 > x_direction_save - 10000) && (y_direction_value * 1000 < y_direction_save + 10000 && y_direction_value * 1000 > y_direction_save - 10000) && (z_direction_value * 1000 < z_direction_save + 10000 && z_direction_value * 1000 > z_direction_save - 10000))
                notify = true;
            else
                notify = false;
            */
            /*if ((x_axis * 1000 < x_axis_save + 150 && x_axis * 1000 > x_axis_save - 150) && (y_axis * 1000 < y_axis_save + 150 && y_axis * 1000 > y_axis_save - 150) && (z_axis * 1000 < z_axis_save + 150 && z_axis * 1000 > z_axis_save - 150))
                notify = true;
            else
                notify = false;
            if ((x_direction_value * 1000 < x_direction_save + 2500 && x_direction_value * 1000 > x_direction_save - 2500) && (y_direction_value * 1000 < y_direction_save + 2500 && y_direction_value * 1000 > y_direction_save - 2500) && (z_direction_value * 1000 < z_direction_save + 2500 && z_direction_value * 1000 > z_direction_save - 2500))
                direction = true;
            else
                direction = false;*/
            if ((y_axis * 1000 < y_axis_save + 30 && y_axis * 1000 > y_axis_save - 30))
                notify = true;
            else
                notify = false;
        }
        Debug.Log("Notify " + notify + "\nClicked " + clicked);

    }
    void Save_coordinates()
    {
        x_axis_save = x_axis*1000;
        y_axis_save = y_axis * 1000;
        z_axis_save = z_axis * 1000;

        x_direction_save = x_direction_value * 1000;
        y_direction_save = y_direction_value * 1000;
        z_direction_save = z_direction_value * 1000;
        Debug.Log("Line 67 Z Direction "+ z_direction_save);

        clicked = true;
    }

}

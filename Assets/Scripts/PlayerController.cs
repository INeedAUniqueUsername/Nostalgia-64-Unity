using UnityEngine;
public class PlayerController : MonoBehaviour {
    Control[] controls;
    void Start() {
        controls = GetComponent<ControlSet>().controls;
    }
    void Update() {
        for(int i = 0; i < controls.Length; i++) {
            /*
            if(Input.GetKey(controls[i].key)) {
                //print(controls[i].key + " key activated");
                controls[i].action.GetComponent<IUsable>().Activate();
            }
            */
            bool down = Input.GetKey(controls[i].key);
            IUsable usable = controls[i].action.GetComponent<IUsable>();
            if(usable is IDevice) {
                ((IDevice) usable).SetActive(down);
            } else if(down) {
                usable.Activate();
            }
        }
    }
}
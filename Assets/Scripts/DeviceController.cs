using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceController : MonoBehaviour
{
    public List<GameObject> reactorObjects;
    private List<IReactor> reactors;
    
    public List<GameObject> miscObjects;
    private List<IDevice> misc;
    public List<GameObject> driveObjects;
    private List<IDrive> drives;

    public List<GameObject> weaponObjects;
    private List<IWeapon> weapons;

    public List<GameObject> capacitorObjects;
    private List<ICapacitor> capacitors;
    void Start() {
        drives = Helper.InitializeComponent<IDrive>(driveObjects);
        weapons = Helper.InitializeComponent<IWeapon>(weaponObjects);
        reactors = Helper.InitializeComponent<IReactor>(reactorObjects);
        capacitors = Helper.InitializeComponent<ICapacitor>(capacitorObjects);
        misc = Helper.InitializeComponent<IDevice>(miscObjects);
    }
    void Update() {
        float totalOutput = GetReactorOutput(reactors) + GetCapacitorOutput(capacitors);
        float powerLeft = totalOutput;
        for (int i = 0; i < capacitors.Count && powerLeft > 0; i++) {
            ICapacitor c = capacitors[i];
            float chargeNeeded = c.GetCapacity() - c.GetCharge();
            c.Recharge(Mathf.Min(powerLeft, chargeNeeded));
            powerLeft -= chargeNeeded;
        }
        for(int i = 0; i < drives.Count && powerLeft > 0; i++) {
            IDrive d = drives[i];
            powerLeft -= d.GetPowerUse();
            if(powerLeft < 0) {
                //TO DO: Handle overload
                //TO DO: Disable and deactivate drive
                d.SetActive(false);
            }
            else if(d.GetActive()) {
                d.Activate();
            }
        }
        for(int i = 0; i < weapons.Count && powerLeft > 0; i++) {
            IWeapon w = weapons[i];
            powerLeft -= w.GetPowerUse();
            if(powerLeft < 0) {
                //TO DO: Handle overload
                //TO DO: Disable and deactivate weapon
                w.SetActive(false);
            }
            else if(w.GetActive()) {
                w.Activate();
            }
        }
        for(int i = 0; i < misc.Count && powerLeft > 0; i++) {
            IDevice m = misc[i];
            powerLeft -= m.GetPowerUse();
            if(powerLeft < 0) {
                //TO DO: Handle overload
                //TO DO: Disable and deactivate weapon
                m.SetActive(false);
            }
            else if(m.GetActive()) {
                m.Activate();
            }
        }

        
        float usage = totalOutput - powerLeft;
        //Drain from our reactors first
        for (int i = 0; i < reactors.Count && usage > 0; i++) {
            IReactor r = reactors[i];
            float reactorOutput = r.GetOutput();
            r.Consume(Mathf.Min(usage, reactorOutput));
            usage -= reactorOutput;
        }
        //Our capacitors boost our power output
        for (int i = 0; i < capacitors.Count && usage > 0; i++) {
            ICapacitor c = capacitors[i];
            float capacitorCharge = c.GetCharge();
            c.Consume(Mathf.Min(usage, capacitorCharge));
            usage -= capacitorCharge;
        }
    }
    public static float GetReactorOutput(List<IReactor> reactors) {
        float result = 0;
        for(int i = 0; i < reactors.Count; i++) {
            result += reactors[i].GetOutput();
        }
        return result;
    }
    public static float GetCapacitorOutput(List<ICapacitor> capacitors) {
        float result = 0;
        for(int i = 0; i < capacitors.Count; i++) {
            result += capacitors[i].GetCharge();
        }
        return result;
    }
}

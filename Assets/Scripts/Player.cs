using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item Item { get; set; }

    [SerializeField] private float minPower = 3;
    [SerializeField] private float maxPower = 8;
    [SerializeField] private float powerPerSecond = 3;
    [SerializeField] Bar powerBar;

    private float power;
    private bool increasePower;

    public void Init()
    {
        Item = null;
        power = 0;
        SetPowerProgress();
    }

    private void Update()
    {
        if (Item == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            power = minPower;
            increasePower = true;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            var delta = powerPerSecond * Time.deltaTime;
            if (!increasePower) delta = -delta;
            power += delta;

            if (power >= maxPower) increasePower = false;
            else if (power <= minPower) increasePower = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Item.Push(power);
            Item = null;
        }

        SetPowerProgress();
    }

    private void SetPowerProgress()
    {
        var progress = (power - minPower) / (maxPower - minPower);
        powerBar.SetProgress(progress);
    }
}

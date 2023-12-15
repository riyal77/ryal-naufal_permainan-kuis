using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class UI_Timer : MonoBehaviour
{
    public static event System.Action EventWaktuHabis;

    [SerializeField]
    private Slider _timeBar = null;
    [SerializeField]
    private float _waktuJawab = 30;
    private float _sisaWaktu = 0;
    private bool _waktuBerjalan = true;

    public bool WaktuBerjalan
    {
        get =>_waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    public void UlangiWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UlangiWaktu();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_waktuBerjalan)
        {
            return;
        }

        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu <= 0f)
        {
            EventWaktuHabis?.Invoke();
            _waktuBerjalan = false;
            return;
        }
    }
}

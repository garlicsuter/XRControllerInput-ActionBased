using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    public TextMeshProUGUI leftScoreDisplay;
    public TextMeshProUGUI rightScoreDisplay;

    private InputData _inputData;
    private float _leftMaxScore = 0f;
    private float _rightMaxScore = 0f;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            _leftMaxScore = Mathf.Max(leftVelocity.magnitude, _leftMaxScore);
            leftScoreDisplay.text = _leftMaxScore.ToString("F2");
        }
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            _rightMaxScore = Mathf.Max(rightVelocity.magnitude, _rightMaxScore);
            rightScoreDisplay.text = _rightMaxScore.ToString("F2");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SensorReadout : MonoBehaviour
{
  public TextMeshProUGUI locationStatus;
  public TextMeshProUGUI LatitudeText;
  public TextMeshProUGUI LongitudeText;
  public TextMeshProUGUI AltitudeText;
  public TextMeshProUGUI AccelerationText;
  public TextMeshProUGUI AngularVelocityText;

  public float minLatitude = -90f;
  public float maxLatitude = 90f;
  public float minLongitude = -180f;
  public float maxLongitude = 180f;

  public GameObject samurai;

  void Start()
  {
    StartCoroutine(StartLocationService());
  }

  IEnumerator StartLocationService()
  {
    Input.gyro.enabled = true;
    Input.compass.enabled = true;
    Input.location.Start(10f, 10f);

    int maxWait = 20;
    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    {
      yield return new WaitForSeconds(1);
      maxWait--;
    }

    if (maxWait <= 0)
    {
      locationStatus.text = "Timed out.";
      yield break;
    }

    if (Input.location.status == LocationServiceStatus.Failed)
    {
      locationStatus.text = "Unable to determine device location.";
      yield break;
    }
  }


  void Update()
  {
    if (Input.location.status == LocationServiceStatus.Running)
    {
      LatitudeText.text = "Latitude: " + Input.location.lastData.latitude;
      LongitudeText.text = "Longitude: " + Input.location.lastData.longitude;
      AltitudeText.text = "Altitude: " + Input.location.lastData.altitude;
      AccelerationText.text = "Acceleration: " + Input.acceleration;
      AngularVelocityText.text = "Angular Velocity: " + Input.gyro.rotationRate;
    }
    else
    {
      locationStatus.text = "Location services are not running.";
    }

    Quaternion attitude = Input.gyro.attitude;
    Quaternion rotator = Quaternion.Euler(0f, 180, 0f) * attitude * Quaternion.Euler(0f, 0, 180f);
    samurai.transform.rotation = Quaternion.Slerp(samurai.transform.rotation, rotator, Time.deltaTime * 5f);

    Vector3 acceleration = Input.acceleration;
    acceleration.z = -acceleration.z; 

    if (Input.location.status == LocationServiceStatus.Running)
    {
      float latitude = Input.location.lastData.latitude;
      float longitude = Input.location.lastData.longitude;

      if (latitude >= minLatitude && latitude <= maxLatitude && longitude >= minLongitude && longitude <= maxLongitude)
      {
        samurai.transform.Translate(acceleration * Time.deltaTime);
      }
      else
      {
        // Stop the movement
        samurai.transform.Translate(Vector3.zero);
      }
    }
  }

  void OnDestroy()
  {
    Input.location.Stop();
  }
}

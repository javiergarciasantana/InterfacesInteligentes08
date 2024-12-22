# InterfacesInteligentes08
----
# SensorReadout Script

This Unity C# script implements a `SensorReadout` class that:

- Reads and displays real-time location and sensor data from the device.
- Manipulates a GameObject (`samurai`) based on device location and movement.
- Handles device gyroscope and accelerometer data for rotation and movement.

## Features

- **Location Services**: Displays latitude, longitude, and altitude.
- **Gyroscope and Accelerometer Data**:
  - Displays device acceleration and angular velocity.
  - Rotates the `samurai` GameObject based on gyroscope data.
  - Moves the `samurai` GameObject when within specified latitude/longitude bounds.
- **Location Service Initialization**:
  - Provides feedback when location services are initializing, fail, or succeed.

## Script Overview

### Public Fields

- `locationStatus`: Displays location status (e.g., "Running", "Timed out").
- `LatitudeText`, `LongitudeText`, `AltitudeText`: Show device location coordinates.
- `AccelerationText`, `AngularVelocityText`: Show accelerometer and gyroscope data.
- `minLatitude`, `maxLatitude`, `minLongitude`, `maxLongitude`: Define valid location bounds.
- `samurai`: The GameObject that moves and rotates based on sensor data.

### Methods

- **`Start()`**:
  - Begins the location service and enables sensors.
- **`StartLocationService()`**:
  - Initializes and checks the status of location services.
- **`Update()`**:
  - Updates UI elements with sensor data.
  - Rotates and translates the `samurai` GameObject based on gyroscope and accelerometer input.
- **`OnDestroy()`**:
  - Stops location services when the script is destroyed.

## Setup Instructions

1. **Add the Script**:
   - Attach the `SensorReadout` script to a GameObject in your Unity scene.

2. **Assign UI Elements**:
   - Add `TextMeshProUGUI` components to the scene for `locationStatus`, `LatitudeText`, `LongitudeText`, `AltitudeText`, `AccelerationText`, and `AngularVelocityText`.
   - Assign these fields in the Unity Editor.

3. **Configure GameObject**:
   - Add a GameObject (e.g., `samurai`) to the scene and assign it to the `samurai` field.

4. **Set Location Bounds** (Optional):
   - Adjust `minLatitude`, `maxLatitude`, `minLongitude`, and `maxLongitude` to define valid movement regions.

5. **Enable Required Features**:
   - Ensure the project has permissions for accessing location and sensors on the target platform.

## Example Use

This script is designed for projects that involve real-time movement based on sensor data, such as augmented reality (AR) applications or mobile games.



https://github.com/user-attachments/assets/cf84ecc4-0728-48ea-b308-e6da756d4b9e


## Dependencies

- [TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@latest): Required for displaying UI text.

## Notes

- Ensure the target platform supports location services, gyroscope, and accelerometer.
- Adjust the `Translate` and `Slerp` parameters in the `Update` method to fine-tune movement and rotation.

## License

This script is open-source. Modify and distribute as needed for your projects.

using NfsCore.Support.Underground2.Parts.CarParts;
using NfsCore.Support.Underground2.Parts.InfoParts;

namespace NfsCore.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        private void Initialize()
        {
            ECAR = new Ecar();
            PVEHICLE = new Pvehicle();
            AI_CAMERA_DRIVER = new Camera();
            AI_CAMERA_CLOSE = new Camera();
            AI_CAMERA_DRIFT = new Camera();
            AI_CAMERA_BUMPER = new Camera();
            AI_CAMERA_FAR = new Camera();
            AI_CAMERA_HOOD = new Camera();
            PLAYER_CAMERA_DRIVER = new Camera();
            PLAYER_CAMERA_CLOSE = new Camera();
            PLAYER_CAMERA_DRIFT = new Camera();
            PLAYER_CAMERA_BUMPER = new Camera();
            PLAYER_CAMERA_FAR = new Camera();
            PLAYER_CAMERA_HOOD = new Camera();
            BASE_BRAKES = new Brakes();
            BASE_ENGINE = new Engine();
            BASE_RPM = new RPM();
            BASE_SUSPENSION = new Suspension();
            BASE_TIRES = new Tires();
            BASE_TRANSMISSION = new Transmission();
            BASE_TURBO = new Turbo();
            DRIFT_ADD_CONTROL = new DriftControl();
            STREET_ECU = new ECU();
            STREET_RPM = new RPM();
            STREET_TRANSMISSION = new Transmission();
            PRO_ECU = new ECU();
            PRO_RPM = new RPM();
            PRO_TRANSMISSION = new Transmission();
            TOP_BRAKES = new Brakes();
            TOP_ECU = new ECU();
            TOP_ENGINE = new Engine();
            TOP_NITROUS = new Nitrous();
            TOP_RPM = new RPM();
            TOP_SUSPENSION = new Suspension();
            TOP_TIRES = new Tires();
            TOP_TRANSMISSION = new Transmission();
            TOP_TURBO = new Turbo();
            TOP_WEIGHT_REDUCTION = new WeightReduction();
            WHEEL_FRONT_LEFT = new CarInfoWheel();
            WHEEL_FRONT_RIGHT = new CarInfoWheel();
            WHEEL_REAR_LEFT = new CarInfoWheel();
            WHEEL_REAR_RIGHT = new CarInfoWheel();
            CARSKIN01 = new CarSkin();
            CARSKIN02 = new CarSkin();
            CARSKIN03 = new CarSkin();
            CARSKIN04 = new CarSkin();
            CARSKIN05 = new CarSkin();
            CARSKIN06 = new CarSkin();
            CARSKIN07 = new CarSkin();
            CARSKIN08 = new CarSkin();
            CARSKIN09 = new CarSkin();
            CARSKIN10 = new CarSkin();
        }
    }
}
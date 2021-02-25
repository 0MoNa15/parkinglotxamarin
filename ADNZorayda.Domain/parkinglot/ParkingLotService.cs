using System;
using System.Globalization;
using ADNZorayda.Domain.parkinglot;
using ADNZorayda.Domain.vehicle.entity;
using ADNZorayda.Domain.vehicle.webservice;

namespace ADNZorayda.Domain.parkinglot
{
    // Validaciones y reglas de negocio con relación al parqueadero en general
    public class ParkingLotService
    {

        CarService mCarService;
        MotorcycleService mMotorcycleService;

        public ParkingLotService(CarService carRepository, MotorcycleService motorcycleRepository)
        {
            mCarService = new CarService(carRepository);
            mMotorcycleService = new MotorcycleService(motorcycleRepository);
        }

        // 'A' en inicial de la placa solo ingresan los Domingos y Lunes
        public bool licensePlateVerificationForAdmission(string licensePlate) {
            // Para obtener el dia actual y posteriormente compararlo
            var coCulture = new CultureInfo("es-CO");
            var d = DateTime.UtcNow;
            var coDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(d, "SA Pacific Standard Time");
            var dayOfTheWeek = coDate.ToString("EEEE", coCulture);

            Day day;
            Day[] mList = Day.availablesDays();

            for (int i = 0; i < Day.availablesDays().Length; i++)
            {
                day = mList[i];
                if (day.identifyDay == dayOfTheWeek && day.type.Equals(Day.TypeOfDay.NORMAL_DAY))
                {
                    string letter = licensePlate[0].ToString();

                    if (letter == LicencePlate.INITIAL_WITH_SPECIAL_CONDITION || letter == LicencePlate.INITIAL_WITH_SPECIAL_CONDITION_LOWER)
                    {
                        return false;
                    }
                }
            }


            return true;
        }

        public bool carLimitValidation(int currentQuantity)
        {
            if (currentQuantity < ParkingLot.MAXIMUM_QUANTITY_CARS)
                return true;

            return false;
        }

        public bool motorcycleLimitValidation(int currentQuantity)
        {
            if (currentQuantity < ParkingLot.MAXIMUM_QUANTITY_MOTORCYCLES)
                return true;

            return false;
        }
        /*
         public Vehicle[] getAllVehicles()
         {

         }

         public ArrayList<Vehicle> getOnlyVehiclesEnteredParkingLot()
         {

         }
         */
        public void saveMotorcycle(Motorcycle motorcycle)
        {
            mMotorcycleService.saveMotorcycle(motorcycle);
        }

        public int calculateCostToPay(int priceByHour, int priceByDay, int entryDateString)
        {
            int finalPrice = 0;

            // Parseando la fecha con el time zone, y un formato predefinido
            var usCulture = new CultureInfo("en-US");
            var d = DateTime.UtcNow;
            var coDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(d, "SA Pacific Standard Time");
            var dayOfTheWeek = coDate.ToString("dd/MM/yyyy HH:mm", usCulture);
            DateTime entryDateInFormatDate = DateTime.ParseExact(dayOfTheWeek, entryDateString.ToString(), usCulture);

            int hoursInTheParking = convertTimeToHour(entryDateInFormatDate);

            if (hoursInTheParking < 9)
            {
                // Se cobra por hora cuando el tiempo en el parqueadero fué inferior a 9 horas
                finalPrice += hoursInTheParking  * priceByHour;
            } else if (hoursInTheParking < 24)
            {
                // Se cobran un dia completo si el vehiculo estuvo por más de 9 horas hasta 24 horas
                finalPrice += priceByDay;
            } else
            {
                // Se cobra un dia completo por cada 24 horas transcurridas y
                // se cobra por horas el restante
                finalPrice += (hoursInTheParking / 24) * priceByDay;
                finalPrice += (hoursInTheParking % 24) * priceByHour;
            }

            return finalPrice;
        }
        
        public int convertTimeToHour(DateTime entyDate)
        {
            return 0;
        }
        /*
        public int exitToAVehicle(Vehicle vehicle)
        {
            return 0;
        }

        public int getCostToPay(Vehicle vehicle)
        {
            return 0;
        }
        */
        public bool enterANewCar(Car car)
        {
            return false;
        }

        public bool enterANewMotorcycle(Motorcycle motorcycle)
        {
            return false;
        }

        public bool currentDate()
        {
            return false;
        }
        
    }
}

﻿using System;
using System.Globalization;
using ADNZorayda.Domain.parkinglot;
using ADNZorayda.Domain.vehicle;

namespace ADNZorayda.Domain
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
        public Boolean licensePlateVerificationForAdmission(String licensePlate) {
            // Para obtener el dia actual y posteriormente compararlo
            var usCulture = new CultureInfo("es-CO");
            var d = DateTime.UtcNow;
            var coDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(d, "SA Pacific Standard Time");
            var dayOfTheWeek = coDate.ToString("EEEE", usCulture);

            Day day;
            Day[] mList = Day.availablesDays();

            for (int i = 0; i < Day.availablesDays().Length; i++)
            {
                day = mList[i];
                if (day.identifyDay == dayOfTheWeek && day.type.Equals(Day.TypeOfDay.NORMAL_DAY))
                {
                    //var letter :String = licensePlate[0].toString()
                    String letter = "";

                    if (letter.Equals(INITIAL_WITH_SPECIAL_CONDITION) ||
                        letter.Equals(INITIAL_WITH_SPECIAL_CONDITION_LOWER))
                    {
                        return false;
                    }
                }
                Console.WriteLine(i);
            }


            return true;
        }

        public Boolean carLimitValidation(int currentQuantity)
        {
            return false;
        }

        public Boolean motorcycleLimitValidation(int currentQuantity)
        {
            return false;
        }
        /*
        public ArrayList<Vehicle> getAllVehicles()
        {

        }
        
        public ArrayList<Vehicle> getOnlyVehiclesEnteredParkingLot()
        {

        }
        */
        public void saveMotorcycle(Car car)
        {
            
        }

        public void saveMotorcycle(Motorcycle motorcycle)
        {

        }

        public int calculateCostToPay(int priceByHour, int priceByDay, int entryDateString)
        {
            return 0;
        }
        /*
        public int convertTimeToHour(Date entyDateg)
        {
            return 0;
        }

        public int exitToAVehicle(Vehicle vehicle)
        {
            return 0;
        }

        public int getCostToPay(Vehicle vehicle)
        {
            return 0;
        }
        */
        public Boolean enterANewCar(Car car)
        {
            return false;
        }

        public Boolean enterANewMotorcycle(Motorcycle motorcycle)
        {
            return false;
        }

        public String currentDate()
        {
            return "";
        }
        
    }
}
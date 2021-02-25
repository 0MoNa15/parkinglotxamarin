using System;
namespace ADNZorayda.Domain.parkinglot
{
    public class Day
    {
        public String identifyDay = null;
        public TypeOfDay? type =  null;

        public Day()
        {
           
        }

        public struct TypeOfDay
        {
            // Solo en los dias especiales pueden ingresar los vehiculos con placa que inicie en 'A'
            public static String SPECIAL_DAYD;
            public static String NORMAL_DAY;
        }

        //fun availablesDays(): ArrayList<Day>{

        public static Day[] availablesDays()
        {
            Day[] days = Day[];

            return days;
        }
    }
}

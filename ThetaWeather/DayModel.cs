namespace ThetaWeather
{
    internal class DayModel
    {
        public DayModel(int dayNumber, int maxTemp, int minTemp)
        {
            _dayNumber = dayNumber;
            _minTemp = minTemp;
            _maxTemp = maxTemp;
        }

        private int _dayNumber;

        public int DayNumber
        {
            get { return _dayNumber; }
            set { _dayNumber = value; }
        }

        private int _minTemp;

        public int MinTemp
        {
            get { return _minTemp; }
            set { _minTemp = value; }
        }

        private int _maxTemp;

        public int MaxTemp
        {
            get { return _maxTemp; }
            set { _maxTemp = value; }
        }

        public int TempRange
        {
            get { return _maxTemp - _minTemp; }
        }



    }
}

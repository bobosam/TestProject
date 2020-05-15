namespace DataDriven
{
    using System;

    public class HelpMethods
    {
        public static string GetDirectory()
        {
            string directory = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString();

            return directory;
        }

        /// <summary>
        /// Generate PID by current day and difference of days 
        /// </summary>
        /// <param name="age">integer number</param>
        /// <param name="diffDays">positive or negative integer number</param>
        /// <returns>string for current pid</returns>
        public static string GeneratePID(int age, int diffDays)
        {
            int[] numbers = new int[10];
            int[] weight = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

            DateTime date = DateTime.Now;
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            year -= age;
            if (year > 1999)
            {
                month += 40;
            }

            if (diffDays > (day - 1))
            {
                if (month > 1)
                {
                    month = month - 1;
                    day += DateTime.DaysInMonth(year, month);
                }
                else
                {
                    year = year - 1;
                    month = 12;
                    day += DateTime.DaysInMonth(year, month);
                }
            }

            day -= diffDays;

            Random rnd = new Random();
            numbers[0] = (year % 100) / 10;
            numbers[1] = (year % 100) % 10;
            numbers[2] = month / 10;
            numbers[3] = month % 10;
            numbers[4] = day / 10;
            numbers[5] = day % 10;
            numbers[6] = rnd.Next(0, 10);
            numbers[7] = rnd.Next(0, 10);
            numbers[8] = rnd.Next(0, 10);

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * weight[i];
            }

            numbers[9] = sum % 11;
            if (numbers[9] == 10)
            {
                numbers[9] = 0;
            }

            string result = string.Empty;
            foreach (var number in numbers)
            {
                result += number.ToString();
            }

            return result;
        }

        public static string GetBirthDayByPid(string pid)
        {
            var year = pid.Substring(0, 2);
            var month = pid.Substring(2, 2);
            var day = pid.Substring(4, 2);
            string birthDay;

            if (int.Parse(month) > 40)
            {
                month = (int.Parse(month) - 40).ToString();
                birthDay = string.Format("{0}/{1}/20{2}", day, month, year);
            }
            else
            {
                birthDay = string.Format("{0}/{1}/19{2}", day, month, year);
            }

            return birthDay;
        }
    }
}

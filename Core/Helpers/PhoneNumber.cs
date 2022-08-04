
using System.Text.RegularExpressions;


namespace Core.Helpers
{
    public static class PhoneNumber
    {
        public const string motif = @"^([\+]?994[-]?|[0])?[1-9][0-9]{8}$";
        public static bool IsPhoneNumber(string number)
        {
            try
            {
            if (number != null)
            {
                return Regex.IsMatch(number, motif);
            }
            else
            {
                return false;
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

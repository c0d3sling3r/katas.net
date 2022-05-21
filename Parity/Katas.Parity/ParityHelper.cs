namespace Katas.Parity;

public class ParityHelper
{
    public static string DetermineArraySum(int[] numbers)
    {
        int sum = numbers.Sum();

        return _getParityString(sum);
    }

    private static string _getParityString(int number)
    {
        return number % 2 == 0 ? "even" : "odd";
    }
}
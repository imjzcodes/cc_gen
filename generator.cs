using System;
using System.Text;

public class CardGenerator
{
    public static string Gen(long baseNumber, int amount, string separator)
    {
        if (baseNumber < 100000 || baseNumber > 999999)
        {
            throw new ArgumentException("Base number must be a 6-digit number.");
        }

        Random random = new Random();
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < amount; i++)
        {
            // Generate card number
            long cardNumber = baseNumber * 10000000000L +
                              (long)random.Next(100000, 1000000) * 10000L +
                              random.Next(10000);

            // Generate expiration date (mm/yyyy)
            int month = random.Next(1, 13);
            int year = random.Next(2026, 2036);

            // Generate CVV
            int cvv = random.Next(100, 1000);

            // Append to result
            result.Append(cardNumber.ToString("D16"))
                  .Append(separator)
                  .Append($"{month:D2}/{year}")
                  .Append(separator)
                  .Append(cvv.ToString("D3"));

            if (i < amount - 1)
            {
                result.AppendLine();
            }
        }

        return result.ToString();
    }
}

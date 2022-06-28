namespace Testing.Validation
{
    public class AccountNumberValidation
    {
        private const int startingPartLength = 3;
        private const int middlePartLength = 10;
        private const int lastPartLength = 2; 
        
        public bool IsValid(string accountNumber)
        {
            var firstDelimiter = accountNumber.IndexOf('-');
            var secoundDelimiter = accountNumber.IndexOf('-');

          if (firstDelimiter == -1 || secoundDelimiter == -1)
            throw new ArgumentException();
            
          var firstPart = accountNumber.Substring(0, firstDelimiter);
          if (firstPart.Length != startingPartLength)
                return false;
          var temPart = accountNumber.Remove(0, startingPartLength +1);

          var middlePart = temPart.Substring(0, temPart.IndexOf('-'));
          if (middlePart.Length != middlePartLength)
                return false;

          var lastPart = accountNumber.Substring(secoundDelimiter + 1);
          if (lastPart.Length != lastPartLength)
                return false;

       
        }

    }
}

using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("JsonStorageManagerUnitTests")]
namespace JsonStorageManager.QueueProcessor
{
    internal class Validator
    {
        public bool IsValid(string message)
        {
            try
            {
                JsonDocument.Parse(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

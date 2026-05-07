using System.IO.MemoryMappedFiles;
using System.Text;

namespace CinemaApp.Services
{
    public class MemoryMappedService
    {
        public void SendNotification(
            string message)
        {
            using var mmf =
                MemoryMappedFile.CreateOrOpen(
                    "CinemaNotifications",
                    1024
                );

            using var stream =
                mmf.CreateViewStream();

            byte[] data =
                Encoding.UTF8.GetBytes(message);

            stream.Write(data, 0, data.Length);
        }
    }
}
using System.IO.Pipes;
using System.Text;

namespace CinemaApp.Services
{
    public class PipeClientService
    {
        public async Task SendMessage(
            string text)
        {
            using NamedPipeClientStream client =
                new NamedPipeClientStream(
                    ".",
                    "CinemaPipe",
                    PipeDirection.Out
                );

            await client.ConnectAsync();

            byte[] data =
                Encoding.UTF8.GetBytes(text);

            await client.WriteAsync(
                data,
                0,
                data.Length
            );
        }
    }
}
using System.IO.Pipes;
using System.Text;
using System.Windows;

namespace CinemaApp.Services
{
    public class PipeServerService
    {
        public async Task StartServer()
        {
            while (true)
            {
                using NamedPipeServerStream server =
                    new NamedPipeServerStream(
                        "CinemaPipe"
                    );

                await server.WaitForConnectionAsync();

                byte[] buffer =
                    new byte[1024];

                int count =
                    await server.ReadAsync(
                        buffer,
                        0,
                        buffer.Length
                    );

                string message =
                    Encoding.UTF8.GetString(
                        buffer,
                        0,
                        count
                    );

                MessageBox.Show(
                    $"Сообщение клиента:\n{message}"
                );
            }
        }
    }
}
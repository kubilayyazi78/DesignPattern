// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


ILogger logger = new BufferedFileLoggerProxy(5);
logger.Log("787878");

class BufferedFileLoggerProxy : ILogger
{
    private readonly int bufferSize;
    private readonly FileLogger fileLogger;
    private List<string> buffer;
    public BufferedFileLoggerProxy(int bufferSize)
    {
        this.bufferSize = bufferSize;
        this.fileLogger = new FileLogger();
        buffer = new List<string>(capacity: bufferSize);
    }
    public void Log(string message)
    {
        buffer.Add(message);
        if (bufferSize <= buffer.Count)
        {
            foreach (var log in buffer)
            {
                fileLogger.Log(log);
            }
            buffer.Clear();
        }
    }

    public void Log(IEnumerable<string> messages)
    {
        //throw new Exception();
        fileLogger.Log(messages);
    }
}
class FileLogger : ILogger
{
    public void Log(string message)
    {
        message = $"[{DateTime.Now:dd.mm.yyyy}- {message}]";
        File.AppendAllText("message.log", message);
    }

    public void Log(IEnumerable<string> messages)
    {
        File.AppendAllText("message.log", string.Join(Environment.NewLine, messages));
    }
}
interface ILogger
{
    void Log(string message);

    void Log(IEnumerable<string> messages);
}
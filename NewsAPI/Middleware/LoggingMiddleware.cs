using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace NewsAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        string logFilePath;
        Stopwatch stopwatch;
        public LoggingMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            logFilePath = environment.ContentRootPath + @"/LogFile.txt";
            stopwatch = new Stopwatch();
        }

        /*log the information into file at given file path. 
         * Note:If File don't exist create a file i.e LogFile.txt
        */
        public async Task Invoke(HttpContext context)
        {
            
            if(!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }
            var endPoint = context.Request.Path;
            var incomingTime = DateTime.Now;
            var outgoingTime = DateTime.Now;
            var message = "Processed Successfully";
            try
            {
                await _next.Invoke(context);
                outgoingTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                outgoingTime = DateTime.Now;
            }
            var processingTime = outgoingTime.Subtract(incomingTime);
            var logContent = $"{endPoint} was hit at {incomingTime}. Status:-{message}. Processing Time:-{processingTime}/n";            
            var fileContent=File.ReadAllText(logFilePath);
            fileContent = fileContent + logContent;
            File.WriteAllText(logFilePath, fileContent);
            
        }
    }
}

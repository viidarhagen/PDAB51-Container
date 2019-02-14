using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Visma.Training.Serverless.ServiceBus
{
        public  class SendTopic
        {
            public static string ServiceBusConnectionString = "";
            public static  string TopicName = "";
            public static string Message = "";
            public static int NumberOfMessages = 1;
            static ITopicClient topicClient;

        public static void Send(string cstr, string topicname, string messasge, int numberOfMessages)
        {
            ServiceBusConnectionString = cstr;
            TopicName = topicname;
            Message = messasge;
            NumberOfMessages = numberOfMessages;

            MainAsync().GetAwaiter().GetResult();
        }


            static async Task MainAsync()
            {
            
                topicClient = new TopicClient(ServiceBusConnectionString, TopicName);
             
                // Send messages.
                await SendMessagesAsync(NumberOfMessages);

                await topicClient.CloseAsync();
            }

            static async Task SendMessagesAsync(int numberOfMessagesToSend)
            {
                try
                {
                    for (var i = 0; i < numberOfMessagesToSend; i++)
                    {
                        // Create a new message to send to the topic
                        string messageBody = Message + " " + i;
                        var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                        // Send the message to the topic
                        await topicClient.SendAsync(message);
                    }
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
        }
    }



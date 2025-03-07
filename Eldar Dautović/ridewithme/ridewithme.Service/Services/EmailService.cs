﻿using EasyNetQ;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ridewithme.Service.Interfaces;
using System.Threading.Channels;
using Newtonsoft.Json;

namespace ridewithme.Service.Services
{
    public class EmailService : IEmailService
    {

        private readonly string _host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq";
        private readonly string _username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "user";
        private readonly string _password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "mypass";
        private readonly string _virtualhost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/";

        public void SendingMessage(string message, int senderId, int recieverId)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _host,
                    UserName = _username,
                    Password = _password,
                    VirtualHost = _virtualhost,
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare("chat", false, false, false, null);

                var messageData = new
                {
                    SenderId = senderId,
                    RecieverId = recieverId,
                    Message = message
                };

                // Serializacija objekta u JSON
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageData));

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "chat",
                                     basicProperties: null,
                                     body: body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending message to RabbitMQ: {ex.Message}");
            }
        }

        public void SendingObject<T>(T obj)
        {
            var host = _host;
            var username = _username;
            var password = _password;
            var virtualhost = _virtualhost;

            using var bus = RabbitHutch.CreateBus($"host={host};virtualHost={virtualhost};username={username};password={password}");

            bus.PubSub.Publish(obj);
        }
    }
}
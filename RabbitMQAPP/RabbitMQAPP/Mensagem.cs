using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQAPP
{
    public class Mensagem
    {
        private readonly ConnectionFactory _factory;
        private readonly string nomeFila = "MinhaFila";
        public Mensagem()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
        }

        public void Publicar()
        {
            var conectarRabbit = _factory.CreateConnection();
            var canal = conectarRabbit.CreateModel();


            IBasicProperties iBasicProperties = canal.CreateBasicProperties();


            Cliente cliente = new Cliente();
            cliente.Nome = "Renan Lima";
            cliente.DataNascimento = DateTime.Now;
            cliente.CPF = "111.222.333-44";
            cliente.RG = "11.222.333-4";

            var dados = JsonConvert.SerializeObject(cliente);

            var corpoMensagem = Encoding.UTF8.GetBytes(dados);

            // Criar fila
            //canal.QueueDeclare(queue: nomeFila, durable: true, exclusive: false, autoDelete: false, arguments: null);

            //Mensagem Publica direto na FILA
            //canal.BasicPublish(exchange: "", routingKey: nomeFila, basicProperties: iBasicProperties, body: corpoMensagem);

            //Publica na EXCHANGE
            canal.BasicPublish(exchange: "emails", routingKey: "", basicProperties: iBasicProperties, body: corpoMensagem);
            

        }
    }
}

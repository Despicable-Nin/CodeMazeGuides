using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Transport.InMem;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;
using MessagingComparisons.Rebus;
using Rebus.Encryption;
using Rebus.Retry.Simple;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<IMessageBusStrategy, RebusStrategy>();
builder.Services.AddScoped<IMessageSender, MessageSender>(sp => 
    new MessageSender(
        sp.GetRequiredService<IMessageBusStrategy>(),
        "Rebus"
    ));

builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(true), "MyQueue"))
    .Routing(r => r.TypeBased().MapAssemblyOf<Message>("MyQueue"))
    .Options(o =>
    {
        o.RetryStrategy(
            maxDeliveryAttempts: 5,
            secondLevelRetriesEnabled: true,
            errorQueueName: "ErrorQueue");
        o.EnableEncryption("mK8nD2pL9qR5vX7hJ4tF3wA6cE1bN0yZ");
    }));
builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/send-message", async (IMessageSender messageSender) =>
    {
        await messageSender.SendMessageAsync();
        
        return Results.Ok();
    })
    .WithName("Send Message")
    .WithOpenApi();

app.Run();
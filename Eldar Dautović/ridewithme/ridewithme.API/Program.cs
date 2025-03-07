using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quartz;
using ridewithme.API;
using ridewithme.API.Filters;
using ridewithme.Service.Database;
using ridewithme.Service.KuponiStateMachine;
using ridewithme.Service.ObavjestenjaStateMachine;
using ridewithme.Service.VoznjeStateMachine;
using ridewithme.Service.ZalbeStateMachine;
using ridewithme.Service.Jobs;
using ridewithme.Service.Services;
using ridewithme.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddTransient<IVoznjeService, VoznjeService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IUlogeervice, Ulogeervice>();
builder.Services.AddTransient<IGradoviService, GradoviService>();
builder.Services.AddTransient<IKuponiService, KuponiService>();
builder.Services.AddTransient<IVrstaZalbeService, VrstaZalbeService>();
builder.Services.AddTransient<IZalbeService, ZalbeService>();
builder.Services.AddTransient<IReklameService, ReklameService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IDogadjaji, DogadjajiService>();
builder.Services.AddTransient<IObavjestenjaService, ObavjestenjaService>();
builder.Services.AddTransient<IStatistikaService,  StatistikaService>();
builder.Services.AddTransient<IFAQService, FAQService>();
builder.Services.AddTransient<IDostignucaService, DostignucaService>();
builder.Services.AddTransient<IRecenzijaService, RecenzijaService>();
builder.Services.AddTransient<IChatService, ChatService>();

//State machine
builder.Services.AddTransient<BaseVoznjeState>();
builder.Services.AddTransient<InitialVoznjeState>();
builder.Services.AddTransient<DraftVoznjeState>();
builder.Services.AddTransient<ActiveVoznjeState>();
builder.Services.AddTransient<HiddenVoznjeState>();
builder.Services.AddTransient<BookedVoznjeState>();
builder.Services.AddTransient<InProgressVoznjeState>();
builder.Services.AddTransient<CompletedVoznjeState>();

builder.Services.AddTransient<BaseKuponiState>();
builder.Services.AddTransient<InitialKuponiState>();
builder.Services.AddTransient<DraftKuponiState>();
builder.Services.AddTransient<HiddenKuponiState>();
builder.Services.AddTransient<ActiveKuponiState>();

builder.Services.AddTransient<BaseZalbeState>();
builder.Services.AddTransient<InitialZalbeState>();
builder.Services.AddTransient<ActiveZalbeState>();
builder.Services.AddTransient<ProcessingZalbeState>();
builder.Services.AddTransient<CompletedZalbeState>();

builder.Services.AddTransient<BaseObavjestenjaState>();
builder.Services.AddTransient<InitialObavjestenjaState>();
builder.Services.AddTransient<DraftObavjestenjaState>();
builder.Services.AddTransient<ActiveObavjestenjaState>();
builder.Services.AddTransient<HiddenObavjestenjaState>();
builder.Services.AddTransient<CompletedObavjestenjeState>();


builder.Services.AddControllers(x=> x.Filters.Add<ExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[]{}
    } });

});

var connectionString = builder.Configuration.GetConnectionString("ridewithme");
builder.Services.AddDbContext<RidewithmeContext>(options =>
    options.UseSqlServer(connectionString).EnableDetailedErrors().EnableSensitiveDataLogging());

builder.Services.AddMapster();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddQuartz(q =>
{
    var obavjestenjaJobKey = new JobKey("CompletedObavjestenjaJob");

    q.AddJob<CompletedObavjestenjaJob>(opts => opts.WithIdentity(obavjestenjaJobKey));

    q.AddTrigger(opts => opts
        .ForJob(obavjestenjaJobKey)
        .WithIdentity("CompletedObavjestenjaJob-trigger")
        .WithCronSchedule("0 0 0 * * ?")
    );

});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<RidewithmeContext>();

    dataContext.Database.Migrate();
}

app.Run();

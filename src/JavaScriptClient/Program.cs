using System.IdentityModel.Tokens.Jwt;
using Duende.Bff;
using Duende.Bff.Yarp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthorization();


builder.Services.AddBff().AddRemoteApis();

//builder.Services.AddReverseProxy()
//    .AddTransforms<AccessTokenTransformProvider>();

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
    options.DefaultSignOutScheme = "oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://localhost:5001";

    options.ClientId = "bff";
    options.ClientSecret = "secret";
    options.ResponseType = "code";

    options.Scope.Add("api1");

    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");


app.UseDeveloperExceptionPage();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseBff();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
        .AsBffApiEndpoint();

    endpoints.MapBffManagementEndpoints();

    endpoints.MapRemoteBffApiEndpoint("/remote", "https://localhost:6001")
        .RequireAccessToken(Duende.Bff.TokenType.User);

});



app.Run();

using BoilerPlate.Data;
using BoilerPlate.Entities;
using BoilerPlate.Repositories;
using BoilerPlate.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
namespace BoilerPlate.WebAPI
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(Startup.CreateSecurityContext);
            app.CreatePerOwinContext<CustomUserManager>(Startup.CreateUserManager);
            app.CreatePerOwinContext<CustomRoleManager>(Startup.CreateRoleManager);
            app.CreatePerOwinContext<CustomClientManager>(Startup.CreateClientManager);
            app.CreatePerOwinContext<CustomTokenManager>(Startup.CreateTokenManager);
            app.CreatePerOwinContext<NotificationManager>(Startup.CreateNotificationManager);
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                Provider = new AuthenticationProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(Common.Constants.AuthenticationTimeout)
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            };
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");
            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");
            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
        public static DataContext CreateSecurityContext()
        {
            return new DataContext();
        }
        public static CustomUserManager CreateUserManager(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            // *** PASS CUSTOM APPLICATION USER STORE AS CONSTRUCTOR ARGUMENT:
            var manager = new CustomUserManager(new CustomUserStore(context.Get<DataContext>()));
            // Configure validation logic for usernames
            // *** ADD INT TYPE ARGUMENT TO METHOD CALL:
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromDays(365);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers.
            // This application uses Phone and Emails as a step of receiving a
            // code for verifying the user You can write your own provider and plug in here.
            // *** ADD INT TYPE ARGUMENT TO METHOD CALL:
            //manager.RegisterTwoFactorProvider("PhoneCode",
            //    new PhoneNumberTokenProvider<ApplicationUser, int>
            //    {
            //        MessageFormat = "Your security code is: {0}"
            //    });
            // *** ADD INT TYPE ARGUMENT TO METHOD CALL:
            //manager.RegisterTwoFactorProvider("EmailCode",
            //    new EmailTokenProvider<ApplicationUser, int>
            //    {
            //        Subject = "SecurityCode",
            //        BodyFormat = "Your security code is {0}"
            //    });
            //manager.SmsService = new SmsService();
            manager.EmailService = new CustomEmailService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                // *** ADD INT TYPE ARGUMENT TO METHOD CALL:
                //manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
                //manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity")){ TokenLifespan = TimeSpan.FromDays(1) };
                manager.UserTokenProvider = new CustomUserTokenProvider() { TokenLifespan = TimeSpan.FromDays(1) };
            }

            return manager;
        }
        public static CustomRoleManager CreateRoleManager(IdentityFactoryOptions<CustomRoleManager> options, IOwinContext context)
        {
            return new CustomRoleManager(new CustomRoleStore(context.Get<DataContext>()));
        }
        public static CustomClientManager CreateClientManager(IdentityFactoryOptions<CustomClientManager> options, IOwinContext context)
        {
            return new CustomClientManager(context.Get<DataContext>());
        }
        public static CustomTokenManager CreateTokenManager(IdentityFactoryOptions<CustomTokenManager> options, IOwinContext context)
        {
            return new CustomTokenManager(context.Get<DataContext>());
        }
    }
}

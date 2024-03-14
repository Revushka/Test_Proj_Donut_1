using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Test_Proj_Donut_1.Helper;
using Test_Proj_Donut_1.Services;
using System.Threading.Tasks;

namespace Test_Proj_Donut_1.Controllers
{
    public class GoogleOAuthController : Controller
    {
        public IActionResult RedirectOnOAuthServer()
        { 
            var scope = "https://www.googleapis.com/auth/youtube";
            var redirecturl = "https://localhost:7109/GoogleOAuth/Code";
            var codeVerifier = Guid.NewGuid().ToString();

            HttpContext.Session.SetString("codeVerifier", codeVerifier); // Помилка (Session has not been configured for this application or request), додав builder.Services.AddSession(); та app.UseSession();

            var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);

            var url = GoogleOauthService.GenerateOauthRequestUrl(scope, redirecturl, codeChallenge);
            return Redirect(url);
        }

        public async Task<IActionResult> Code(string code)
        {
            string codeVerifier = HttpContext.Session.GetString("codeVerifier");
            var redirecturl = "https://localhost:7109/GoogleOAuth/Code";
            var tokenResult = await GoogleOauthService.ExchangeCodeOnTokenAsync(code, codeVerifier, redirecturl);

            //var MyChannelId = await YouTubeServices.GetMyChannelIdAsync(tokenResult.AccessToken);
            //var newDescription = "Hello from YouTube API!!!:3";
            //await YouTubeServices.UpdateChannelDescriptionAsync(tokenResult.AccessToken, MyChannelId, newDescription);

            var refreshedTokenResult = await GoogleOauthService.RefreshTokenAsync(tokenResult.RefreshToken);
            return Ok();
            //return RedirectToAction("MainPage/Index");
        }
    }
}

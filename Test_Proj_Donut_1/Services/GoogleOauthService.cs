using Microsoft.AspNetCore.WebUtilities;
using Test_Proj_Donut_1.Helper;

namespace Test_Proj_Donut_1.Services
{
    public class GoogleOauthService
    {
        private const string ClientID = "1060603001128-sivtauvvsuuoqstpa6ju5kahgdtvildv.apps.googleusercontent.com";
        private const string ClientSecret = "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";
        private const string TokenServerEndpoint = "https://oauth2.googleapis.com/token";
        private const string oAuthServerEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        public static string GenerateOauthRequestUrl(string scope, string redirectUrl, string codeChallenge)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "client_id", ClientID },
                { "redirect_uri", redirectUrl },
                { "response_type", "code" },
                { "scope", scope},
                { "code_challenge", codeChallenge },
                { "code_challenge_method", "S256" },
                { "access_type", "offline" }
            };
            var url = QueryHelpers.AddQueryString(oAuthServerEndpoint, queryParams);
            return url;
        }
        public static async Task<TokenResult> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirecturl)
        {
            var authParams = new Dictionary<string, string>
            {
                { "client_id", ClientID },
                { "client_secret", ClientSecret },
                { "code", code },
                { "code_verifier", codeVerifier},
                { "grant_type", "authorization_code" }, //authorization_code
                { "redirect_uri", redirecturl}
            };

            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(TokenServerEndpoint, authParams);
            return tokenResult;

        }
        public static async Task<TokenResult> RefreshTokenAsync(string refreshToken)
        {
            var refreshParams = new Dictionary<string, string>
            {
                { "client_id", ClientID },
                { "client_secret", ClientSecret },
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken },
                { "prompt", "consert"}
            };
            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(TokenServerEndpoint, refreshParams); 
            return tokenResult;
        }
    }
}
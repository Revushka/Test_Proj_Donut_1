using Microsoft.AspNetCore.Mvc;
using Test_Proj_Donut_1.Helper;

namespace Test_Proj_Donut_1.Services
{
    public class YouTubeServices
    {
    //    private const string YoutubeApiEndpoint = "https://www.googleapis.com/youtube/v3/channels"; //посилання на яке буде відправелний GET запит
    //    public static async Task<string> GetMyChannelIdAsync(string accessToken)
    //    {
    //        var queryParams = new Dictionary<string, string> //потрібні параметри для отримання каналу по авторизованому користувачу
    //        {
    //            { "mine", "true" }
    //        };
    //        var response = await HttpClientHelper.SendGetRequest<dynamic>(YoutubeApiEndpoint, queryParams, accessToken); //посилаємо запит на те посилання, що є в YoutubeApiEndpoint, передаємо туди все що є в queryParams + додаєм accessToken
    //        var channelId = response.items[0].id; //у користувача може бути більше одного каналу, тому ми беремо тільки перший з них (items[0.id])
    //        return channelId; // ми отримали id нашого каналу на ютубі
    //    }

    //    public static async Task UpdateChannelDescriptionAsync(string accessToken, string channelId, string newDescription)
    //    {
    //        var queryParams = new Dictionary<string, string>()
    //        {
    //            { "part", "brandingSettings"}
    //        };

    //        var body = new 
    //        { 
    //            id = channelId,
    //            brandingSettings = new 
    //            { 
    //                channel = new 
    //                { 
    //                    description = newDescription 
    //                } 
    //            } 
    //        };

    //        await HttpClientHelper.SendPutRequest(YoutubeApiEndpoint, queryParams, body, accessToken);
    //    }
    }
}

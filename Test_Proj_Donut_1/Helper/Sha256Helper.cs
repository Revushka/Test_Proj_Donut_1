﻿using IdentityModel;
using System.Text;
using System.Security.Cryptography;

namespace Test_Proj_Donut_1.Helper
{
    public class Sha256Helper
    {
        public static string ComputeHash(string codeVerifier)
        {
            using var sha256 = SHA256.Create();
            var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
            var codeChallenge = Base64Url.Encode(challengeBytes);
            return codeChallenge;
        }
    }
}

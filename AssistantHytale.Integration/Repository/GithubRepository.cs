﻿using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Integration.Repository.Interface;

namespace AssistantHytale.Integration.Repository
{
    public class GithubRepository: BaseExternalApiRepository, IGithubRepository
    {
        private readonly string _baseGithubUrl = "https://raw.githubusercontent.com/AssistantSMS/App/master/assets/lang/";

        public async Task<string> GetFileContents(string filename)
        {
            if (IsMaliciousName(filename)) return "{}";

            ResultWithValue<string> githubFileContents = await Get($"{_baseGithubUrl}{filename}");

            if (githubFileContents.HasFailed) return "{}";

            return githubFileContents.Value;
        }

        private bool IsMaliciousName(string filename)
        {
            Regex regexLangFileName = new Regex(@"(language.)([a-z]|\-){2,7}(.json)");
            return !regexLangFileName.Match(filename).Success;
        }
    }
}

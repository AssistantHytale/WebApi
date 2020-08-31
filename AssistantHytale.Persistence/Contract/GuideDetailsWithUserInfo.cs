using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Contract
{
    public class GuideDetailsWithUserInfo: GuideDetail
    {
        public string UserName { get; set; }
        public string TranslatorName { get; set; }
    }
}

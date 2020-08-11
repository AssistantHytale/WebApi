using System.Threading.Tasks;

namespace AssistantHytale.Integration.Repository.Interface
{
    public interface IGithubRepository
    {
        Task<string> GetFileContents(string filename);
    }
}
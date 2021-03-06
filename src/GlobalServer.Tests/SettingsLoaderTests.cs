using Xunit;
using System;
using System.Threading.Tasks;
using GlobalServer.Properties;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Initialization;
using static GlobalServer.Tests.Files.FileNames;
using static GlobalServer.Tests.Files.FileLoader;
using static GlobalServer.Tests.Mocks.MockFileSystemAdapter;

namespace GlobalServer.Tests
{
    public class SettingsLoaderTests
    {
        [Theory]
        [InlineData(OneGetRequest, typeof(GetRequest))]
        [InlineData(OnePutRequest, typeof(PutRequest))]
        [InlineData(OnePostRequest, typeof(PostRequest))]
        [InlineData(OneUnknownRequest, typeof(NullRequest))]
        [InlineData(OneDeleteRequest, typeof(DeleteRequest))]
        public void GivenFileWithSpecifiedRequest_ThenRequestDescriptionIsCorrectType(string fileName, Type requestType)
        {
            var settings = LoadSettings(fileName);

            var interaction = Assert.Single(settings.Result.Interactions);
            Assert.NotNull(interaction);

            Assert.IsType(requestType, interaction.Request);
        }

        private static Task<ISettings> LoadSettings(string fileName)
        {
            const string fileLocation = @"c:\MyFile.txt";
            var fileSystem = Create(fileLocation, GetFileContents(fileName));

            var propertiesBuilder = new PropertiesBuilder()
                .WithFileSystem(fileSystem)
                .Build();

            return propertiesBuilder.GetSettingsLoader().Load(fileLocation);
        }
    }
}
